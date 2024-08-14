// Software-1-Class-Exercise\PetStore\Program.cs
using System.Text.Json;
using Store.App;

JsonSerializerOptions options = new()
{
    IncludeFields = true, // Includes all fields.
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};
var productLogic = new ProductLogic();

string userInput = "";
Console.WriteLine("Press 1 to add a Dog Leash product");
Console.WriteLine("Press 2 to view a Dog Leash product");
Console.WriteLine("Type 'exit' to quit");

userInput = Console.ReadLine()!.ToLower();
    

while (userInput.ToLower() != "exit")
{
    
    int input = int.Parse(userInput);

    switch (input)
    {
        case 1:
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
            Console.WriteLine("Added dog leash product");
            break;
        
        case 2:
            Console.WriteLine("Enter the name of the dog leash to view?");
            var leashName = Console.ReadLine();
            var leash = productLogic.GetDogLeashByName(leashName!);
            string jsonOutput = JsonSerializer.Serialize(value: leash, options);
            Console.WriteLine($"{jsonOutput}\n");
            break;

        default:
            Console.WriteLine("Invalid input");
             
            continue;
               
    }

    Console.WriteLine("Press 1 to add a Dog Leash product");
    Console.WriteLine("Press 2 to view a Dog Leash product");
    Console.WriteLine("Type 'exit' to quit");
    userInput = Console.ReadLine()!;
}