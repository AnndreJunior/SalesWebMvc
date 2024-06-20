using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers;

[Route("[controller]")]
public class DepartmentsController : Controller
{
    public IActionResult Index()
    {
        var departments = new List<Department>
        {
            new() { Id = 1, Name = "Eletronics" },
            new() { Id = 2, Name = "Fashion" }
        };

        return View(departments);
    }

    [HttpGet("Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
