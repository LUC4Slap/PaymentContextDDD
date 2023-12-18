using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTest
{
    private readonly Student _studant;
    private readonly Subscription _subscription;
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;

    public StudentTest()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("43253800008", EDocumentType.CPF);
        _email = new Email("batman@dc.com");
        _address = new Address("Rua 1", "1234", "Bairro legal", "Gotam", "MS", "BR", "1234567");
        _studant = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldRetornErroWhenHadAciveSubscription()
    {
        var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document,
            _address, _email, "123456789");
        _subscription.AddPayment(payment);
        _studant.AddSubscription(_subscription);
        _studant.AddSubscription(_subscription);

        Assert.IsTrue(_studant.Invalid);
    }

    [TestMethod]
    public void ShouldRetornErroWhenSubscriptionHasNoPayment()
    {
        _studant.AddSubscription(_subscription);
        Assert.IsTrue(_studant.Invalid);
    }

    [TestMethod]
    public void ShouldRetornSuccessWhenAddSubscription()
    {
        var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document,
            _address, _email, "123456789");
        _subscription.AddPayment(payment);
        _studant.AddSubscription(_subscription);

        Assert.IsTrue(_studant.Valid);
    }
}