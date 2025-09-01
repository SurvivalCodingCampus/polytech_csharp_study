namespace CsharpStudy.File;

class Program
{
    static void Main(string[] args)
    {
        
        string text = "안녕 홍길동\n";
        
        // 갈아 엎기
        System.IO.File.WriteAllText("text.txt", text);
        System.IO.File.WriteAllText("text.txt", text);
        
        // 더하기
        System.IO.File.AppendAllText("text.txt", text);
        System.IO.File.AppendAllText("text.txt", text);
        
        // text = System.IO.File.ReadAllText("text.txt");
        // Console.WriteLine(text);
        
        // string[] lines = System.IO.File.ReadAllLines("text.txt");
        string totalText = System.IO.File.ReadAllLines("text.txt")
            .Select(line => line.Replace("안녕", "Hello"))
            .Aggregate((a, b) => a + b);
        Console.WriteLine(totalText);
        
            // .ForEach(Console.WriteLine);
    }
}