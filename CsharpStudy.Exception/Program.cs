namespace CsharpStudy.Exception;

class Program
{
    static void Main(string[] _)
    {
        var numString = "10.5"; // 소수점 문자열
        int num = int.Parse(numString); 
        Console.WriteLine(num); // 도달하지 못함
    }
}