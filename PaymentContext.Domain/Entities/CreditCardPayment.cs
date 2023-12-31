using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public CreditCardPayment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer,
        Document document, Address address, Email email, string cartHolderName, string cardNumber,
        string lastTransactionNumber) : base(paidDate, expiredDate, total, totalPaid, payer, document, address, email)
    {
        CartHolderName = cartHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CartHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
}