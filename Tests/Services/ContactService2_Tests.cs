using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using System.IO;
using System.Text.Json;

namespace Tests.Services;

public class ContactService2_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;

    public ContactService2_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactService = new ContactService(_fileServiceMock.Object);
    }

    [Fact]
    public void Create_ShouldAddContactToList_AndSaveToFile()
    {

        //arrange
        ContactRegistrationForm contactRegistrationForm = new()
        { FirstName = "Test", LastName = "Test", Email = "Test", PhoneNumber = "Test", Street = "Test", PostalCode = "Test", City = "Test" };

        _fileServiceMock.Setup(x => x.SaveListToFile(It.IsAny<List<Contact>>()))
            .Callback<List<Contact>>(list => 
            {
                Assert.NotNull(list);
                Assert.Single(list);
            });

        //act
        var result = _contactService.Create(contactRegistrationForm);

        //assert
        Assert.True(result);
        _fileServiceMock.Verify(x => x.SaveListToFile(It.IsAny<List<Contact>>()), Times.Once);
    }
}
