
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

    public static int Main(string[] args)
    {
        // 1. 2011년에 일어난 모든 트랜잭션을 찾아 가격 기준 오름차순으로 정리하여 이름을 나열하시오
        Solved_1();
        
        // 2. 거래자가 근무하는 모든 도시를 중복 없이 나열하시오
        Solved_2();
        
        // 3. 케임브리지에서 근무하는 모든 거래자를 찾아서 이름순으로 정렬하여 나열하시오
        Solved_3();
        
        // 4. 모든 거래자의 이름을 알파벳순으로 정렬하여 나열하시오
        Solved_4();
        
        // 5. 밀라노에 거래자가 있는가?
        Solved_5();
        
        // 6. 케임브리지에 거주하는 거래자의 모든 트랙잭션값을 출력하시오
        Solved_6();
        
        // 7. 전체 트랜잭션 중 최대값은 얼마인가?
        Solved_7();
        
        // 8. 전체 트랜잭션 중 최소값은 얼마인가?
        Solved_8();

        return 0;
    }

    private static void Solved_1()
    {
        Console.WriteLine("\n=== 1. 2011년에 일어난 모든 트랜잭션을 찾아 가격 기준 오름차순으로 정리하여 이름을 나열하시오 ===");
        transactions
            .Where(it => it.Year == 2011)
            .OrderBy(it => it.Value)
            .Select(it => it.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);
    }

    private static void Solved_2()
    {
        Console.WriteLine("\n=== 2. 거래자가 근무하는 모든 도시를 중복 없이 나열하시오 ===");
        transactions
            .DistinctBy(it => it.Trader.City)
            .Select(it => it.Trader.City)
            .ToList()
            .ForEach(Console.WriteLine);
    }

    private static void Solved_3()
    {
        Console.WriteLine("\n=== 3. 케임브리지에서 근무하는 모든 거래자를 찾아서 이름순으로 정렬하여 나열하시오 ===");
        transactions
            .Where(it => it.Trader.City == "Cambridge")
            .DistinctBy(it => it.Trader.Name)
            .Select(it => it.Trader.Name)
            .Order()
            .ToList()
            .ForEach(Console.WriteLine);
    }

    private static void Solved_4()
    {
        Console.WriteLine("\n=== 4. 모든 거래자의 이름을 알파벳순으로 정렬하여 나열하시오 ===");
        transactions
            .DistinctBy(it => it.Trader.Name)
            .Select(it => it.Trader.Name)
            .Order()
            .ToList()
            .ForEach(Console.WriteLine);
    }

    private static void Solved_5()
    {
        Console.WriteLine("\n=== 5. 밀라노에 거래자가 있는가? ===");
        Console.WriteLine(transactions.Any(it => it.Trader.City.Equals("Milan")));
    }

    private static void Solved_6()
    {
        Console.WriteLine("\n=== 6. 케임브리지에 거주하는 거래자의 모든 트랙잭션값을 출력하시오 ===");
        var cambrigeTraders = transactions
            .Where(it => it.Trader.City.Equals("Cambridge"))
            .Select(it => it.Trader.Name)
            .ToList();

        transactions.Where(it => cambrigeTraders.Contains(it.Trader.Name))
            .ToList()
            .ForEach(Console.WriteLine);
    }

    private static void Solved_7()
    {
        Console.WriteLine("\n=== 7. 전체 트랜잭션 중 최대값은 얼마인가? ===");
        int max = transactions.Select(it => it.Value).Aggregate(Math.Max);
        Console.WriteLine(max);
    }

    private static void Solved_8()
    {
        Console.WriteLine("\n=== 8. 전체 트랜잭션 중 최소값은 얼마인가? ===");
        int min = transactions.Select(it => it.Value).Aggregate(Math.Min);
        Console.WriteLine(min);
    }
    
    
}