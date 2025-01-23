using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Moq;

namespace Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _contactService = _contactServiceMock.Object;
    }

    [Fact]
     public void Create_ShouldReturnTrue_WhenProductIsCreated()
    {
        var contactRegistrationForm = new ContactRegistrationForm { FirstName = "", LastName = "", Email = "", PhoneNumber = "", Street = "", PostalCode = "", City = "" };
        _contactServiceMock
            .Setup(cs => cs.Create(contactRegistrationForm))
            .Returns(true);

        var result = _contactService.Create(contactRegistrationForm);

        Assert.True(result);

    }


    [Fact]
    public void GetAll_ShouldReturnListOfContacts()
    {
        var contacts = new List<Contact>()
        {
            new() {Id = "1", FirstName = "Test", LastName = "Test", Email = "Test", PhoneNumber = "Test", Street = "Test", PostalCode = "Test", City = "Test"},
            new() {Id = "2", FirstName = "Example", LastName = "Example", Email = "Example", PhoneNumber = "Example", Street = "Example", PostalCode = "Example", City = "Example"}
        };
        _contactServiceMock.Setup(cs => cs.GetAll()).Returns(contacts);
        var result = _contactService.GetAll();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}
