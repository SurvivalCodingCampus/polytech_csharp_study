namespace CsharpStudy;

public class Word
{
    private string word = "";
    public Word(string word)
    {
        this.word = word;
    }

    public bool isVowel(int i)
    {
        return word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u';;
    }

    public bool isConsonant(int i)
    {
        return !(word[i] == 'a' || word[i] == 'e' || word[i] == 'i'  || word[i] == 'o' || word[i] == 'u');
    }
}