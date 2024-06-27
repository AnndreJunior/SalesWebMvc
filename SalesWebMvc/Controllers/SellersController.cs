using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;
    private readonly DepartmentService _departmentService;

    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
        _sellerService = sellerService;
        _departmentService = departmentService;
    }

    public IActionResult Index()
    {
        var sellerList = _sellerService.FindAll();
        return View(sellerList);
    }

    #region Create

    public IActionResult Create()
    {
        var departments = _departmentService.FindAll();
        var viewModel = new SellerFormViewModel
        {
            Departments = departments,
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    public IActionResult Delete(int? id)
    {
        if (id is null)
            return NotFound();

        var seller = _sellerService.FindById(id.Value);

        if (seller is null)
            return NotFound();

        return View(seller);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _sellerService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
