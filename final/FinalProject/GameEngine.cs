using System;

class GameEngine
{
    private readonly Protagonist player;
    private readonly World world;

    public GameEngine()
    {
        world = new World();
        player = new Protagonist("Player", 100, 10, 5, World.StartingLocation);
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to the Text-Based Game!");
        Console.WriteLine("Let's begin...");

        // Game loop
        while (true)
        {
            DisplayLocation();
            DisplayOptions();

            string input = Console.ReadLine().Trim().ToLower();
            ProcessInput(input);

            // Check for game over conditions or other exit conditions
            if (GameOver())
            {
                Console.WriteLine("Game Over!");
                break;
            }
        }
    }

    private void DisplayLocation()
    {
        Console.WriteLine($"Current Location: {player.CurrentLocation.Name}");
        Console.WriteLine(player.CurrentLocation.Description);
    }

    private void DisplayOptions()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Move to another location");
        Console.WriteLine("2. Interact with NPCs");
        Console.WriteLine("3. Check inventory");
        Console.WriteLine("4. Quit game");
        Console.Write("Enter your choice: ");
    }

    private void ProcessInput(string input)
    {
        switch (input)
        {
            case "1":
                MoveToLocation();
                break;
            case "2":
                InteractWithNPCs();
                break;
            case "3":
                DisplayInventory();
                break;
            case "4":
                Console.WriteLine("Exiting game...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input. Please try again.");
                break;
        }
    }

    private void MoveToLocation()
{
    // Display available locations to move to
    Console.WriteLine("Available Locations:");
    List<Location> connectedLocations = player.CurrentLocation.GetConnectedLocations();
    for (int i = 0; i < connectedLocations.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {connectedLocations[i].Name}");
    }

    // Prompt the player to choose a location
    Console.Write("Enter the number of the location you want to move to: ");
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        choice--; // Adjust choice to match index

        // Validate choice
        if (choice >= 0 && choice < connectedLocations.Count)
        {
            Location newLocation = connectedLocations[choice];
            player.MoveTo(newLocation);
            Console.WriteLine($"You have moved to {newLocation.Name}.");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a valid location number.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}


    private void InteractWithNPCs()
{
    // Get NPCs in the current location
    List<NPC> npcs = player.CurrentLocation.GetNPCs();

    if (npcs.Count == 0)
    {
        Console.WriteLine("There are no NPCs to interact with in this location.");
        return;
    }

    // Display NPCs available for interaction
    Console.WriteLine("NPCs in the area:");
    for (int i = 0; i < npcs.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {npcs[i].Name}");
    }

    // Prompt the player to choose an NPC to interact with
    Console.Write("Enter the number of the NPC you want to interact with: ");
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        choice--; // Adjust choice to match index

        // Validate choice
        if (choice >= 0 && choice < npcs.Count)
        {
            NPC selectedNPC = npcs[choice];
            selectedNPC.Interact();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a valid NPC number.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}


    private void DisplayInventory()
{
    // Check if the player has any items in their inventory
    if (player.Inventory.Count == 0)
    {
        Console.WriteLine("Your inventory is empty.");
        return;
    }

    // Display the items in the player's inventory
    Console.WriteLine("Inventory:");
    foreach (var item in player.Inventory)
    {
        Console.WriteLine($"{item.Name} - Quantity: {item.Quantity}");
        // Optionally, you can display additional information about the item
        // Console.WriteLine($"   Description: {item.Description}");
    }
}


    private bool GameOver()
    {
        // Check conditions for game over
        return false;
    }
}
