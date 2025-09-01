namespace FP2;

class Program
{
    static void study(string[] args)
    {
        List<int> items = new List<int> { 1, 2, 3, 4, 5 };
        
        IEnumerable<int> results=items.Where(e=>e%2==0);

        List<int> resultsItems = results.ToList();
        resultsItems.ForEach(Console.WriteLine);
        
        int total=items.Aggregate((a,b)=>a+b);
        Console.WriteLine(total);

        int max = items.Aggregate(Math.Max);
        Console.WriteLine(max);
    }
}