using Newtonsoft.Json;
namespace Data;

class Sword
{
    public string Name { get; set; }

    public Sword(string name)
    {
        Name = name;
    }
}

class Hero
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public List<string> Items { get; set; }=new List<string>();
    public Sword? Sword { get; set; }

    public Hero(string name, int hp, int mp)
    {
        Name = name;
        Hp = hp;
        Mp = mp;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Hp)}: {Hp}, {nameof(Mp)}: {Mp}";
    }
}

class Program
{
    /*static void Main(string[] args)
    {
        JsonSerializtion();
        JsonDeserialztion();
    }*/

    static void JsonSerializtion()
    {
        Hero hero = new Hero("홍길동", 100, 50);
        hero.Items.Add("물약");
        hero.Items.Add("반창고");
        hero.Sword = new Sword("불의 검");
        
        string jsonString = JsonConvert.SerializeObject(hero);
        Console.WriteLine(hero);
        Console.WriteLine(jsonString);
        File.WriteAllText("hero.json", jsonString);
    }

    static void JsonDeserialztion()
    {
        string jsonString=File.ReadAllText("hero.json");
        Hero hero=JsonConvert.DeserializeObject<Hero>(jsonString);
        Console.WriteLine(hero);
    }

    static void PropertyParser()
    {
        Dictionary<string, object> heroes = new Dictionary<string, object>();
        
        string[] heroesArray=File.ReadAllLines("hero.properties");

        foreach (var hero in heroesArray)
        {
            string key = hero.Split("=")[0];
            string value = hero.Split("=")[1];
            heroes.Add(key, value);
        }

        foreach (var keyValuePair in heroes)
        {
            Console.WriteLine(keyValuePair.Key+" : "+keyValuePair.Value);
        }
    }

    static void CsvParser()
    {
        List<Hero> heroes=File.ReadAllLines("hero.csv")
            .Skip(1)
            .Select(line =>
            {
                string name = line.Split("=")[0];
                int hp = int.Parse(line.Split(",")[1]);
                int mp = int.Parse(line.Split(",")[2]);
                return new Hero(name, hp, mp);
            })
            .ToList();
        
        heroes.ForEach(Console.WriteLine);
    }
}