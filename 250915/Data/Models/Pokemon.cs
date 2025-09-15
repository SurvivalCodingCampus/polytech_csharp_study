namespace _250915.Data.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Pokemon(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    
}