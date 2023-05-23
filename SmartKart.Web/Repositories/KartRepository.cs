using Microsoft.EntityFrameworkCore;
using SmartKart.Web.Data;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Repositories;

public class KartRepository : IKartRepository
{
    private readonly SmartKartContext _dbContext;

    public KartRepository(SmartKartContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task AddItem(string userName, int productId, int quantity = 1, string? color = "Black")
    {
        var kart = await GetKartByUserName(userName);

        kart.Items.Add(
            new KartItem
            {
                ProductId = productId,
                Color = color,
                Price = _dbContext.Products!.FirstOrDefault(p => p.Id == productId)!.Price,
                Quantity = quantity
            }
        );

        _dbContext.Entry(kart).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveItem(int cartId, int cartItemId)
    {
        var kart = _dbContext.Karts!
            .Include(c => c.Items)
            .FirstOrDefault(c => c.Id == cartId);

        if (kart != null)
        {
            var removedItem = kart.Items.FirstOrDefault(x => x!.Id == cartItemId);
            kart.Items.Remove(removedItem);

            _dbContext.Entry(kart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Kart> GetKartByUserName(string userName)
    {
        var cart = _dbContext.Karts!
            .Include(c => c.Items)
            .ThenInclude(i => i!.Product)
            .FirstOrDefault(c => c.UserName == userName);

        if (cart != null)
            return cart;

        // if it is first attempt create new
        var newCart = new Kart
        {
            UserName = userName
        };

        _dbContext.Karts!.Add(newCart);
        await _dbContext.SaveChangesAsync();
        return newCart;
    }

    public async Task ClearKart(string userName)
    {
        var cart = await GetKartByUserName(userName);

        cart.Items.Clear();

        _dbContext.Entry(cart).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}