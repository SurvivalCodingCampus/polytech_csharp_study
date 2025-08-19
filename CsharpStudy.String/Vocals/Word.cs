namespace CsharpStudy.String.Vocals;

public class Word
{
    private readonly char[] _vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

    public Word(string value)
    {
        if (value is null) throw new ArgumentException("You must provide at least a char for Word");
        text = value;
        
        // The way compliant with .NET Guideline
        // if (value is null) throw new System.ArgumentNullException(nameof(value));
    }

    public string text { get; }

    public char GetChar(int index)
    {
        ValidateIndex(index);

        return text[index];
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
        
        // SHORTEST WAY
        // true when exists, false when doesn't.
        // return System.Array.IndexOf(_vowels, c) >= 0;
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
        if (index < 0 || index >= text.Length) throw new System.ArgumentOutOfRangeException(nameof(index), "Index out of range");
    }
}