// Software-1-Class-Exercise\PetStore\Program.cs
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Store.App;
using Store.App.Validators;



string userInput = "";
// Display the main menu
UILogic.DisplayMenu();

userInput = Console.ReadLine()!.ToLower();
    

while (userInput.ToLower() != "exit")
{
    // Perform the corresponding action based on the user's choice
    UILogic.UISwitchLogic(int.Parse(userInput));

    // Display the main menu
    UILogic.DisplayMenu();
    userInput = Console.ReadLine()!;
}

