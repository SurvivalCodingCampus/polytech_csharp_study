using CsharpStudy.File.Extensions;

namespace CsharpStudy.File.Exam1;

public class ExceptionExam
{
    static void Main(string[] args)
    {
        const string numString = "10.5";
        int value = numString.TryParseInt() ?? 0;
        Console.WriteLine(value);
    }

    static void Solution2()
    {
        var numString = "10.5";
        int num;    // 0
        int.TryParse(numString, out num);
        Console.WriteLine(num);
    }

    static void Solution1()
    {
        var numString = "10.5";
        int num;
        try
        {
            num = int.Parse(numString);
        }
        catch (FormatException e)
        {
            num = 0;
        }

        Console.WriteLine(num);
    }
}