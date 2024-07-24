using System.Text.Json;


namespace Store.App;

public class Product
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; } 

    /// <summary>
    /// constructor for product (base class)
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    /// <param name="description"></param> <summary>
     
    public Product(string name, decimal price, int quantity, string description)
    {
        Name = name ;
        Price = price;
        Quantity = quantity;
        Description = description;
    }

    /// <summary>
    /// Override ToString to print Product properties (base class)
    /// </summary>
    /// <returns>A string of properties of the Product object</returns>
    public override string ToString()
    {
        return $"Name: {this.Name}, Price: {this.Price}, Quantity: {this.Quantity}, Description: {this.Description}";
    }

    /// <summary>
    /// A method to convert Product to Json
    /// </summary>
    /// <returns>JSON representation of Product</returns>
    public string ConvertToJson()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            IncludeFields = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Serialize(this.ToString());
    }
}