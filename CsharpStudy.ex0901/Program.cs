namespace CsharpStudy.ex0901;

class Program
{
    static void Main(string[] args)
    {
        var numString = "10.5";
        int num;
        try
        {
            num = int.Parse(numString);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            num = 0;
        }
        Console.WriteLine(num);
    } 
}