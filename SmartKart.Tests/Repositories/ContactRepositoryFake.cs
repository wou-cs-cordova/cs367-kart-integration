using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Tests.Repositories;

internal class ContactRepositoryFake : IContactRepository
{
    public Task<Contact> SendMessage(Contact contact)
    {
        throw new NotImplementedException();
    }

    public Task<Contact> Subscribe(string address)
    {
        throw new NotImplementedException();
    }
}