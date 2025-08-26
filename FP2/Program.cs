namespace FP2;

class Program
{
   /* static void Main(string[] args)
    {
        //list 타입
        var items = new List<int> { 1, 2, 3, 4, 5 };
        
        //IEnumerable 타입, 반복자
        var results = items.Where(e => e % 2 == 0);
        
        //list 타입으로 바꾸어줌
        var resultsItems = results.ToList();
        resultsItems.ForEach(Console.WriteLine);
        
        
        items.Where(e => e % 2 == 0).ToList().ForEach(Console.WriteLine);
        
        //합계
        // 1, 2, 3, 4, 5
        //(1 + 2), 3, 4, 5
        //(3+3), 4, 5
        //(6+4), 5
        //15
        int totla = items.Aggregate((a, b) => a + b); //a가 누적값 b가 새로 들어오는 값
        Console.WriteLine(totla);

        int max = items.Aggregate(Math.Max);
        Console.WriteLine(max);
    }*/
}