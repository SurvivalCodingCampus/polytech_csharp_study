namespace CsharpStudy.DTO.Data.Models;

public class Pokemon
{
    public string Name { get; set; }
    public string OfficialArtFront { get; set; }
    public List<string> Abilities = new List<string>();

    public Pokemon(string name, string officialArtFront, List<string> abilities)
    {
        Name = name;
        OfficialArtFront = officialArtFront;
        Abilities = abilities;
    }
}