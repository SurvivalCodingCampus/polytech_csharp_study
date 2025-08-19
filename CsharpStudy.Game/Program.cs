using CsharpStudy.Game.Characters;

namespace CsharpStudy.Game;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Cleric cleric1 = new Cleric("홍길동1");
        Cleric cleric2 = new Cleric("홍길동3",10);
        Cleric cleric3 = new Cleric("홍길동2",10,10);
        Cleric cleric4 = new Cleric("홍길동1");

        Cleric.SetRandomMoney();

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
        
        HashSet<Cleric> textSet = new HashSet<Cleric>();
        textSet.Add(cleric1);
        textSet.Add(cleric2);
        Console.WriteLine(textSet.Count);

        Console.WriteLine(cleric1.GetHashCode());
        Console.WriteLine(cleric4.GetHashCode());

        string hong1 = "홍길동";
        string hong2 = "홍길동";
        Console.WriteLine(hong1.GetHashCode());
        Console.WriteLine(hong2.GetHashCode());

        Console.WriteLine(cleric1.ToString());
        
        // HashMap, 키가 중복 되면 오류 발생
        // TryAdd : 중복 된 키도 추가 가능
        Dictionary<Cleric, int> clericMap = new Dictionary<Cleric, int>();
        clericMap.TryAdd(cleric1, 100);
        clericMap.TryAdd(cleric2, 200);

        Console.WriteLine(clericMap.Count);

        List<string> menus = ["메뉴1", "메뉴3", "메뉴2"];
        // 오름차순
        menus.Sort();
        foreach (var menu in menus)
        {
            Console.WriteLine(menu);
        }
        // 메뉴1 메뉴2 메뉴3 출력
        
        // -를 붙이면 내림차순
        menus.Sort((x, y) => -x.CompareTo(y));
        foreach (var menu in menus)
        {
            Console.WriteLine(menu);
        }
        // 메뉴3 메뉴2 메뉴1 출력
        
        // Cleric 클래스에서 Comparable을 재정의 하지 않으면 터짐
        clerics.Sort();

        // 업 캐스팅
        Character character = new Wizard();
        // 위험
        // Wizard wizard = (Wizard)character;
        
        // 안전하게 타입 캐스팅
        if (character is Wizard wizard)
        {
            wizard.Fireball();
        }
        
        // 캐스팅 실패 시 null 반환
        Wizard? wizard2 = character as Wizard;

        
    }
}