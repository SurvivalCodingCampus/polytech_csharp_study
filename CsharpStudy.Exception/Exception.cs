namespace CsharpStudy.Exception;
using System;

public class Exception
{
    static void Main(string[] args)
    {
        var numString = "10.5";
        int num;
        try
        {
            num = int.Parse(numString);
            Console.WriteLine(num);
        }
        catch (FormatException e)
        {
            num = 0;
        }
    }
}
/*
@30328
throw new FormatException(SR.Format(SR.Format_InvalidStringWithValue, value.ToString()));

the input string '10.5' was not in a correct format
 */