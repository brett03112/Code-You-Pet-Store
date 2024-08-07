using System.Text.Json;
namespace Store.App;

public class DogLeash : Product
{
    public int LengthInches { get; set; } = 12;
    public string? Material { get; set; } = "Leather";

    /// <summary>
    /// Constructor for DogLeash that inherits from Product
    /// </summary>
    /// <param name="lengthInches"></param>
    /// <param name="material"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public DogLeash(int lengthInches, string material, string name, decimal price, 
        int quantity, string description) : 
        base(name, price, quantity, description)
    {
        LengthInches = lengthInches;
        Material = material;
    }

    /// <summary>
    /// Override ToString method for DogLeash
    /// </summary>
    /// <returns>A string representation of the DogLeash object</returns>
    public override string ToString()
    {
        return $"Name: {this.Name}, Price: ${this.Price}, Quantity: {this.Quantity}, Description: {this.Description}, LengthInches: {this.LengthInches}, Material: {this.Material}";
    }
    /// <summary>
    /// A method to convert DogLeash to Json
    /// </summary>
    /// <returns>JSON representation of DogLeash</returns>
    public new string ConvertToJson()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            IncludeFields = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Serialize(base.ConvertToJson() + this.ToString());
    }
}