using CsharpStudy.Game.Characters;

namespace CsharpStudy.Game;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Cleric.MaxHp);
        
        Cleric.SetRandomMoney();

        Cleric cleric1 = new Cleric("홍길동");
    }
}