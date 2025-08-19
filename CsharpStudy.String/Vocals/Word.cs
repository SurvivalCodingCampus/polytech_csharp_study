namespace CsharpStudy.String.Vocals;

public class Word
{
    private char[] _vowels =  new char[] { 'a', 'e', 'i', 'o', 'u' };
    public string word { get; }

    public Word(string value)
    {
        this.word = value;
    }

    public char GetChar(int index)
    {
        Index_VerificationCheck(index);
        
        return word[index];
    }

    public bool IsVowel(int index)
    {
        Index_VerificationCheck(index);
        
        char targetCharacter = word[index];
        foreach (char vowel in _vowels)
        {
            if (targetCharacter == vowel) return true;
        }
        
        return false;
    }
    
    public bool IsConsonant(int index)
    {
        return !IsVowel(index);
    }

    private void Index_VerificationCheck(int index)
    {
        if (index < 0 || index >= word.Length) throw new IndexOutOfRangeException("Index out of range");
    }
}