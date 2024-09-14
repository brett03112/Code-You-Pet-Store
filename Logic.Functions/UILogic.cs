using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Store.App.Validators;
using FluentValidation;

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
        // Create the service collection and add the product logic services to the service collection 
        var services = UILogic.CreateServiceCollection();
        
        switch (choice)
        {
            case 1:                
                var productLogic = services.GetService<IProductLogic>();
                Console.WriteLine("Please add a dog leash product: ");
                Console.WriteLine("Here is an example:");
                Console.WriteLine("{Price: 58.89, Name: Special dog leash, " +
                    "Quantity: 10, Description: Magical leash that will help your dog not pull hard when going on walks, " +
                    "Material: Classified, LengthInches: 12}\n");
                var leash = new DogLeash();
                var options = NewOptions();
                Console.WriteLine("Enter the price of the dog leash?");
                leash.Price = decimal.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter the name of the dog leash?");
                leash.Name = Console.ReadLine();
                Console.WriteLine("Enter the quantity of the dog leash?");
                leash.Quantity = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter the description of the dog leash?");
                leash.Description = Console.ReadLine();
                Console.WriteLine("Enter the material of the dog leash?");
                leash.Material = Console.ReadLine();
                Console.WriteLine("Enter the length of the dog leash in inches?");
                leash.LengthInches = int.Parse(Console.ReadLine()!);
                
                JsonSerializer.Serialize(value: leash, options: options);
                

                // Validate the leash
                
                var validator = new DogLeashValidator();
                var validationResult = validator.Validate(leash!);
                
                if (validationResult.IsValid)
                {
                    productLogic!.AddProduct(leash!);
                    Console.WriteLine("Dog leash added successfully.");
                }
                else
                {
                    Console.WriteLine("Validation failed. Please check the following errors:");
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine($"- {error.ErrorMessage}");
                    }
                }
                break;
            
            case 2:
                var options2 = NewOptions();
                var productLogic2 = new ProductLogic();
                Console.WriteLine("Enter the name of the dog leash to view?");
                var leashName = Console.ReadLine();
                var leash2 = productLogic2.GetProductByName<DogLeash>(leashName!);
                string jsonOutput = JsonSerializer.Serialize(value: leash2, options2);
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

    /// <summary>
    /// Displays the main menu of the program, which allows the user to perform one of the following actions:
    /// 1. Add a Dog Leash product
    /// 2. View a Dog Leash product
    /// 3. View all products in stock
    /// 4. View the total price of the current inventory
    /// 5. Quit the program by typing 'exit'
    /// </summary>
    public static void DisplayMenu()
    {
        Console.WriteLine("Press 1 to add a Dog Leash product");
        Console.WriteLine("Press 2 to view a Dog Leash product");
        Console.WriteLine("Press 3 to view all products in stock");
        Console.WriteLine("Press 4 to view the total price of the current inventory");
        Console.WriteLine("Type 'exit' to quit\n"); 
    }

    /// <summary>
    /// Creates and returns a service provider with the product logic services configured.
    /// </summary>
    /// <returns>
    /// An instance of IServiceProvider that provides access to the product logic services.
    /// </returns>
    public static IServiceProvider CreateServiceCollection()
    {
        // Creates a new service collection and adds the product logic services
        return new ServiceCollection()
            // Adds the IProductLogic interface with a transient lifetime, implemented by the ProductLogic class
            .AddTransient<IProductLogic, ProductLogic>()
            // Builds the service provider from the service collection
            .BuildServiceProvider();
    }
}
