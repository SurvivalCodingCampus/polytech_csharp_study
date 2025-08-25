using CsharpStudy.Game.Characters;

namespace CsharpStudy.Game;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Cleric.MaxHp);
        
        Cleric.SetRandomMoney();

        Cleric cleric1 = new Cleric("홍길동1");
        Cleric cleric2 = new Cleric("홍길동3", 10);
        Cleric cleric3 = new Cleric("홍길동2", 10, 10);
        Cleric cleric4 = new Cleric("홍길동1");

        // List does NOT identify member-equality
        List<Cleric> clerics = new List<Cleric>();
        clerics.Add(cleric1);
        clerics.Add(cleric2);
        clerics.Add(cleric3);
        clerics.Add(cleric4);
        Console.WriteLine(clerics.Count);       // return 4.

        // Set DOES.
        HashSet<Cleric> clericSet = new HashSet<Cleric>();
        clericSet.Add(cleric1);
        clericSet.Add(cleric2);
        clericSet.Add(cleric3);
        clericSet.Add(cleric4);
        Console.WriteLine(clericSet.Count);     // return 3.

        HashSet<string> textSet = new HashSet<string>();
        textSet.Add("홍길동");
        textSet.Add("홍길동");
        Console.WriteLine(textSet.Count);       // return 1.

        // Same HashCode returns.
        Console.WriteLine(cleric1.GetHashCode());
        Console.WriteLine(cleric4.GetHashCode());

        // Same HashCode returns.
        string hong1 = "홍길동";
        string hong2 = "홍길동";
        Console.WriteLine(hong1.GetHashCode());
        Console.WriteLine(hong2.GetHashCode());
        
        // Redefined ToString();
        // calling variable itself will call 'toString()'.
        Console.WriteLine(cleric1.ToString());
        Console.WriteLine(cleric1);

        // Dictionary will NOT add same object.
        Dictionary<Cleric, int> clericMap = new Dictionary<Cleric, int>();
        clericMap.TryAdd(cleric1, 100);
        clericMap.TryAdd(cleric1, 100);     // Same one as above.
        clericMap.TryAdd(cleric2, 200);
        
        Console.WriteLine(clericMap.Count); // return 2.

        // List has 'order'.
        List<string> menus = ["메뉴1", "메뉴3", "메뉴2"];
        menus.Sort();                       // Sort ascending.
        menus.Sort((a, b) => a.CompareTo(b) * -1);          // Sort descending.
        
        foreach (var menu in menus) // Print one by one.
        {
            Console.WriteLine(menu); 
        }
        
        // Sort rule redefined;
        // One will be compared to other's name.
        clerics.Sort();
        foreach (var cleric in clerics)
        {
            Console.WriteLine(cleric);
        }

        Character character = new Wizard();
        // Casting a variable cannot guarantee whether it is a specific class.
        // Wizard wizard = (Wizard) character;
        // How about using 'is' to check if the variable is the one?

        // It's like 'instanceof' from Java.
        // You can abbreviate like below:
        if (character is Wizard wizard)
        {
            wizard.Fireball();
        }
        
        // Null-optional(Nullable) variable
        // Treating as Wizard class by using a keyword 'as'
        Wizard? wizard2 = character as Wizard;          // Wizard wizard2 = (Wizard) character;

        string? nullableString = null;                  // No error.
        string nonNullableString = "null";

    }
}