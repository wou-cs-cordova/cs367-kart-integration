using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Pages;

public class ProductModel : PageModel
{
    private readonly IKartRepository _kartRepository;
    private readonly IProductRepository _productRepository;

    public ProductModel(IProductRepository productRepository, IKartRepository kartRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _kartRepository = kartRepository ?? throw new ArgumentNullException(nameof(kartRepository));
    }

    public IEnumerable<Category> CategoryList { get; set; } = new List<Category>();
    public IEnumerable<Product> ProductList { get; set; } = new List<Product>();


    [BindProperty(SupportsGet = true)] public string? SelectedCategory { get; set; }

    public async Task<IActionResult> OnGetAsync(int? categoryId)
    {
        CategoryList = await _productRepository.GetCategories();

        if (categoryId.HasValue)
        {
            ProductList = await _productRepository.GetProductByCategory(categoryId.Value);
            SelectedCategory = CategoryList.FirstOrDefault(c => c.Id == categoryId.Value)?.Name;
        }
        else
        {
            ProductList = await _productRepository.GetProducts();
        }

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