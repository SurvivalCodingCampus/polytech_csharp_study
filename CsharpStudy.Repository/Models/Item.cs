namespace CsharpStudy.Repository.Models;

public class Item
{
    private int Id { get; set; }
    private string Name { get; set; }
    private int Count { get; set; }

    public Item(int id, string name, int count)
    {
        this.Id = id;
        this.Name = name;
        this.Count = count;
    }
    
}