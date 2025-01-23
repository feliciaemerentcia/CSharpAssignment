using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Text.Json;

namespace Business.Services;

public class ContactService: IContactService

{
    private List<Contact> _contacts = [];
    private readonly IFileService _fileService;
    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public bool Create(ContactRegistrationForm form)
    {

        try
        {
            Contact contact = ContactFactory.Create(form);
            _contacts.Add(contact);
            _fileService.SaveListToFile(_contacts);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }

    }

    public IEnumerable<Contact> GetAll()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }
}