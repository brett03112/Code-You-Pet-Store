using System.Text.Json;
namespace Store.App;

public class CatFood : Product
{
    public double WeightPounds { get; set; } = 25.0;
    public bool KittenFood { get; set; } = false;


    public CatFood(double weightPounds, bool kittenFood,
        string name, decimal price, int quantity, string description) : 
        base(name, price, quantity, description)
    {
        WeightPounds = weightPounds;
        KittenFood = kittenFood;
    }
    public override string ToString()
    {
        return $"{base.ToString()}, WeightPounds: {this.WeightPounds}, KittenFood: {this.KittenFood}";
    }
}