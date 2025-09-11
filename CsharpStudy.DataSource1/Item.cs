namespace CsharpStudy.DataSource1;

public class Item
{
    public int id{ get; set; }
    public string name{ get; set; }
    public int count{ get; set; }
    
    public Item(int id, string name, int count)
    {
        this.id = id;
        this.name = name;
        this.count = count;
    }
}
    

    