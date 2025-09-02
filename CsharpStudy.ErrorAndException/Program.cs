namespace CsharpStudy.ErrorAndException;

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
        catch (FormatException formatEx)
        {
            Console.WriteLine("You tried parse a number to the wrong format; returns 0");
            num = 0;
        }
        
        // Unhandled exception. System.FormatException: The input string '10.5' was not in a correct format.
        //   at System.Number.ThrowFormatException[TChar](ReadOnlySpan`1 value)
        //   at System.Int32.Parse(String s)
        //   at CsharpStudy.ErrorAndException.Program.Main(String[] args) in C:\_Workplace\polytech_csharp_study\CsharpStudy.ErrorAndException\Program.cs:line 8

        // "The input string '10.5'" : possibly double
        // "was not in a CORRECT FORMAT" : not int; should double
        Console.WriteLine(num);
    }
}