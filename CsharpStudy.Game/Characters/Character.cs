namespace CsharpStudy.Game.Characters;

public abstract class Character
{
    public string Name { get; set; }
    public abstract void Run();
}