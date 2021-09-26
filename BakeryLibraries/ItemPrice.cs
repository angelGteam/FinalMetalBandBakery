public class ItemPrice {
    public ItemPrice(string itemId, decimal price) {
        ItemId = itemId;
        Price = price;
    }
    public ItemPrice(string itemId, decimal price, string name) {
        ItemId = itemId;
        Price = price;
        Name = name;
    }
    public ItemPrice() { }
    public string ItemId { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
}