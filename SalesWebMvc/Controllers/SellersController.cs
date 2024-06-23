using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

[Route("[controller]")]
public class SellersController : Controller
{
    private readonly SellerService _sellerService;

    public SellersController(SellerService sellerService)
    {
        _sellerService = sellerService;
    }

    public IActionResult Index()
    {
        var sellerList = _sellerService.FindAll();
        return View(sellerList);
    }
}
