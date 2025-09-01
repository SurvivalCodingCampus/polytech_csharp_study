using CsharpStudy.Game.Characters;

namespace CsharpStudy.Game;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Cleric.MaxHp);

        Cleric.SetRandomMoney();

        var cleric1 = new Cleric("홍길동1");
        var cleric2 = new Cleric("홍길동3", 10);
        var cleric3 = new Cleric("홍길동2", 10);
        var cleric4 = new Cleric("홍길동1");

        var clerics = new List<Cleric>();
        clerics.Add(cleric1);
        clerics.Add(cleric2);
        clerics.Add(cleric3);
        clerics.Add(cleric4);
        Console.WriteLine(clerics.Count);

        var clericSet = new HashSet<Cleric>();
        clericSet.Add(cleric1);
        clericSet.Add(cleric2);
        clericSet.Add(cleric3);
        clericSet.Add(cleric4);
        Console.WriteLine(clericSet.Count);

        var textSet = new HashSet<string>();
        textSet.Add("홍길동");
        textSet.Add("홍길동");
        Console.WriteLine(textSet.Count);

        Console.WriteLine(cleric1.GetHashCode());
        Console.WriteLine(cleric4.GetHashCode());

        var hong1 = "홍길동";
        var hong2 = "홍길동";
        Console.WriteLine(hong1.GetHashCode());
        Console.WriteLine(hong2.GetHashCode());

        Console.WriteLine(cleric1.ToString());
        Console.WriteLine(cleric1);

        var clericMap = new Dictionary<Cleric, int>();
        clericMap.TryAdd(cleric1, 100);
        clericMap.TryAdd(cleric2, 200);

        Console.WriteLine(clericMap.Count);

        List<string> menus = ["메뉴1", "메뉴3", "메뉴2"];
        // 오름차순
        menus.Sort();

        // 내림차순
        menus.Sort((a, b) => a.CompareTo(b) * -1);

        foreach (var menu in menus) Console.WriteLine(menu);

        // 터졌음
        clerics.Sort();
        foreach (var cleric in clerics) Console.WriteLine(cleric);

        Character character = new Wizard();
        // 위험
        // Wizard wizard = (Wizard) character;
        if (character is Wizard wizard) wizard.Fireball();

        // Wizard wizard2 = (Wizard) character;
        var wizard2 = character as Wizard;

        string? nullableString = null;
        var nonNullableString = "null";
    }
}