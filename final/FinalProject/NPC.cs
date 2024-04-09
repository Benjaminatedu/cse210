using System;

class NPC : Character
{
    public NPC(string name, int health, int attackDamage, int defense) 
        : base(name, health, attackDamage, defense)
    {
        // Additional initialization for NPC specific properties can be added here
    }

    public void Interact()
    {
        // Logic for interacting with the NPC
        Console.WriteLine($"{Name}: Hello, traveler!");
        // Additional interaction logic can be added here
    }

    // Additional methods and properties specific to NPCs can be added here
}
