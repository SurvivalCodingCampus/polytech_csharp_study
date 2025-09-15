using CsharpStudy.DtoMapper.DTOs;

namespace CsharpStudy.DtoMapper.Models;

public class Pokemon
{
    public string Name { get; }
    public string ImageUrl { get; }
    
    public List<AbilityWrapperDto>  Abilities { get; }

    public Pokemon(string name, string imageUrl,  List<AbilityWrapperDto> abilities)
    {
        Name = name;
        ImageUrl = imageUrl;
        Abilities = abilities;
    }

    protected bool Equals(Pokemon other)
    {
        return Name == other.Name && ImageUrl == other.ImageUrl && Abilities.SequenceEqual(other.Abilities);;
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
        return HashCode.Combine(Name, ImageUrl,  Abilities);
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(ImageUrl)}: {ImageUrl},  {nameof(Abilities)}: {Abilities}";
    }
}