using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
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

    #region Create

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
