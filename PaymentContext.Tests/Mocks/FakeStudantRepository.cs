using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks;

public class FakeStudantRepository : IStudantRepository
{
    public void CreateSubscription(Student student)
    {
        throw new NotImplementedException();
    }

    public bool DocumentExists(string document)
    {
        if (document == "9999999999")
            return true;
        return false;
    }

    public bool EmailExists(string email)
    {
        if (email == "teste@gmail.com")
            return true;
        return false;
    }
}