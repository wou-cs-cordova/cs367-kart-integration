using SmartKart.Web.Data;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly SmartKartContext _dbContext;

    public ContactRepository(SmartKartContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Contact> SendMessage(Contact contact)
    {
        _dbContext.Contacts?.Add(contact);
        await _dbContext.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> Subscribe(string address)
    {
        // implement your business logic
        var newContact = new Contact
        {
            Email = address,
            Message = address,
            Name = address
        };

        _dbContext.Contacts?.Add(newContact);
        await _dbContext.SaveChangesAsync();

        return newContact;
    }
}