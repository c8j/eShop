using eShop.models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.client.Controllers;

public class CartController(IWebHostEnvironment webHostEnvironment) : Controller
{
    private readonly string _wwwroot = webHostEnvironment.WebRootPath;
    private readonly List<Product> _products = Storage.ReadJson<Product>(webHostEnvironment.WebRootPath + "/Data/products.json");
    private readonly List<CartItem> _cartItems = Storage.ReadJson<CartItem>(webHostEnvironment.WebRootPath + "/Data/cart.json");

    public IActionResult Index()
    {
        return View(_cartItems);
    }

    public IActionResult AddProduct(int productID)
    {
        CartItem? cartItem = _cartItems.FirstOrDefault(cartItem => cartItem.Product.ID == productID);

        if (cartItem is not null)
        {
            cartItem.Quantity += 1;
        }
        else
        {
            Product? product = _products.FirstOrDefault(product => product.ID == productID);

            if (product is not null)
            {
                _cartItems.Add
                (
                    new CartItem()
                    {
                        Product = product,
                        Quantity = 1
                    }
                );
            }
        }
        Storage.WriteJson(_wwwroot + "/Data/cart.json", _cartItems);
        return RedirectToAction("Index");
    }

}
