using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
{
    // Name
    public string FirsName { get; set; }
    public string LastName { get; set; }

    // Document
    public string Document { get; set; }

    // Email
    public string Email { get; set; }

    // PayPal
    public string TransactionCode { get; set; }

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

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(FirsName, 3, "Name.FirsName", "Nome deve conter pelo menos 3 caractres")
            .HasMinLen(LastName, 3, "Name.lastName", "Sobrenome deve conter pelo menos 3 caractres")
            .HasMaxLen(FirsName, 40, "Name.FirsName", "Nome deve conter até 40 caractres")
            .HasMaxLen(LastName, 40, "Name.lastName", "Sobrenome deve conter até 40 caractres"));
    }
}