using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private IList<Subscription> _subscriptions;

    public Student(Name name, Document document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscriptions = new List<Subscription>();

        AddNotifications(name, document, email);
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get { return _subscriptions.ToArray(); }
    }

    public void AddSubscription(Subscription subscription)
    {
//        if (subscription.Payments.Count == 0)
        var hasSUbscriptionActive = false;
        foreach (var sub in _subscriptions)
        {
            if (sub.Active)
                hasSUbscriptionActive = true;
        }

        AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasSUbscriptionActive, "Studand.Subscriptions", "Você ja tem uma assinatura ativa")
            .AreEquals(0, subscription.Payments.Count, "Studand.Subscription.Payments",
                "Esta Assinatura não possui pagamento")
        );

        // alternativa
//        if (hasSUbscriptionActive)
//            AddNotification("Studand.Subscriptions", "Você ja tem uma assinatura ativa");
    }
}