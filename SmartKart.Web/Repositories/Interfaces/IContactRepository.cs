using SmartKart.Web.Models;

namespace SmartKart.Web.Repositories.Interfaces;

public interface IContactRepository
{
    Task<Contact> SendMessage(Contact contact);
    Task<Contact> Subscribe(string address);
}