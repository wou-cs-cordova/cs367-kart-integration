using Microsoft.EntityFrameworkCore;
using SmartKart.Web.Data;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly SmartKartContext _dbContext;

    public OrderRepository(SmartKartContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Order> CheckOut(Order order)
    {
        _dbContext.Orders?.Add(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        var orderList = await _dbContext.Orders!
            .Where(o => o.UserName == userName)
            .ToListAsync();

        return orderList;
    }
}