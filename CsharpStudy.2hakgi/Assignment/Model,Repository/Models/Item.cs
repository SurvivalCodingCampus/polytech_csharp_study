namespace CsharpStudy._2hakgi.Assignment.Model_Repository.Models;

public class Item
{
    public string ItemID { get; set; }   
    public string ItemName { get; set; }   
    public int ItemCount { get; set; }   
    
    public Item(string itemId, string itemName, int itemCount)
    {
        ItemID = itemId;
        ItemName = itemName;
        ItemCount = itemCount;
    }
}