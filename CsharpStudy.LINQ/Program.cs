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

    public override string ToString()
    {
        // return base.ToString();
        return $"Trader: {Trader.Name} || City: {Trader.City} || Year: {Year} || Value: {Value}";
    }
}

public class MainClass
{
    private static List<Transaction> _transactions = new List<Transaction>
    {
        new Transaction(new Trader("Brian", "Cambridge"), 2011, 300),
        new Transaction(new Trader("Raoul", "Cambridge"), 2012, 1000),
        new Transaction(new Trader("Raoul", "Cambridge"), 2011, 400),
        new Transaction(new Trader("Mario", "Milan"), 2012, 710),
        new Transaction(new Trader("Mario", "Milan"), 2012, 700),
        new Transaction(new Trader("Alan", "Cambridge"), 2012, 950)
    };

    public static List<Transaction> transactions => _transactions;

    public static void Main(string[] args)
    {
        Console.WriteLine("1. Show names from all transactions of 2011 ordered by value-ascending");
        
        // Year == 2011, (All Transactions,) Show Name, Ordered By Value-Ascending,
        transactions.Where(transaction => transaction.Year == 2011)
            .OrderBy(transaction => transaction.Value)
            .Select(transaction => transaction.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("======");

        Console.WriteLine("2. Show all unique city where traders are participated");
        
        // From Traders, All City, Show City, No Same Output
        transactions.Select(transaction => transaction.Trader.City)
            .ToHashSet()
            .ToList()
            .ForEach(Console.WriteLine);
        
        Console.WriteLine("======");
        
        Console.WriteLine("3. Show traders' names of Cambridge ordered by alphabet-ascending");
        
        // All Traders, Only In Cambridge, Show Name, Ordered By Name-Ascending
        transactions.Where(transaction => transaction.Trader.City == "Cambridge")
            .Select(transaction => transaction.Trader.Name)
            .ToHashSet()
            .OrderBy(name => name)
            .ToList()
            .ForEach(Console.WriteLine);
        
        Console.WriteLine("======");
        
        Console.WriteLine("4. Show traders' names ordered by alphabet-ascending");
        
        // All Traders, Show Name, Ordered By Alphabet-Ascending
        transactions.Select(transaction => transaction.Trader.Name)
            .ToHashSet()
            .OrderBy(name => name)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("======");
        
        Console.WriteLine("5. Are there traders in Milan?");
        
        // Are there traders in Milan?
        Console.WriteLine(transactions.Any(transaction => transaction.Trader.City == "Milan"));
        
        Console.WriteLine("======");
        
        Console.WriteLine("6. Show all transaction value of traders in Cambridge");
        
        // Show All Transaction 'Value', From Trader, Only Where In Cambridge
        transactions.Where(transaction => transaction.Trader.City == "Cambridge")
            .ToList()
            .ForEach(transaction => Console.WriteLine(transaction.ToString()));
        
        Console.WriteLine("======");
        
        Console.WriteLine("7. Show maximum transaction value among all traders'");
        
        // Show Maximum Transaction Value, From All Transaction
        Console.WriteLine(
            transactions.Select(transaction => transaction.Value)
                .Aggregate(Math.Max)
            );

        Console.WriteLine("======");

        Console.WriteLine("7. Show minimum transaction value among all traders'");
        
        // Show Minimum Transaction Value, From All Transaction
        Console.WriteLine(
            transactions.Select(transaction => transaction.Value)
                .Aggregate(Math.Min)
        );
    }
}