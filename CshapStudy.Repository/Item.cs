namespace CshapStudy.Repository;

public class Item
{
    protected bool Equals(Item other)
    {
        return Id == other.Id && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Item)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }

    public Item()
    {
    }

    public Item(int id, string name, int count)
    {
        Id = id;
        Name = name;
        this.Count = count;
    }

    public int Id {get; set;}
    public string Name {get; set;}
    public int Count {get; set;}
    
    
}