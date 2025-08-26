public class Trader
{
    public string Name { get; set; }
    public string City { get; set; }

    public Trader(string name, string city)
    {
        Name = name;
        City = city;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(City)}: {City}";
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
        return $"{nameof(Trader)}: {Trader}, {nameof(Year)}: {Year}, {nameof(Value)}: {Value}";
    }
}