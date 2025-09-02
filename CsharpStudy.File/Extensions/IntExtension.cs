namespace CsharpStudy.File.Extension;

public static class IntExtension
{
    public static int? MyTyeParse(this int value, string numString)
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