using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObjct
{
    public Name(string firsName, string lastName)
    {
        FirsName = firsName;
        LastName = lastName;

        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(FirsName, 3, "Name.FirsName", "Nome deve conter pelo menos 3 caractres")
                .HasMinLen(LastName, 3, "Name.lastName", "Sobrenome deve conter pelo menos 3 caractres")
                .HasMaxLen(FirsName, 40, "Name.FirsName", "Nome deve conter até 40 caractres")
                .HasMaxLen(LastName, 40, "Name.lastName", "Sobrenome deve conter até 40 caractres")
        );
    }

    public string FirsName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirsName} {LastName}";
    }
}