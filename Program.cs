// Software-1-Class-Exercise\PetStore\Program.cs

using Store.App;




string userInput = "";
Console.WriteLine("Press 1 to add a Dog Leash product");
Console.WriteLine("Press 2 to view a Dog Leash product");
Console.WriteLine("Press 3 to view all products in stock");
Console.WriteLine("Press 4 to view the total price of the current inventory");
Console.WriteLine("Type 'exit' to quit\n");

userInput = Console.ReadLine()!.ToLower();
    

while (userInput.ToLower() != "exit")
{
    
    UILogic.UISwitchLogic(int.Parse(userInput));
    
    Console.WriteLine();
    Console.WriteLine("Press 1 to add a Dog Leash product");
    Console.WriteLine("Press 2 to view a Dog Leash product");
    Console.WriteLine("Press 3 to view all products in stock");
    Console.WriteLine("Press 4 to view the total price of the current inventory");
    Console.WriteLine("Type 'exit' to quit\n");
    userInput = Console.ReadLine()!;
}