using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Tests.Repositories;

internal class OrderRepositoryFake : IOrderRepository
{
    public Task<Order> CheckOut(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        throw new NotImplementedException();
    }
}