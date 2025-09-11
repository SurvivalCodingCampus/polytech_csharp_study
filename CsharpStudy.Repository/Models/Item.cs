namespace CsharpStudy.Repository.Models;

public class Item
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Count { get; set; }

    public Item(int id, string name, int count)
    {
        this.Id = id;
        this.Name = name;
        this.Count = count;
    }
    
}