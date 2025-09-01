namespace CsharpStudy.File;

class Program
{
    static void Main(string[] args)
    {
        string text = "안녕 홍길동\n";
        
        System.IO.File.WriteAllText("test.txt", text);  // 알아서 열고 닫아줌
        System.IO.File.WriteAllText("test.txt", text);  // 갈아엎어짐

       System.IO.File.AppendAllText("test.txt", text);  // 뒤에 추가
       System.IO.File.AppendAllText("test.txt", text);
       
       // text = System.IO.File.ReadAllText("test.txt");
       // Console.WriteLine(text);
       
       
       // 읽어오기
       // string[] lines = System.IO.File.ReadAllLines("test.txt");
       // lines.ToList().ForEach(Console.WriteLine);
       
       string totalText = System.IO.File.ReadAllLines("text.txt")
           .Select(line => line.Replace("안녕", "Hello"))
           .Aggregate((a, b) => a + b);
       Console.WriteLine(totalText);

    }
}