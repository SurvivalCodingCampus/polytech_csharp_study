namespace CsharpStudy.DataSource1;

public class Item
{
    public string id{ get; set; }
    public string name{ get; set; }
    public string count{ get; set; }
    
    public Item(string id, string name, string count)
    {
        this.id = id;
        this.name = name;
        this.count = count;
    }
}
    

    