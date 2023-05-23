using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Pages;

public class CheckOutModel : PageModel
{
    private readonly IKartRepository _kartRepository;
    private readonly IOrderRepository _orderRepository;

    public CheckOutModel(IKartRepository kartRepository, IOrderRepository orderRepository)
    {
        _kartRepository = kartRepository ?? throw new ArgumentNullException(nameof(kartRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    [BindProperty] public Order? Order { get; set; }

    public Kart Kart { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        Kart = await _kartRepository.GetKartByUserName("test");
        return Page();
    }

    public async Task<IActionResult> OnPostCheckOutAsync()
    {
        Kart = await _kartRepository.GetKartByUserName("test");

        if (!ModelState.IsValid) return Page();

        Order!.UserName = "test";
        Order.TotalPrice = Kart.TotalPrice;

        await _orderRepository.CheckOut(Order);
        await _kartRepository.ClearKart("test");

        return RedirectToPage("Confirmation", "OrderSubmitted");
    }
}