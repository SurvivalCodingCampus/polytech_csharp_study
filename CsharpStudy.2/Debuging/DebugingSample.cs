namespace CsharpStudy._2.Debuging;

public class DebugingSample
{
    static void Main(string[] args)
    {
        var heroes = new List<Hero>();
        
        var hero1 = new Hero("슈퍼맨", 100);
        var hero2 = new Hero("슈퍼맨", 100);
        
        Add(heroes, hero1);
        
        Update(10);

        heroes.Remove(hero2);
    }

    static void Update(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"카운트 : {i}");
        }
    }
    static void Add(List<Hero> heroes, Hero newHero)
    {
        Console.WriteLine(heroes.Count);
        heroes.Add(newHero);
        Console.WriteLine(heroes.Count);
    }
}