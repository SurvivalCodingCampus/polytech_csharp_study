namespace Csharp.Repository.Models;

public class Item
{
    public int ItemId { get; set; }   
    public string ItemName { get; set; }   
    public int ItemCount { get; set; }   
    
    public Item(int itemId, string itemName, int itemCount)
    {
        ItemId = itemId;
        ItemName = itemName;
        ItemCount = itemCount;
    }
}