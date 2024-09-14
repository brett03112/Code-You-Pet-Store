using System.Text.Json;


namespace Store.App;


public class Product
{
    protected static readonly List<Product>? _products;
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; } 
    
}