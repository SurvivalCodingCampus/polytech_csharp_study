namespace CsharpStudy;

public class Word
{
    private string word = "";
    private int size = 0;

    public Word(string word)
    {
        this.word = word;
        size = word.Length;
    }

    public bool IsVowel(int i)
    {
        if (i > size || i < 0) return false;
        return word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u';
        ;
    }

    public bool IsConsonant(int i)
    {
        if (i > size || i < 0) return false;
        return !(word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u');
    }
}