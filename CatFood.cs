using System.Text.Json;
namespace Store.App;

public class CatFood : Product
{
    public double WeightPounds { get; set; } = 25.0;
    public bool KittenFood { get; set; } = false;

    /// <summary>
    /// Constructor for CatFood that inherits from Product
    /// </summary>
    /// <param name="weightPounds"></param>
    /// <param name="kittenFood"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public CatFood(double weightPounds, bool kittenFood,
        string name, decimal price, int quantity, string description) : 
        base(name, price, quantity, description)
    {
        WeightPounds = weightPounds;
        KittenFood = kittenFood;
    }

    /// <summary>
    /// Override ToString to print CatFood properties
    /// </summary>
    /// <returns>A string of properties of the CatFood object</returns>
    public override string ToString()
    {
        return $"Name: {this.Name}, Price: ${this.Price}, Quantity: {this.Quantity}, Description: {this.Description}, WeightPounds: {this.WeightPounds}, KittenFood: {this.KittenFood}";
    }

    /// <summary>
    /// A method to convert CatFood to a JSON string
    /// </summary>
    /// <returns>JSON representation of CatFood</returns>
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