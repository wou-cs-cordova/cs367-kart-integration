using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IKartRepository _kartRepository;
    private readonly IProductRepository _productRepository;

    public IndexModel(IProductRepository productRepository, IKartRepository kartRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _kartRepository = kartRepository ?? throw new ArgumentNullException(nameof(kartRepository));
    }

    public IEnumerable<Product> ProductList { get; set; } = new List<Product>();

    public async Task<IActionResult> OnGetAsync()
    {
        ProductList = await _productRepository.GetProducts();
        return Page();
    }

    public async Task<IActionResult> OnPostAddToKartAsync(int productId)
    {
        //if (!User.Identity.IsAuthenticated)
        //    return RedirectToPage("./Account/Login", new { area = "Identity" });

        await _kartRepository.AddItem("test", productId);
        return RedirectToPage("Kart");
    }
}