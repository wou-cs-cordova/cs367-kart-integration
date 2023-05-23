using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Web.Pages;

public class KartModel : PageModel
{
    private readonly IKartRepository _kartRepository;

    public KartModel(IKartRepository kartRepository)
    {
        _kartRepository = kartRepository ?? throw new ArgumentNullException(nameof(kartRepository));
    }

    public Kart Kart { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        Kart = await _kartRepository.GetKartByUserName("test");

        return Page();
    }

    public async Task<IActionResult> OnPostRemoveToKartAsync(int kartId, int kartItemId)
    {
        await _kartRepository.RemoveItem(kartId, kartItemId);
        return RedirectToPage();
    }
}