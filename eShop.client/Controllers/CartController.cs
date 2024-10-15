using eShop.models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.client.Controllers;

public class CartController : Controller
{
    private readonly List<CartItem> _cartItems = [];

    public IActionResult Index()
    {
        return View(_cartItems);
    }

    public void AddProduct(Product product)
    {
        CartItem? cartItem = _cartItems.FirstOrDefault(cartItem => cartItem.Product == product);

        if (cartItem is not null)
        {
            cartItem.Quantity += 1;
        }
        else
        {
            _cartItems.Add(
                new CartItem()
                {
                    Product = product,
                    Quantity = 1
                }
            );
        }
    }
}
