using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Tests.Factories;

public class ContactFactory_Tests
{

    [Fact]

    public void Create_ShouldReturnContactRegistrationForm()
    {
        ContactRegistrationForm result = ContactFactory.Create();
        Assert.IsType<ContactRegistrationForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnContact_WhenProductRegistrationFormIsSupplied()
    {
        ContactRegistrationForm contactRegistrationForm = new()
        { FirstName = "Test", LastName = "Test", Email = "Test", PhoneNumber = "Test", Street = "Test", PostalCode = "Test", City = "Test" };
        
        Contact result = ContactFactory.Create(contactRegistrationForm);
        
        Assert.IsType<Contact>(result);
        Assert.Equal(contactRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(contactRegistrationForm.LastName, result.LastName);
        Assert.Equal(contactRegistrationForm.Email, result.Email);
        Assert.Equal(contactRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contactRegistrationForm.Street, result.Street);
        Assert.Equal(contactRegistrationForm.PostalCode, result.PostalCode);
        Assert.Equal(contactRegistrationForm.City, result.City);
    }
}
