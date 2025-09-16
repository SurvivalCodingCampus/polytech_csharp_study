using CsharpStudy.DtoMapper.DTOs;

namespace CsharpStudy.DtoMapper.Models;

//public record Pokemon(int id, string Name, string ImageUrl, List<AbilityWrapperDto> Abilities);


public class Pokemon
{
    public int Id { get; }
    public string Name { get; }
    public string ImageUrl { get; } = null!;

    public List<AbilityWrapperDto>  Abilities { get; } = null!;

    public Pokemon(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Pokemon(int id, string name, string imageUrl,  List<AbilityWrapperDto> abilities)
    {
        Id = id;
        Name = name;
        ImageUrl = imageUrl;
        Abilities = abilities;
    }

    protected bool Equals(Pokemon other)
    {
        return Id == other.Id && Name == other.Name && ImageUrl == other.ImageUrl && Abilities.SequenceEqual(other.Abilities);;
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
        return HashCode.Combine(Id, Name, ImageUrl,  Abilities);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(ImageUrl)}: {ImageUrl},  {nameof(Abilities)}: {Abilities}";
    }
}