namespace CsharpStudy._0911;

public class Item
{
    public int Id { get; }
    public string Name { get; }
    public int Count { get; private set; }

    public Item(int id, string name, int count)
    {
        Id = id;
        Name = name;
        Count = count;
    }

    public void IncreaseCount(int value) => Count += value;
}