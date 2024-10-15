namespace eShop.models;

public class Product
{
    public int ID { get; init; }
    public required string Name { get; init; }
    public decimal Price { get; init; }
}
