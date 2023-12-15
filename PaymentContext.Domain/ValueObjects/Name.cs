using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObjct
{
    public Name(string firsName, string lastName)
    {
        FirsName = firsName;
        LastName = lastName;
        if (string.IsNullOrEmpty(FirsName))
        {
            AddNotification("Name.FirsName", "Nome inválido");
        }
    }

    public string FirsName { get; private set; }
    public string LastName { get; private set; }
}