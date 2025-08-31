namespace CsharpStudy.FP2;
using System.Linq;

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
        //2011년 오름차순
        transactions.Where(trader => trader.Year == 2011)
            .OrderBy(trader => trader.Value)
            .Select(transaction => transaction.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);
            Console.WriteLine();

        //근무지
        transactions.Select(transaction => transaction.Trader.City)
            .Distinct()
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        
        //cambridge 근무자
        transactions.Where(trader => trader.Trader.City == "Cambridge")
            .Select(transaction => transaction.Trader.Name)
            .OrderBy(name => name)
            .Distinct()
            .ToList()
            .ForEach(Console.WriteLine);


        //근무자 이름 나열
        transactions.Select(transaction => transaction.Trader.Name)
            .Distinct()
            .OrderBy(name => name)
            .ToList()
            .ForEach(Console.WriteLine);

        
        //Milan 근무자
        transactions.Where(transaction => transaction.Trader.City == "Milan")
            .Select(transaction => transaction.Trader.Name)
            .Distinct()
            .ToList()
            .ForEach(Console.WriteLine);
        
        //Cambridge 근무자 transaction 출력
        var CambridgeTransactions = transactions
            .Where(transaction => transaction.Trader.City == "Cambridge");
        foreach (var t in CambridgeTransactions)
        {
            Console.WriteLine($"[{t.Year}] {t.Trader.Name} - Value: {t.Value}");
        }

        int Maxvalue = transactions.Aggregate((a, b) => Math.Max(a.Value, b.Value));
        
    }
    
}