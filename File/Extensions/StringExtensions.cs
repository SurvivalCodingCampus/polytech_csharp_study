namespace File.Extensions;

public static class StringExtensions
{
    public static int? TryParseInt(this string numString)
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