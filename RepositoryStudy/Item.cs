namespace RepositoryStudy;

public class Item
{
    public int id {get; private set;}
    public string name {get; private set;}
    public int count{get; set;}
    

    public Item(int id, string name, int count)
    {
        this.id = id;
        this.name = name;
        this.count = count;
    }
    
}