namespace CsharpStudy._2hakgi;

public class Word
{
    private string _word;

    public Word(string word)
    {
        _word = word;
    }

    public bool IsVowel(int i)
    {
        string vowel = "aeiou";
        return vowel.IndexOf(_word.ElementAt(i)) > -1;
    }

    public bool IsConsonant(int i)
    {
        return !IsVowel(i);
    }
}