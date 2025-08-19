namespace CaharpStudy._2hakgi;

class Program
{
    static void Main(string[] args)
    {
        
        //동적생성
        string s1 = "HELLO";
        Console.WriteLine(s1.GetHashCode());
        s1 += "World";
        Console.WriteLine(s1.GetHashCode());
        
        Console.WriteLine(s1.Replace("LL", "XX"));
    }
}