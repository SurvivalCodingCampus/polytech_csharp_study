using System.Globalization;

namespace CsharpStudy.Exception;

class Program
{
    static void Main(string[] args)
    {
        var numstring = "10.5";
        
        try
        {
            int num = int.Parse(numstring);
            Console.WriteLine(num);
        }

        catch (FormatException e)
        {
            int num = 0;
            Console.WriteLine(num);
        }
    }
}


