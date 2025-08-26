namespace FP2;

class Program
{
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
            Console.WriteLine("1번 문제에 대한 답변");
            transactions.Where(transaction => transaction.Year == 2011)
                .OrderBy(transaction => transaction.Value)
                .Select(transaction => transaction.Trader.Name)
                .ToList()
                .ForEach(Console.WriteLine);

            // 2. 거래자가 근무하는 모든 도시를 중복 없이 나열하시오
            Console.WriteLine("\n2번 문제에 대한 답변");
            transactions.Select(transactions => transactions.Trader.City)
                .ToHashSet()
                .ToList()
                .ForEach(Console.WriteLine);
            
            // 3. 케임브리지에서 근무하는 모든 거래자를 찾아서 이름순으로 정렬하여 나열하시오
            Console.WriteLine("\n3번 문제에 대한 답변");
            transactions.Where(transactions => transactions.Trader.City == "Cambridge")
                .Select(transactions => transactions.Trader.Name)
                .OrderBy(name => name)
                .ToList()
                .ForEach(Console.WriteLine);
            
            // 4. 모든 거래자의 이름을 알파벳순으로 정렬하여 나열하시오
            Console.WriteLine("\n4번 문제에 대한 답변");
            transactions.Select(transactions => transactions.Trader.Name)
                .OrderBy(name => name)
                .ToList()
                .ForEach(Console.WriteLine);
            
            // 5. 밀라노에 거래자가 있는가?
            Console.WriteLine("\n5번 문제에 대한 답변");
            if (transactions.Select(transactions => transactions.Trader.City)
                .Any(City => City == "Milan"))
            {
                Console.WriteLine("밀라노에는 거래자가 있습니다.");
            }
            else
            {
                Console.WriteLine("밀라노에는 거래자가 없습니다.");
            }
            
            // 6. 케임브리지에 거주하는 거래자의 모든 트랙잭션값을 출력하시오
            Console.WriteLine("\n6번 문제에 대한 답변");
            transactions.Where(transactions => transactions.Trader.City == "Cambridge")
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.Trader.Name}, {t.Trader.City}, {t.Year}, {t.Value}"));
            
            // 7. 전체 트랜잭션 중 최대값은 얼마인가?
            Console.WriteLine("\n7번 문제에 대한 답변");
            Console.WriteLine(transactions.Select(transactions => transactions.Value)
                .OrderByDescending(Value => Value)
                .ToList()
                .First());
            
                
            // 8. 전체 트랜잭션 중 최대값은 얼마인가?
            Console.WriteLine("\n8번 문제에 대한 답변");
            Console.WriteLine(transactions.Select(transactions => transactions.Value)
                .OrderBy(Value => Value)
                .ToList()
                .First());
                

        }
    }
    
}