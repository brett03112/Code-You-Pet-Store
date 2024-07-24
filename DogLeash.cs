using System.Text.Json;
namespace Store.App;

public class DogLeash : Product
{
    public static int LengthInches { get; set; } = 6;
    public static string? Material { get; set; } = "Leather";


    public DogLeash(int lengthInches, string material, string name, decimal price, 
        int quantity, string description) : 
        base(name, price, quantity, description)
    {
        LengthInches = lengthInches;
        Material = material;
    }

    public override string ToString()
    {
        return $"{base.ToString()},LengthInches: {LengthInches}, Material: {Material}";
    }
}