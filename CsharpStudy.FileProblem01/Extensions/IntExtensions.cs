namespace CsharpStudy.FileProblem01.Extensions;

public static class IntExtensions
{
    public static int? MyTryParse(this int value, string numString)
    {
        try
        {
            return int.Parse(numString);
        }
        catch (FormatException e)
        {
            return null;
        }
    }
}