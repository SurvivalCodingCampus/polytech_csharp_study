namespace DtoMapper.Models;

public class Pokemon
{
    public string Name { get; }
    public List<string> Types { get; }

    public Pokemon(string name, List<string> types)
    {
        Name = name;
        Types = types;
    }

    protected bool Equals(Pokemon other)
    {
        return Name == other.Name && Types.SequenceEqual(other.Types);
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
        var hash = new HashCode();
        hash.Add(Name);
        foreach (var type in Types)
        {
            hash.Add(type);
        }
        return hash.ToHashCode();
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Types)}: [{string.Join(", ", Types)}]";
    }
}