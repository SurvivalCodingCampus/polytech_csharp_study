namespace FP2.Trader;

public class Trader
{
    public string Name { get; set; }
    public string City { get; set; }

    public Trader(string name, string city)
    {
        Name = name;
        City = city;
    }
}

public class Transaction
{
    public Trader Trader { get; set; }
    public int Year { get; set; }
    public int Value { get; set; }

    public Transaction(Trader trader, int year, int value)
    {
        Trader = trader;
        Year = year;
        Value = value;
    }
}

public class MainClass
{
    public static List<Transaction> transactions = new List<Transaction>
    {
        new Transaction(new Trader("Brian", "Cambridge"), 2011, 300),
        new Transaction(new Trader("Raoul", "Cambridge"), 2012, 1000),
        new Transaction(new Trader("Raoul", "Cambridge"), 2011, 400),
        new Transaction(new Trader("Mario", "Milan"), 2012, 710),
        new Transaction(new Trader("Mario", "Milan"), 2012, 700),
        new Transaction(new Trader("Alan", "Cambridge"), 2012, 950)
    };

    public static void Main(string[] args)
    {
        // 1. 2011년에 일어난 모든 트랜잭션을 찾아 가격 기준 오름차순으로 정리하여 이름을 나열하시오
        transactions.Where(transaction => transaction.Year == 2011)
            .OrderBy(transaction => transaction.Value)
            .Select(transaction => transaction.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);
        
        Console.WriteLine("2번--------");
       List<string> names= transactions.Select(transaction => transaction.Trader.Name)
           .ToHashSet()
           .ToList();
       
       foreach (var name in names)
       {
           Console.WriteLine(name);
       }
       
       Console.WriteLine("3번--------");
       List<string> cambrigeNames = transactions.Where(transaction => transaction.Trader.City == "Cambridge")
           .Select(transaction => transaction.Trader.Name)
           .OrderBy(name => name)
           .ToList();
       foreach (var name in cambrigeNames)
       {
           Console.WriteLine(name);
       }
       Console.WriteLine("4번--------");
       List<string> everyname = transactions.Select(transaction => transaction.Trader.Name)
           .OrderBy(name => name)
           .ToList();
       foreach (var name in everyname)
       {
           Console.WriteLine(name);
       }
       
       Console.WriteLine("5번--------");
       bool milan = transactions.Any(transaction => transaction.Trader.City == "Milan");
       Console.WriteLine(milan);
       
       Console.WriteLine("6번--------");
       List<int> cambridgean =  transactions.Where(transaction => transaction.Trader.City == "Cambridge")
           .Select(transaction => transaction.Value)
           .ToList();
       foreach (var value in cambridgean)
       {
           Console.WriteLine(value);
       }

       Console.WriteLine("7번--------");
       //List<int> maxResult = transactions.Select(transaction => transaction.Value).ToList();
       //int max = maxResult.Max();
       //Console.WriteLine(max);
       int maxResult= transactions.Select(transaction => transaction.Value)
           .Aggregate((e, v) => Math.Max(e , v));
       
       Console.WriteLine(maxResult);
       
       Console.WriteLine("8번--------");
       //int min = maxResult.Min();
       //Console.WriteLine(min);
       int minResult = transactions.Select(transaction => transaction.Value)
           .Aggregate((e, v) => Math.Min(e, v));
       
       Console.WriteLine(minResult);










    }
}