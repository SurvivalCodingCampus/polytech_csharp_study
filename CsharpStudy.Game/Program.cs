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
        Cleric cleric2 = new Cleric("홍길동", 10);
        Cleric cleric3 = new Cleric("홍길동", 10, 1);
        Cleric cleric4 = new Cleric("홍길동");
        
        List<Cleric> clerics = new List<Cleric>();
        clerics.Add(cleric1);
        clerics.Add(cleric2);
        clerics.Add(cleric3);
        clerics.Add(cleric4);
        Console.WriteLine(clerics.Count);
        
        HashSet<Cleric> clericSet = new HashSet<Cleric>();
        clericSet.Add(cleric1);
        clericSet.Add(cleric2);
        clericSet.Add(cleric3);
        clericSet.Add(cleric4);
        Console.WriteLine(clericSet.Count);
        
        HashSet<string> textSet = new HashSet<string>();
        textSet.Add("홍길동");
        Console.WriteLine(textSet.Count);

        string hong1 = "홍길동";
        string hong2 = "홍길동";
        Console.WriteLine(hong1.GetHashCode());
        Console.WriteLine(hong2.GetHashCode());

        Console.WriteLine(cleric1.ToString());
        Console.WriteLine(cleric1);

        Dictionary<Cleric, int> clericMap = new Dictionary<Cleric, int>();
        clericMap.TryAdd(cleric1, 100);
        clericMap.TryAdd(cleric2, 200);
        
        Console.WriteLine(clericMap.Count);

        List<string> menus = ["메뉴1", "메뉴3", "메뉴2"];
        menus.Sort();
        
        foreach (var menu in menus)
        {
            Console.WriteLine(menu);
        }
        
        //펑
        clerics.Sort();
        foreach (var cleric in clerics)
        {
            Console.WriteLine(cleric);
        }

        Character character = new Wizard();
        if (character is Wizard wizard)
        {
            wizard.Fireball();
        }
        
        Wizard? wizard2 = character as Wizard;

        string? nullableString = null;
        
    }
}