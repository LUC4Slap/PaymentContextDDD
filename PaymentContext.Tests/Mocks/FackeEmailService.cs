using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks;

public class FackeEmailService : IEmailService
{
    public void Send(string to, string email, string subject, string body)
    {
    }
}