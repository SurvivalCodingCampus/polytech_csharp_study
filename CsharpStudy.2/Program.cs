using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace CsharpStudy._2;

/*class Program
{
    static void Main(string[] args)
    {
        Word w = new Word("Hello");
        Console.WriteLine(w.IsVowel(1)); // true (e)
        Console.WriteLine(w.IsVowel(0)); // false (H)
        Console.WriteLine(w.IsVowel(4)); // true (o)
        
        /*Hero hero1 = new Hero(name: "홍길동");
        Hero hero2 = new Hero(name: "홍길동");

        Console.WriteLine(hero1 == hero2);
        Console.WriteLine(hero1.GetHashCode()==hero2.GetHashCode());
        Console.WriteLine(hero1.Equals(hero2));
        Console.WriteLine(object.ReferenceEquals(hero1, hero2));
    }



    static void StringPool()
    {
        string s1 = "HELLO";  // 동적으로 생김(new) 안 해도 생김
        Console.WriteLine(s1.GetHashCode());
        
        string s2 = "HELLO";
        Console.WriteLine(s2.GetHashCode());
        
    }

    public static string GetLo()
    {
        return "LO";
    }
    
    
    static void String_vs_StringBuilder()
    {
        string s1 = "HELLO";  // 동적으로 생김(new) 안 해도 생김
        Console.WriteLine(s1.GetHashCode());
        s1 += " World";
        Console.WriteLine(s1.GetHashCode());
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 100000; i++)
        {
            sb.Append(i); // 0.0018208초
        }
        stopwatch.Stop();
        
        Console.WriteLine($"끝 {stopwatch.Elapsed.TotalSeconds}");
        //Console.WriteLine(s1 + " World");
        //Console.WriteLine($"{s1} World");
    }
}*/