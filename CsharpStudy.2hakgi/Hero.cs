namespace CsharpStudy._2hakgi;

public class Hero
{
    public string Name { get; set; }

    public Hero(string name)
    {
        Name = name;
    }

    protected bool Equals(Hero other)
    {
        return Name == other.Name;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Hero)obj);
    }
    
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}