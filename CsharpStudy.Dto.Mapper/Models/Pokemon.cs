namespace CsharpStudy.Dto.Mapper.Models;

public class Pokemon
{
    private int Id { get; }
    private string Name { get; }

    public Pokemon(int id, string name)
    {
        Id = id;
        Name = name;
    }
}