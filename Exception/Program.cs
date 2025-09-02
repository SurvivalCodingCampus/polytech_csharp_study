namespace Exception;

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
        catch (System.Exception e)
        {
            num = 0;
        }
        
        Console.WriteLine(num);
    }

}