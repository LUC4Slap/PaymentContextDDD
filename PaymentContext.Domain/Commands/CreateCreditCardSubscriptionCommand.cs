using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands;

public class CreateCreditCardSubscriptionCommand
{
    // Name
    public string FirsName { get; set; }
    public string LastName { get; set; }

    // Document
    public string Document { get; set; }

    // Email
    public string Email { get; set; }

    // Credit Card
    public string CartHolderName { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }

    // Payment
    public string PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; }

    // Adrress
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}