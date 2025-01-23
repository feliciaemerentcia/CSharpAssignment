using Business.Dtos;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public static class ContactFactory
{
    public static ContactRegistrationForm Create() => new();

    public static Contact Create(ContactRegistrationForm form) => new()
    {
        Id = IdGenerator.Generate(),
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber,
        Street = form.Street,
        PostalCode = form.PostalCode,
        City = form.City,
    };

}
