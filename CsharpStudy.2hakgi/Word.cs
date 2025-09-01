namespace CsharpStudy._2hakgi;

public class Word
{
    private readonly string _word;

    public Word(string word)
    {
        _word = word;
    }

    public bool IsVowel(int i)
    {
        var vowel = "aeiou";
        return vowel.IndexOf(_word.ToLower().ElementAt(i)) > -1;
    }

    public bool IsConsonant(int i)
    {
        return !IsVowel(i);
    }
}