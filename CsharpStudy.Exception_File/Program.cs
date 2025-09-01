namespace CsharpStudy.Exception_File;

class Program
{
    static void Main(string[] args)
    {
        var numString = "10.5";
        int num=int.Parse(numString);
        
        Console.WriteLine(num);
        // FormatException 발생
        // int.Parse()는 정수 문자열만 받아들임
    }
}