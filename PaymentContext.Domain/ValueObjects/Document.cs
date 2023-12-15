using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObjct
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;

        AddNotifications(new Contract()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Documento inválido")
        );
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }

    private bool Validate()
    {
        //"05996585000165"
        if (Type == EDocumentType.CNPJ && Number.Length == 14)
            return true;

        if (Type == EDocumentType.CPF && Number.Length == 11)
            return true;

        return false;
    }
}