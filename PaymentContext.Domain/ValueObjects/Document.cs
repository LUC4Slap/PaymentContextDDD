using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObjct
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
}