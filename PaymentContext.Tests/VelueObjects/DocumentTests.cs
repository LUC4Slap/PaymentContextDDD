using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var document = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(document.Invalid);
    }


    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var document = new Document("17824756000158", EDocumentType.CNPJ);
        Assert.IsTrue(document.Valid);
    }


    [TestMethod]
    public void ShouldReturnErrorWhenCPFsInvalid()
    {
        var document = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(document.Invalid);
    }


    [TestMethod]
    [DataTestMethod]
    [DataRow("43253800008")]
    [DataRow("18643115096")]
    [DataRow("07830817073")]
    public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
    {
        var document = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(document.Valid);
    }
}