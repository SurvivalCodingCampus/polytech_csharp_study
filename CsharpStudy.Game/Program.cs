using CsharpStudy.Game.Charactrs;

namespace CsharpStudy.Game;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Cleric.MaxHp);
        
        Cleric.SetRandomMoney();
        
        Cleric cleric1 = new Cleric("홍길동1");
        Cleric cleric2 = new Cleric("홍길동2", 50);
        Cleric cleric3 = new Cleric("홍길동3", 50, 10);
        Cleric cleric4 = new Cleric("홍길동1");
        
        List<Cleric> clerics = new List<Cleric>();
        clerics.Add(cleric1);
        clerics.Add(cleric2);
        clerics.Add(cleric3);
        clerics.Add(cleric4);
        Console.WriteLine(clerics.Count);
        
        HashSet<Cleric> clericSet = new HashSet<Cleric>(clerics);
        clericSet.Add(cleric1);
        clericSet.Add(cleric2);
        clericSet.Add(cleric3);
        clericSet.Add(cleric4);
        Console.WriteLine(clericSet.Count);

        HashSet<string> textSet = new HashSet<string>();
        textSet.Add("홍길동");
        textSet.Add("홍길동");
        Console.WriteLine(textSet.Count);

        Console.WriteLine(cleric1.GetHashCode());
        Console.WriteLine(cleric4.GetHashCode());

        string hong1 = "홍길동";
        string hong2 = "홍길동";
        Console.WriteLine(hong1.GetHashCode());
        Console.WriteLine(hong2.GetHashCode());

        Console.WriteLine(cleric1); //뒤에 .string은 생략 가능
        
        Dictionary<Cleric, int> clericMap = new Dictionary<Cleric, int>();
        clericMap.TryAdd(cleric1, 100);
        clericMap.TryAdd(cleric2, 200);

        Console.WriteLine(clericMap.Count);

        List<string> menus = ["메뉴1", "메뉴3", "메뉴2"];
        menus.Sort(); //오름차순
        foreach (var menu in menus)
        {
            Console.WriteLine(menu);
        }
        
        menus.Sort((a, b) => a.CompareTo(b) );
        //내림차순은 -a.CompareTo(b) 하거나 a.CompareTo(b)*-1

        foreach (var menu in menus)
        {
            Console.WriteLine(menu);
        }
        
        clerics.Sort();
        {
            Console.WriteLine();
        }
        
        Character character = new Wizard();
        if (character is Wizard wizard)
        {
            wizard.Fireball();
        }
        //Wizard wizard2 = (Wizard) character;
        Wizard? wizard2 = character as Wizard; //?는 null을 허용한다는 의미
        string? nullableString = null;
        string nonNUllableString = "null";
        
        
    }
}