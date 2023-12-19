using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQueriesTests
{
    private IList<Student> _students;

    public StudentQueriesTests()
    {
        for (var i = 0; i <= 10; i++)
        {
            _students.Add(
                new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("99999999999", EDocumentType.CPF),
                    new Email($"{i.ToString()}@teste.com")
                )
            );
        }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
        Assert.AreEqual(null, studn);
    }

    [TestMethod]
    public void ShouldReturnWhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("999999999999");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
        Assert.AreNotEqual(null, studn);
    }
}