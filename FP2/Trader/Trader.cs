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


        // null safety :
        List<string> transactions2 = new List<string>();
        string? nullableFirst = transactions2.FirstOrDefault();

        // string first = "기본값";
        // if (nullableFirst != null)
        // {
        //     first = nullableFirst;
        // }
        
        string first = nullableFirst ?? "기본값";
        Console.WriteLine(first);

        transactions2.Max();

        // 글자수가 짝수인지
        bool isEven = first.IsEven();
    }
}

// 확장 함수
public static class StringExtensions
{
    public static bool IsEven(this string str)
    {
        return str.Length % 2 == 0;
    }
}