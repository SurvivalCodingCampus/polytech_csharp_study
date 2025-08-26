using System.Globalization;

namespace FP2.Trader;

public class Trader // 거래자(사람) 
{
    public string Name { get; set; } // 거래자 이름 
    public string City { get; set; } // 거래 도시 

    public Trader(string name, string city) // 거래자 생성자 
    {
        Name = name;
        City = city;
    }
}

public class Transaction // 거래 
{
    public Trader Trader { get; set; } // 거래자가 누구인지 확인 (거래자에 의해 발생) 
    public int Year { get; set; } // 거래 연도 
    public int Value { get; set; } // 거래 금액 

    public Transaction(Trader trader, int year, int value) // 거래 생성자 
    {
        Trader = trader;
        Year = year;
        Value = value;
    }
}

public class MainClass
{
    public static List<Transaction> transactions = new List<Transaction> // 거래 리스트 
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
        // 1. 2011년에 일어난 모든 트랜잭션을 찾아 / 가격 기준/ 오름차순으로 정리/하여 이름을 나열/하시오
        Console.WriteLine("-------------------[ 문제 1 ]---------------------");
        transactions.Where(transaction => transaction.Year == 2011)
            .OrderBy(transaction => transaction.Value) // 오름차순 정렬  vs 내림차순 정렬 [OrderByDescending]
            .Select(transaction => transaction.Trader.Name)
            .ToList()
            .ForEach(Console.WriteLine);


        // 2. 거래자가 근무하는 /모든 도시를 /중복 없이 나열/하시오
        Console.WriteLine("-------------------[ 문제 2 ]---------------------");
        transactions
            .Select(t => t.Trader.City)
            .ToHashSet()
            .ToList()
            .ForEach(Console.WriteLine);


        // 3. 케임브리지에서 근무하는 모든 거래자를/ 찾아서 이름순으로 정렬하여/ 나열하시오
        Console.WriteLine("-------------------[ 문제 3 ]---------------------");
        transactions.Where(transactions => transactions.Trader.City == "Cambridge")
            .OrderBy(transaction => transaction.Trader.Name)
            .Select(transaction => transaction.Trader.Name)
            .ToHashSet()
            .ToList()
            .ForEach(Console.WriteLine);


        // 4. 모든 거래자의 이름을 알파벳순으로 정렬하여 나열하시오
        Console.WriteLine("-------------------[ 문제 4 ]---------------------");
        transactions
            .OrderBy(transactions => transactions.Trader.Name)
            .Select(t => t.Trader.Name)
            .ToHashSet()
            .ToList()
            .ForEach(Console.WriteLine);


        // 5. 밀라노에 거래자가 있는가?
        Console.WriteLine("-------------------[ 문제 5 ]---------------------");
        bool result = transactions.Any(transaction => transaction.Trader.City == "Milan");
        Console.WriteLine(result);


        // 6. 케임브리지에 거주하는 거래자의/ 모든 트랙잭션값을 /출력하시오
        Console.WriteLine("-------------------[ 문제 6 ]---------------------");
        transactions.Where(transactions => transactions.Trader.City == "Cambridge")
            .OrderBy(transaction => transaction.Value)
            .Select(transactions => transactions.Value)
            .ToList()
            .ForEach(Console.WriteLine);


        // 7. 전체 트랜잭션 중 최대값은 얼마인가?
        Console.WriteLine("-------------------[ 문제 7 ]---------------------");
        int maxResult = (transactions.Max(transaction => transaction.Value));
        Console.WriteLine(maxResult);


        // 8. 전체 트랜잭션 중 최소값은 얼마인가?
        Console.WriteLine("-------------------[ 문제 8 ]---------------------");
        int minResult = (transactions.Min(transaction => transaction.Value));
        Console.WriteLine(minResult);
        Console.WriteLine("-------------------------------------------------");
    }
}
// var cities = transactions
//     .Select(t => t.Trader.City)
//     .ToHashSet()      // 중복 자동 제거
//     .ToList();
//
// Console.WriteLine(string.Join(", ", cities));

// C# LINQ에서 제공되는 대표적인 고계 함수
// Where : 조건에 맞는 데이터 필터링. 조건문 필터링 (for, if 조합과 동일한 역할).
// Select : 데이터를 변환. 변환 (예: x → x * 2).
// ToHashSet(): Set으로 변환 → 중복 제거.
// ForEach : 모든 요소 순환. 
// Aggregate : 요소들을 하나로 줄임 (예: 합계, 평균). 반복적으로 줄여 하나의 값 생성.
// Any : 특정 조건을 만족하는 요소가 있는지 확인. 조건에 맞는 값이 존재하는지 확인.