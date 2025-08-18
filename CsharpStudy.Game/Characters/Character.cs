namespace CsharpStudy.Game.Characters;

public abstract class Character // Abstract class; Just declare, NO IMPLEMENTATION
{
    public string Name { get; set; }
    
    public abstract void Run(); // Abstract method; Implementation is needed in concrete class.
}