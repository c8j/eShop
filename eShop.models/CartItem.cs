namespace eShop.models;

public class CartItem
{
    public required Product Product { get; init; }
    public int Quantity { get; set; }
    public decimal TotalPrice
    {
        get
        {
            return Product.Price * Quantity;
        }
    }
}
