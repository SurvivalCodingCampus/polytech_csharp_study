namespace CsharpStudy._2hakgi;

class Program
{
    static void Main(string[] args)
    {
        Word word = new Word("ooodle");

        Console.WriteLine(word.IsVowel(2));
        Console.WriteLine(word.IsVowel(0));
        Console.WriteLine(word.IsConsonant(0));
        Console.WriteLine(word.IsConsonant(2));
        
    }
}