namespace CsharpStudy.LambdaFunc.Trader;

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

    public static void RunLambdaExample(string[] args)
    {
        // 1. 2011년에 일어난 모든 트랜잭션을 찾아 가격 기준 오름차순으로 정리하여 이름을 나열하시오.
        
        transactions.Where(transaction => transaction.Year == 2011)
            .OrderBy(transaction => transaction.Value)
            .Select(transaction => transaction.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);
    }
    
    //-------------------------------------------------------------
    // 2. 거래자가 근무하는 모든 도시를 중복 없이 나열하시오.
    public static void RunCityExample()
    {
        transactions.Select(t => t.Trader.City)
            .GroupBy(city => city) // 각 그룹은 같은 도시 (중복 제거 역할)
            .Select(g => g.Key)
            .OrderBy(city => city)
            .ToList()
            .ForEach(Console.WriteLine); // ForEach는 리턴없음
    }
    //--------------------------------------------------------------
    // 3. 케임브리지에서 근무하는 모든 거래자를 찾아서 이름순으로 정렬하여 나열하시오.

    public static void CambridgeTradersExample()
    {
        transactions
            .Where(t => t.Trader.City == "Cambridge")
            .Select(t => t.Trader.Name)
            .Aggregate(new List<string>(), (acc, name) => {
                if (!acc.Any(n => n == name)) acc.Add(name);
                return acc;
            })
            .OrderBy(n => n)
            .ToList()
            .ForEach(Console.WriteLine);
        
    }
    //-----------------------------------------------------------
    //4. 모든 거래자의 이름을 알파벳순으로 정렬하여 나열하시오

    public static void TraderNamesExample()
    {
        transactions
            .Select(t => t.Trader.Name)    // 이름만 추출
            .OrderBy(n => n)               // 알파벳순 정렬
            .ToList()
            .ForEach(Console.WriteLine);   // 출력
    }
    //-----------------------------------------------------------
    //5. 밀라노에 거래자가 있는가?
    
    public static void MilanTraderExample()
    {
        transactions
            .Where(t => t.Trader.City == "Milan")   // Milan 거래자만 고르기
            .Select(t => t.Trader.Name)             // 이름만 추출
            .OrderBy(n => n)                        // 알파벳순 정렬
            .ToList()
            .ForEach(Console.WriteLine);            // 출력
    }
    //-----------------------------------------------------------
    //6. 케임브리지에 거주하는 거래자의 모든 트랙잭션값을 출력하시요.
    public static void CambridgeValuesExample()
    {
        transactions
            .Where(t => t.Trader.City == "Cambridge")  // 케임브리지 거래자만
            .Select(t => t.Value)                      // 트랜잭션 값만 추출
            .ToList()
            .ForEach(Console.WriteLine);     
    }
    //-----------------------------------------------------------
    //7. 전체 트랜잭션 중 최대값은 얼마인가?
    public static void MaxValueExample()
    {
        Console.WriteLine(
            transactions
                .Select(t => t.Value)   // 모든 값만 추출
                .Max()                  // 최대값 계산
        );
    }
    //-----------------------------------------------------------
    //8. 전체 트랜잭션 중 최소값은 얼마인가?
    public static void MinValueExample()
    {
        Console.WriteLine(
            transactions
                .Select(t => t.Value)   // 모든 값만 추출
                .Min()                  // 최소값 계산
        );
    }
}

