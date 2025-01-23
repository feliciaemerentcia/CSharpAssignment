
using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    void SaveListToFile(List<Contact> List);

    List<Contact> LoadListFromFile();
}
