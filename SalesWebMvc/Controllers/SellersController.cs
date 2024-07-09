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

    public async Task<IActionResult> Index()
    {
        var sellerList = await _sellerService.FindAll();
        sellerList.ForEach(seller => seller.BirthDate = seller.BirthDate.ToLocalTime());
        return View(sellerList);
    }

    #region Create

    public async Task<IActionResult> Create()
    {
        var departments = await _departmentService.FindAll();
        var viewModel = new SellerFormViewModel
        {
            Departments = departments,
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Seller seller)
    {
        // if (!ModelState.IsValid)
        // {
        //     var departments = await _departmentService.FindAll();
        //     var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
        //     return View(viewModel);
        // }

        await _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });

        var seller = await _sellerService.FindById(id.Value);

        if (seller is null)
            return RedirectToAction(nameof(Error), new { message = "Vendendor não encontrado" });

        return View(seller);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        catch (IntegrityException ex)
        {
            return RedirectToAction(nameof(Error), new { message = ex.Message });
        }
    }

    #endregion

    #region Details

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });

        var seller = await _sellerService.FindById(id.Value);

        if (seller is null)
            return RedirectToAction(nameof(Error), new { message = "Vendendor não encontrado" });

        seller.BirthDate = seller.BirthDate.ToLocalTime();
        return View(seller);
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });
        }

        var obj = await _sellerService.FindById(id.Value);
        if (obj is null)
        {
            return RedirectToAction(nameof(Error), new { message = "Vendendor não encontrado" });
        }

        List<Department> departments = await _departmentService.FindAll();
        SellerFormViewModel viewModel = new()
        {
            Seller = obj,
            Departments = departments
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Seller seller)
    {
        if (!ModelState.IsValid)
        {
            var departments = await _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }

        if (id != seller.Id)
        {
            return RedirectToAction(nameof(Error), new { message = "Ids não batem" });
        }

        try
        {
            await _sellerService.Update(seller);
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
