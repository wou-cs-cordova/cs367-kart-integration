﻿using SmartKart.Web.Models;

namespace SmartKart.Web.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order> CheckOut(Order order);
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}