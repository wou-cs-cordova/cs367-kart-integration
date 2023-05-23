﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Pages;

public class OrderModel : PageModel
{
    private readonly IOrderRepository _orderRepository;

    public OrderModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public IEnumerable<Order> Orders { get; set; } = new List<Order>();

    public async Task<IActionResult> OnGetAsync()
    {
        Orders = await _orderRepository.GetOrdersByUserName("test");

        return Page();
    }
}