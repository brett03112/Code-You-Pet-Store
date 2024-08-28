using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store.App;

public class UILogic
{
    
    /// <summary>
    /// This function provides a UI for the user to interact with the pet store.
    /// The user can choose from a menu of options:
    /// 1. Add a dog leash product
    /// 2. View a dog leash product
    /// 3. View all products in stock
    /// 4. View the total price of the current inventory
    /// The function takes in an integer parameter 'choice' which represents the option the user has chosen.
    /// The function performs the corresponding action based on the user's choice.
    /// </summary>
    public static void UISwitchLogic(int choice)
    {
        switch (choice)
        {
            case 1:
                var options = NewOptions();
                var productLogic = new ProductLogic();

                var dogLeash = new DogLeash();

                Console.WriteLine("Creating a dog leash product");

                Console.Write("Enter the material the leash is made out of: ");
                dogLeash.Material = Console.ReadLine();

                Console.Write("Enter the length in inches: ");
                dogLeash.LengthInches = int.Parse(Console.ReadLine()!);

                Console.Write("Enter the name of the leash: ");
                dogLeash.Name = Console.ReadLine();

                Console.Write("Give the product a short description: ");
                dogLeash.Description = Console.ReadLine();

                Console.Write("Give the product a price: ");
                dogLeash.Price = decimal.Parse(Console.ReadLine()!);

                Console.Write("How many products do you have on hand? ");
                dogLeash.Quantity = int.Parse(Console.ReadLine()!);

                productLogic.AddProduct(dogLeash);
                Console.WriteLine("Added dog leash product\n");
                break;
            
            case 2:
                var options2 = NewOptions();
                var productLogic2 = new ProductLogic();
                Console.WriteLine("Enter the name of the dog leash to view?");
                var leashName = Console.ReadLine();
                var leash = productLogic2.GetDogLeashByName(leashName!);
                string jsonOutput = JsonSerializer.Serialize(value: leash, options2);
                Console.WriteLine($"{jsonOutput}\n");
                break;

            case 3:
                var options3 = NewOptions();
                var productLogic3 = new ProductLogic();
                
                var products = productLogic3.GetAllProducts();
                foreach (var product in products)
                {
                    string jsonOutput2 = JsonSerializer.Serialize(value: product, options3);
                    Console.WriteLine($"{jsonOutput2}\n");
                }
                break;

            case 4:
                var productLogic4 = new ProductLogic();
                Console.WriteLine($"The total price of inventory on hand is {productLogic4.GetTotalPriceOfInventory()}\n");
                break;

            default:
                Console.WriteLine("Invalid input\n");
                break;
                
        }
    }
    
    /// <summary>
    /// Creates a new instance of <see cref="JsonSerializerOptions"/> with options set for 
    /// serializing and deserializing JSON, including including all fields, 
    /// making property names case insensitive, writing JSON indented, and using camel case 
    /// property naming policy.
    /// </summary>
    public static JsonSerializerOptions NewOptions()
    {
        JsonSerializerOptions options = new()
        {
            IncludeFields = true, // Includes all fields.
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        return options;
    }
}