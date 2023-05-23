using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Tests.Repositories;

internal class KartRepositoryFake : IKartRepository
{
    public Task<Kart> GetKartByUserName(string userName)
    {
        throw new NotImplementedException();
    }

    public Task AddItem(string userName, int productId, int quantity = 1, string? color = "Black")
    {
        throw new NotImplementedException();
    }

    public Task RemoveItem(int kartId, int kartItemId)
    {
        throw new NotImplementedException();
    }

    public Task ClearKart(string userName)
    {
        throw new NotImplementedException();
    }
}