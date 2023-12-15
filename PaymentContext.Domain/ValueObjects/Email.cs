using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObjct
{
    public Email(string address)
    {
        Address = address;
    }

    public string Address { get; private set; }
}