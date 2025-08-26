namespace CsharpStudy_0826;

public class Data
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
        // 1. 2011년에 일어난 모든 트랜잭션을 찾아 가격 기준 오름차순으로 정리하여 이름을 나열하시오: where
        transactions.Where(transactions => transactions.Year ==2011)
            .OrderBy(transactions=>transactions.Value)
            .Select(transactions=>transactions.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);
        
        // 2. 거래자가 근무하는 모든 도시를 중복 없이 나열하시오 /Select
        transactions.Select(transactions => transactions.Trader.City)
            .ToHashSet()
            .ToList()
            .ForEach(Console.WriteLine);

    }

    
}