class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Quantity { get; set; }

    public Item(string name, string description, int quantity)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
    }

    // You can add more properties and methods as needed
}
