using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

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
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });

        var seller = _sellerService.FindById(id.Value);

        if (seller is null)
            return RedirectToAction(nameof(Error), new { message = "Vendendor não encontrado" });

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

    #region Details

    public IActionResult Details(int? id)
    {
        if (id is null)
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });

        var seller = _sellerService.FindById(id.Value);

        if (seller is null)
            return RedirectToAction(nameof(Error), new { message = "Vendendor não encontrado" });

        return View(seller);
    }

    #endregion

    #region Edit

    public IActionResult Edit(int? id)
    {
        if (id is null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });
        }

        var obj = _sellerService.FindById(id.Value);
        if (obj is null)
        {
            return RedirectToAction(nameof(Error), new { message = "Vendendor não encontrado" });
        }

        List<Department> departments = _departmentService.FindAll();
        SellerFormViewModel viewModel = new()
        {
            Seller = obj,
            Departments = departments
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Seller seller)
    {
        if (id != seller.Id)
        {
            return RedirectToAction(nameof(Error), new { message = "Ids não batem" });
        }

        try
        {
            _sellerService.Update(seller);
            return RedirectToAction(nameof(Index));
        }
        catch (ApplicationException ex)
        {
            return RedirectToAction(nameof(Error), new { message = ex.Message });
        }
    }

    #endregion

    public IActionResult Error(string message)
    {
        var viewModel = new ErrorViewModel
        {
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        return View(viewModel);
    }
}
