namespace CaharpStudy._2hakgi.Debuging;

public class DebugSample
{
    /*static void Main(string[] args)
    {
        var heroes = new List<Hero>();

        var hero1 = new Hero("슈퍼맨", 100);
        var hero2 = new Hero("슈퍼맨", 100);
        
        Add(heroes, hero1);
        
        heroes.Add(hero1);
        heroes.Add(hero2);
    }*/

    static void Update(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"카운트 : {i}");
        }
    }

    /*static void Add(List<Hero> heroes, Hero newHero)
    {
        heroes.Add(newHero);
    }*/
}