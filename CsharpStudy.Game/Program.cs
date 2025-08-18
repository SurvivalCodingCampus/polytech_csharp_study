using CsharpStudy.Game.Characters;

namespace CsharpStudy.Game;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Cleric.MaxMp);

        Cleric.SetRandomMoney();

        Cleric cleric1 = new Cleric("g", 1);
        Cleric cleric2 = new Cleric("g", 2, 2);
        Cleric cleric3 = new Cleric("g");
        Cleric cleric4 = new Cleric("g");

        // list는 중복을 허용
        List<Cleric> clerics = new List<Cleric>();
        clerics.Add(cleric1);
        clerics.Add(cleric2);
        clerics.Add(cleric3);
        clerics.Add(cleric4);
        Console.WriteLine(clerics.Count);
        
        // equals 재정의로 이름이 같으면 동일하게 처리
        HashSet<Cleric> clericSet = new HashSet<Cleric>();
        clericSet.Add(cleric1);
        clericSet.Add(cleric2);
        clericSet.Add(cleric3);
        clericSet.Add(cleric4);
        Console.WriteLine(clericSet.Count);
        
        HashSet<string> textSet = new HashSet<string>();
        textSet.Add("g");
        textSet.Add("g");
        Console.WriteLine(textSet.Count);
        
        Console.WriteLine(cleric3.GetHashCode());
        Console.WriteLine(cleric4.GetHashCode());

        string s1 = "g";
        string s2 = "g";
        Console.WriteLine(s1.GetHashCode());
        Console.WriteLine(s2.GetHashCode());
        
        //toString 출력 ( 생략 가능 )
        Console.WriteLine(cleric1);
        
        Dictionary<Cleric, int> clericMap = new Dictionary<Cleric, int>();
        clericMap.TryAdd(cleric3, 1);
        clericMap.TryAdd(cleric4, 2);
        
        Console.WriteLine(clericMap.Count);

        List<string> menus = ["메뉴1", "메뉴3", "메뉴2"];
        
        // 오름차순
        menus.Sort();
        // 내림차순
        menus.Sort((a,b)=> -a.CompareTo(b));
        
        foreach (var menu in menus)
        {
            Console.WriteLine(menu);
        }
        
        Character character = new Wizard();
        
        // 위험
        // Wizard wizard = (Wizard) character;
        if (character is Wizard wizard)
        {
            wizard.Fireball();
        }
        Wizard? wizard2 = character as Wizard;
        string? nullableString = null;
    }
}