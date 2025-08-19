namespace CsharpStudy.String.Vocals;

public class Word
{
    private readonly char[] _vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

    public Word(string value)
    {
        if (value is null) throw new ArgumentException("You must provide at least a char for Word");
        word = value;
    }

    public string word { get; }

    public char GetChar(int index)
    {
        ValidateIndex(index);

        return word[index];
    }

    public bool IsVowel(int index)
    {
        var c = GetChar(index);
        if (!char.IsLetter(c)) return false;        // No whitespace or mark

        var targetCharacter = c;
        foreach (var vowel in _vowels)
            if (targetCharacter == vowel)           // Or targetCharacter.Equals(vowel)
                return true;

        return false;
        
        // LINQ Expression?
        // return _vowels.Any(vowel => targetCharacter == vowel);
    }

    public bool IsConsonant(int index)
    {
        var c = GetChar(index);
        if (!char.IsLetter(c)) return false;        // No whitespace or mark

        var targetCharacter = c;
        foreach (var vowel in _vowels)
            if (targetCharacter == vowel)
                return false;

        return true;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= word.Length) throw new IndexOutOfRangeException("Index out of range");
    }
}