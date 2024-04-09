using System.Collections.Generic;

class World
{
    public static Location StartingLocation { get; private set; }
    private List<Location> locations;

    public World()
    {
        locations = new List<Location>();
        InitializeWorld();
    }

    private void InitializeWorld()
    {
        // Create locations
        Location location1 = new Location("Location 1", "Description of Location 1");
        Location location2 = new Location("Location 2", "Description of Location 2");

        // Create NPCs
        NPC npc1 = new NPC("NPC 1", 50, 8, 3);
        NPC npc2 = new NPC("NPC 2", 60, 10, 5);

        // Add NPCs to locations
        location1.AddNPC(npc1);
        location2.AddNPC(npc2);

        // Connect locations as needed
        ConnectLocations(location1, location2);
        // Add more connections as needed

        // Set starting location
        StartingLocation = location1;

        // Add locations to the list
        locations.Add(location1);
        locations.Add(location2);
    }

    private void ConnectLocations(Location location1, Location location2)
    {
        location1.AddConnection(location2);
        location2.AddConnection(location1);
    }
}
