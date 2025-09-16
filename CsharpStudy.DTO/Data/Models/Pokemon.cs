namespace CsharpStudy.DTO.Data.Models;

public class Pokemon
{
    public string Name { get; set; }
    public string OfficialArtFront { get; set; }
    public List<string> Abilities;

    public Pokemon(string name, string officialArtFront, List<string> abilities)
    {
        Name = name;
        OfficialArtFront = officialArtFront;
        Abilities = abilities;
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Pokemon pokemon)) return false;
        return (Name == pokemon.Name);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        string abilityList = "None";
        
        if (Abilities.Count > 0)
        {
            foreach (var ability in Abilities)
            {
                abilityList = string.Join(", ", Abilities);
            }
        }
        return $"Name : {Name} \nImgURL : {OfficialArtFront} \nAbilities : {abilityList}";
    }
}