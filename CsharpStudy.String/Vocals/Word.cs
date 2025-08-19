namespace CsharpStudy.String.Vocals;

public class Word
{
    private readonly char[] _vowels = new[] { 'a', 'e', 'i', 'o', 'u' };

    public Word(string value)
    {
        word = value;
    }

    public string word { get; }

    public char GetChar(int index = 0)
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
        if (index < 0 || index >= word.Length) throw new System.ArgumentOutOfRangeException(nameof(index), "Index out of range");
    }
}