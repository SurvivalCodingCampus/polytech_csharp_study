namespace CsharpStudy._2hakgi.String;

public class Word
{
    private readonly string _word;

    public Word(string word)
    {
        _word = word;
    }

    public bool IsVowel(int i)
    {
        return "aeiouAEIOU".Contains(_word[i]);
    }

    public bool IsConsonant(int i)
    {
        return !IsVowel(i);
    }
}
