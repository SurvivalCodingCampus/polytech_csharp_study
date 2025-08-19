namespace CsharpStudy.Asset;

public class Word
{
    private string word;

    public Word(string w)
    {
        word = w.ToLower();
    }

    public bool IsVowel(int i)
    {
        // i가 0보다 작거나 단어의 길이보다 크거나 같으면 false 
        if (i < 0 || i >= word.Length)
        {
            return false;
        }
        
        return word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u';
    }
    
    public bool IsConsonant(int i)
    {
        if (i < 0 || i >= word.Length)
        {
            return false;
        }
        
        return word[i] != 'a' && word[i] != 'e' && word[i] != 'i' && word[i] != 'o' && word[i] != 'u';
    }
}