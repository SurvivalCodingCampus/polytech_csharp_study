using System.ComponentModel;

namespace CsharpStudy.File;

class Program
{
    static void Main(string[] args)
    {
        string text = "안녕 홍길동\n";

        // 갈아 엎기 > File.WriteAllText(): 텍스트 파일 쓰기
        System.IO.File.WriteAllText("text.txt", text);
        System.IO.File.WriteAllText("text.txt", text);


        // 더하기 > File.AppendAllText(): 텍스트 파일에 내용 추가
        System.IO.File.AppendAllText("text.txt", text);
        System.IO.File.AppendAllText("text.txt", text);

        //text = System.IO.File.ReadAllLines("text.txt");
        //Console.WriteLine(text);
        //string[] lines = System.IO.File.ReadAllLines("text.txt");

        // File.ReadAllLines(): 텍스트 파일을 줄 단위로 읽기
        string totalText = System.IO.File.ReadAllLines("text.txt")
            .Select(line => line.Replace("안녕", "Hello"))
            .Aggregate((a, b) => a + b);
        Console.WriteLine(totalText);
    }
}