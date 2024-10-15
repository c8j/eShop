using eShop.models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.client.Controllers;

public class ProductsController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly List<Product> _products;

    public ProductsController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        string path = webHostEnvironment.WebRootPath + "/Data/products.json";
        _products = Storage.ReadJson<Product>(path);
    }

    public IActionResult Index()
    {
        return View(_products);
    }
}
