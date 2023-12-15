using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObjct
{
    public Name(string firsName, string lastName)
    {
        FirsName = firsName;
        LastName = lastName;
    }

    public string FirsName { get; private set; }
    public string LastName { get; private set; }
}