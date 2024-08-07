// Software-1-Class-Exercise\PetStore\Program.cs
using System.Text.Json;
using System.Text.Json.Serialization;
using Store.App;

string userInput = "";
JsonSerializerOptions options = new()
{
    IncludeFields = true, // Includes all fields.
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

while (userInput.ToLower() != "exit")
{
    Console.WriteLine("Press 1 to add a product");

    Console.WriteLine("Type 'exit' to quit");

    userInput = Console.ReadLine()!;
    if (userInput.ToLower() != "exit" && userInput != "1")
    {
        Console.WriteLine("Invalid input. Please try again.");
        continue;
    }

    if (userInput == "1")
    {
        Console.WriteLine("Enter the type of product you want to add: 'CatFood' or 'DogLeash'");
        userInput = Console.ReadLine()!;

        if (userInput.ToLower() == "catfood")
        {
            Console.WriteLine("What is the name of the product?");
            string name = Console.ReadLine()!;
            Console.WriteLine("Is the product kitten food? (true or false)");
            userInput = Console.ReadLine()!;
            if (userInput.ToLower() != "true" && userInput.ToLower() != "false")
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }
            bool kittenFood = bool.Parse(userInput.ToLower());

            if (kittenFood == true)
            {
                double weight = 25.0;
                decimal price = 10.99M;
                int quantity = 1;
                string description = "Kitten food";
                CatFood catFood = new CatFood(weight, kittenFood, name, price, quantity, description);
                Console.WriteLine(JsonSerializer.Serialize( value: catFood, options));
                Console.WriteLine("");
                Console.WriteLine(catFood.ToString()!);
                
            }
            
            else // adult food
            {
                double weight = 25.0;
                decimal price = 15.99m;
                int quantity = 1;
                string description = "Adult food";
                CatFood catFood = new CatFood(weight, kittenFood, name, price, quantity, description);
                Console.WriteLine(JsonSerializer.Serialize(value: catFood, options));
                Console.WriteLine("");
                Console.WriteLine(catFood.ToString()!);
               
            }
        }
        else if (userInput.ToLower() == "dogleash")
        {
            Console.WriteLine("Enter the length of the product in inches");
            userInput = Console.ReadLine()!;
            int length ;
            if (int.TryParse(userInput, out length)) // attempt to parse userInput => length : int
            {
                Console.WriteLine("Enter the material of the product");
                string material = Console.ReadLine()!;
                Console.WriteLine("What is the name of the product?");
                string name = Console.ReadLine()!;
                decimal price = 19.99m;
                int quantity = 1;
                string description = "Dog Leash";
                DogLeash dogLeash = new DogLeash(length, material, name, price, quantity, description);
                string jsonOutput = JsonSerializer.Serialize(value: dogLeash, options);
                Console.WriteLine(jsonOutput);
                Console.WriteLine("");
                Console.WriteLine(dogLeash.ToString()!);
                
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Invalid product type");
            continue;
        }
    }
}