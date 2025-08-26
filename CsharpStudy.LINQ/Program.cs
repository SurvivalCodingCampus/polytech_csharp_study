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
        // Year == 2011, (All Transactions,) Show Name, Ordered By Value-Ascending,
        transactions.Where(transaction => transaction.Year == 2011)
            .OrderBy(transaction => transaction.Value)
            .Select(transaction => transaction.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("======");
        
        // From Traders, All City, Show City, No Same Output
        transactions.Select(transaction => transaction.Trader.City)
            .ToHashSet()
            .ToList()
            .ForEach(Console.WriteLine);
        
        Console.WriteLine("======");
        
        // All Traders, Only In Cambridge, Show Name, Ordered By Name-Ascending
        transactions.Where(transaction => transaction.Trader.City == "Cambridge")
            .Select(transaction => transaction.Trader.Name)
            .ToHashSet()
            .OrderBy(name => name)
            .ToList()
            .ForEach(Console.WriteLine);
        
        Console.WriteLine("======");
        
        // All Traders, Show Name, Ordered By Alphabet-Ascending
        transactions.Select(transaction => transaction.Trader.Name)
            .ToHashSet()
            .OrderBy(name => name)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("======");
        
        // Is there a trader in Milan?
        Console.WriteLine(transactions.Any(transaction => transaction.Trader.City == "Milan"));
        
        Console.WriteLine("======");
        
        // Show All Transaction 'Value', From Trader, Only Where In Cambridge
        transactions.Where(transaction => transaction.Trader.City == "Cambridge")
            .ToList()
            .ForEach(transaction => Console.WriteLine(transaction.Value));
        
        Console.WriteLine("======");
        
        // Show Maximum Transaction Value, From All Transaction
        Console.WriteLine(
            transactions.Select(transaction => transaction.Value)
                .Aggregate(Math.Max)
            );

        Console.WriteLine("======");
        
        // Show Minimum Transaction Value, From All Transaction
        Console.WriteLine(
            transactions.Select(transaction => transaction.Value)
                .Aggregate(Math.Min)
        );
    }
}