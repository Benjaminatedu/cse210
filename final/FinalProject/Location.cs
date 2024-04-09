using System.Collections.Generic;

class Location
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    private List<Location> connectedLocations;
    private List<NPC> npcs;

    public Location(string name, string description)
    {
        Name = name;
        Description = description;
        connectedLocations = new List<Location>();
        npcs = new List<NPC>();
    }

    // Method to add a connected location
    public void AddConnection(Location location)
    {
        connectedLocations.Add(location);
    }

    // Method to get the list of connected locations
    public List<Location> GetConnectedLocations()
    {
        return connectedLocations;
    }

    // Method to add an NPC to the location
    public void AddNPC(NPC npc)
    {
        npcs.Add(npc);
    }

    // Method to get the list of NPCs in the location
    public List<NPC> GetNPCs()
    {
        return npcs;
    }
}
