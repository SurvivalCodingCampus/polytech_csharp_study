namespace CsharpStudy.Exception;

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

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

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