namespace CsharpStudy._2hakgi;

internal class Program
{
    private static void Main(string[] args)
    {
        var word = new Word("ooodle");

        Console.WriteLine(word.IsVowel(2));
        Console.WriteLine(word.IsVowel(0));
        Console.WriteLine(word.IsConsonant(0));
        Console.WriteLine(word.IsConsonant(2));
    }
}