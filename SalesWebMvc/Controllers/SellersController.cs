using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers;

[Route("[controller]")]
public class SellersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
