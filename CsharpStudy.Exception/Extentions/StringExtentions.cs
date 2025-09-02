namespace CsharpStudy.Exception.Extentions;

public static class StringExtentions
{
    public static int TryParseInt(this string str)
    {
        try
        {
            return int.Parse(str);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
            return 0;
        }
    }
}