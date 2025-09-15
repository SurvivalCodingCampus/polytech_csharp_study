namespace CshapStudy.DtoMapper.Models;

public class Pokemon
{
    public string Name { get; set; }
    public string Imageurl { get; set; }

    public Pokemon(string name, string imageUrl)
    {
        Name = name;
        Imageurl = imageUrl;
        
    }

    protected bool Equals(Pokemon other)
    {
        return Name == other.Name && Imageurl == other.Imageurl;
    }

    public override bool Equals(object? obj)
    {
        if(obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Pokemon)obj);
        
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Imageurl);
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Imageurl)}: {Imageurl}";
    }
}
