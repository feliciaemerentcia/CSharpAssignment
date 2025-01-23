using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.Security.Authentication.ExtendedProtection;

namespace Business.Services;

public class MenuDialogs(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void Run()
    {
        while (true)
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("MAIN MENU");
        Console.WriteLine($"{"1. ",-5} Create a contact");
        Console.WriteLine($"{"2. ",-5} View contacts");
        Console.Write("Please select one of the options above: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                CreateOption();
                break;

            case "2":
                ViewOption();
                break;

            default:
                InvalidOption();
                break;
        }

        Console.ReadKey();
    }

    private void CreateOption()
    {
        ContactRegistrationForm contactRegistrationForm = ContactFactory.Create();

        Console.Clear();

        Console.WriteLine("Please enter your first name: ");
        contactRegistrationForm.FirstName = Console.ReadLine()!;

        Console.WriteLine("Please enter your last name: ");
        contactRegistrationForm.LastName = Console.ReadLine()!;

        Console.WriteLine("Please enter your emailadress: ");
        contactRegistrationForm.Email = Console.ReadLine()!;

        Console.WriteLine("Please enter your phonenumber: ");
        contactRegistrationForm.PhoneNumber = Console.ReadLine()!;

        Console.WriteLine("Please enter your streetname: ");
        contactRegistrationForm.Street = Console.ReadLine()!;

        Console.WriteLine("Please enter your postalcode: ");
        contactRegistrationForm.PostalCode = Console.ReadLine()!;

        Console.WriteLine("Please enter the name of your city: ");
        contactRegistrationForm.City = Console.ReadLine()!;

        bool result = _contactService.Create(contactRegistrationForm);

        if (result)
            OutputDialog("Contact was successfully created.");
        else
            OutputDialog("Contact was not created successfully");
    }

    private void ViewOption()
    {
        Console.Clear();
        Console.WriteLine("ALL CONTACTS");

        var contacts = _contactService.GetAll();
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id: ",-5}{contact.Id}");
            Console.WriteLine($"{"Firstname: ",-5}{contact.FirstName}");
            Console.WriteLine($"{"LastName: ",-5}{contact.LastName}");
            Console.WriteLine($"{"Email: ",-5}{contact.Email}");
            Console.WriteLine($"{"Phonenumber: ",-5}{contact.PhoneNumber}");
            Console.WriteLine($"{"Street: ",-5}{contact.Street}");
            Console.WriteLine($"{"Postalcode: ",-5}{contact.PostalCode}");
            Console.WriteLine($"{"City:  ",-5}{contact.City}");
            Console.WriteLine(" ");
        }
    }

    private void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("Please enter a valid option.");
    }

    private void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);

    }
}
