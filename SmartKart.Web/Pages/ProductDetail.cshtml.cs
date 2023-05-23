using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Pages;

public class ProductDetailModel : PageModel
{
    private readonly IKartRepository _kartRepository;
    private readonly IProductRepository _productRepository;

    public ProductDetailModel(IProductRepository productRepository, IKartRepository cartRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _kartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
    }

    public Product? Product { get; set; }

    [BindProperty] public string? Color { get; set; }

    [BindProperty] public int Quantity { get; set; }

    public async Task<IActionResult> OnGetAsync(int? productId)
    {
        if (productId == null) return NotFound();

        Product = await _productRepository.GetProductById(productId.Value);
        if (Product == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAddToKartAsync(int productId)
    {
        //if (!User.Identity.IsAuthenticated)
        //    return RedirectToPage("./Account/Login", new { area = "Identity" });

        await _kartRepository.AddItem("test", productId, Quantity, Color);
        return RedirectToPage("Kart");
    }
}