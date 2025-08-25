namespace CsharpStudy._2Semester;

class Program
{
    static void Main()
    {
        Word w = new Word();
        bool result = w.isVowel(3);
        Console.WriteLine(result);

        bool result2 = w.isConsonant(3);
        Console.WriteLine(result2);

    }
}