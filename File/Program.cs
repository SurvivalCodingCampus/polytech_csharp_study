namespace File;

class Program
{
    static void Main(string[] args)
    {
        string text = "안녕 홍길동\n";
            
            System.IO.File.WriteAllText("text.txt", text);
            System.IO.File.WriteAllText("text.txt", text);
            
            System.IO.File.AppendAllText("text.txt", text);
            System.IO.File.AppendAllText("text.txt", text);
            
            string totalText = System.IO.File.ReadAllLines("text.txt")
                .Select(line=>line.Replace("안녕","Hello"))
                .Aggregate((a,b)=>a+b);
            Console.WriteLine(totalText);
            
    }
}