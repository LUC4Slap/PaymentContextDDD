using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>
{
    private readonly IStudantRepository _repository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudantRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        // Fail Fast Validatios
        command.Validate();
        if (command.Invalid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possivel realizar sua assinatura");
        }

        // Verificar se doc esta cadastrado
        if (_repository.DocumentExists(command.Document))
            AddNotification("Document", "Este documento ja esta em uso.");

        // Verificar se email esta cadastrado
        if (_repository.EmailExists(command.Email))
            AddNotification("Email", "Este Email já esta sendo utilizado.");

        // Gerar os VOs
        var name = new Name(command.FirsName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
            command.Country, command.ZipCode);

        // Gerar as Entidades
        var studant = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(
            command.PaidDate,
            command.ExpiredDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email,
            command.BarCode,
            command.BoletoNumber
        );

        // Relacionamento
        subscription.AddPayment(payment);
        studant.AddSubscription(subscription);

        // Aplicar as Validações
        AddNotifications(name, document, email, address, studant, subscription, payment);

        // Checar notificações
        if (Invalid)
            return new CommandResult(false, "Não foi possivel realizar sua assinatura.");

        // Salvar as informações
        _repository.CreateSubscription(studant);

        // Enviar email de boas vindas
        _emailService.Send(studant.Name.ToString(), studant.Email.Address, "Bem vindo ao site",
            "Sua assinatura foi criada");

        // Retorn informaçoes
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
    {
//        // Fail Fast Validatios
//        command.Validate();
//        if (command.Invalid)
//        {
//            AddNotifications(command);
//            return new CommandResult(false, "Não foi possivel realizar sua assinatura");
//        }

        // Verificar se doc esta cadastrado
        if (_repository.DocumentExists(command.Document))
            AddNotification("Document", "Este documento ja esta em uso.");

        // Verificar se email esta cadastrado
        if (_repository.EmailExists(command.Email))
            AddNotification("Email", "Este Email já esta sendo utilizado.");

        // Gerar os VOs
        var name = new Name(command.FirsName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
            command.Country, command.ZipCode);

        // Gerar as Entidades
        var studant = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new PayPalPayment(
            command.PaidDate,
            command.ExpiredDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email,
            command.TransactionCode
        );

        // Relacionamento
        subscription.AddPayment(payment);
        studant.AddSubscription(subscription);

        // Aplicar as Validações
        AddNotifications(name, document, email, address, studant, subscription, payment);

        // Salvar as informações
        _repository.CreateSubscription(studant);

        // Enviar email de boas vindas
        _emailService.Send(studant.Name.ToString(), studant.Email.Address, "Bem vindo ao site",
            "Sua assinatura foi criada");

        // Retorn informaçoes
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}