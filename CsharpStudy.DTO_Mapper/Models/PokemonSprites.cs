using Newtonsoft.Json;

namespace CsharpStudy.DTO_Mapper.Models;

public class Pokemon
{
    public string Name { get; }
    public string Url { get; }
    
    public Pokemon(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Url)}: {Url}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((Pokemon)obj);
    }

    protected bool Equals(Pokemon other)
    {
        return Name == other.Name && Url == other.Url;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Url);
    }
}