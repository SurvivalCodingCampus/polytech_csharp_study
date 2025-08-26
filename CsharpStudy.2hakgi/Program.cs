using System.Diagnostics;
using System.Text;

namespace CsharpStudy._2hakgi;

class Program
{
    // static void Main(string[] args)
    // {
    //     string greeting = "Hello";
    //
    //     Console.WriteLine(greeting.Replace("H", "J"));
    //     Console.WriteLine(greeting);
    // }

    private const string sss = "lo";
    private static string sss2 = "lo";
    
    static void StringQuiz()
    {
        string str1 = "hello";

        string str3 = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
        // Console.WriteLine(str1.Equals(str3));
        Console.WriteLine(ReferenceEquals(str1, str3));

        string str4 = "hel" + "lo";
        Console.WriteLine(ReferenceEquals(str1, str4));

        string str5 = "hel" + GetLo();
        Console.WriteLine(ReferenceEquals(str1, str5));
    }
    
    static string GetLo() => "lo";

    static void Instance()
    {
        Hero hero1 = new Hero(name: "홍길동", 100);
        Hero hero2 = new Hero(name: "홍길동", 100);

        Console.WriteLine(hero1 == hero2);
        Console.WriteLine(hero1.GetHashCode() == hero2.GetHashCode());
        Console.WriteLine(hero1.Equals(hero2));
        Console.WriteLine(object.ReferenceEquals(hero1, hero2));
    }

    static void StringPool()
    {
        string s1 = "Hello";
        Console.WriteLine(s1.GetHashCode());
        string s2 = "Hello";
        Console.WriteLine(s2.GetHashCode());
    }

    static void StringVsStringBuilder()
    {
        // 동적 생성
        string s1 = "Hello";
        Console.WriteLine(s1.GetHashCode());
        s1 = s1 + "World";
        Console.WriteLine(s1.GetHashCode());

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 100000; i++)
        {
            // count++;
            // s1 += "!";   // 3.47
            sb.Append("!"); // 0.0004
        }

        stopwatch.Stop();
        Console.WriteLine($"끝!! {stopwatch.Elapsed.TotalSeconds}");

        // Console.WriteLine(s1 + " World");
        // Console.WriteLine($"{s1} World");
    }
}