using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTest
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var subscription = new Subscription(null);
        var student = new Student("Lucas", "Almeida", "61451463030", "teste@gmail.com");
        student.AddSubscription(subscription);
    }
}