using Newtonsoft.Json;

namespace CsharpStudy.Network.Models;

public class Pokemon
{
    public int Id { get; }
    public string Name { get; }
    public string Image { get; }


    protected bool Equals(Pokemon other)
    {
        return Id == other.Id && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Pokemon)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }

    public Pokemon(int id, string name, string image)
    {
        Id = id;
        Name = name;
        Image = image;
    }
}