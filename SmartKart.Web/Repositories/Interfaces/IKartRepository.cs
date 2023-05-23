using SmartKart.Web.Models;

namespace SmartKart.Web.Repositories.Interfaces;

public interface IKartRepository
{
    Task<Kart> GetKartByUserName(string userName);
    Task AddItem(string userName, int productId, int quantity = 1, string? color = "Black");
    Task RemoveItem(int kartId, int kartItemId);
    Task ClearKart(string userName);
}