using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTest
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
//        var subscription = new Subscription(null);
//        var student = new Student("Lucas", "Almeida", "61451463030", "teste@gmail.com");
//        student.AddSubscription(subscription);
        var name = new Name("Teste", "Teste");
        foreach (var not in name.Notifications)
        {
            Console.WriteLine(not.Message);
        }
    }
}