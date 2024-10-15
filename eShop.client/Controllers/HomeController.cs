using Microsoft.AspNetCore.Mvc;

namespace eShop.client.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
