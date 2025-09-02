using CsharpStudy._2;
using Newtonsoft.Json;

namespace CsharpStudy.Data;

class Program
{
    static void Main(string[] args)
    {
        
    }
    


    static void JsonSerialization()
    {
        // 직렬화
        Hero hero = new Hero("홍길동", 100, 50);
        string jsonString = JsonConvert.SerializeObject(hero);
        Console.WriteLine(hero);
        Console.WriteLine(jsonString);
        File.WriteAllText("hero.json" , jsonString);
    }
    static void JsonDeSerialization()
    {
        // 역직렬화
        string jsonString = File.ReadAllText("hero.json");
        Hero? hero = JsonConvert.DeserializeObject<Hero>(jsonString);
        Console.WriteLine(hero);
    }

    static void PropertyParser()
    {
        Dictionary<string, object> heroes = new Dictionary<string, object>();
        string[] heroesArray = File.ReadAllLines("hero.properties");

        foreach (string hero in heroesArray)
        {
            string key = hero.Split('=')[0];
            string value = hero.Split('=')[1];
            heroes.Add(key, value);
        }

        foreach (var hero in heroes)
        {
            Console.WriteLine(hero.Key);
        }
    }
    static void CsvParse()
    {
        // 이름, hp, mp
        // CSV
        // string hero = "영웅, 100, 50";
        
        // File.WriteAllText("hero.csv",hero);
       
        List<Hero> heroes = File.ReadAllLines("hero.csv")
            .Skip(1)
            .Select(line =>
            {
                string name = line.Split(',')[0];
                int hp = int.Parse(line.Split(',')[1]);
                int mp = int.Parse(line.Split(',')[2]);
                return new Hero(name, hp, mp);
            })
            .ToList();
            
            heroes.ForEach(Console.WriteLine);
    }
}