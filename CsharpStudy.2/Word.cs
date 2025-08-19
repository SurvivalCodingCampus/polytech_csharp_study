namespace CsharpStudy._2;

public class Word
{
    private string word = "";

    public Word(string w)
    {
        word = w;
    }


    public bool IsVowel(int i)
    {
        if (i < 0 || i >= word.Length)
            throw new ArgumentOutOfRangeException(nameof(i), "인덱스가 문자열 범위를 벗어남");
        
        char c = char.ToLower(word[i]); // 소문자로 만들어서 대소문자 구분 없게
        // return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        return "aeiou".Contains(c);  // 모음 중에 포함되어있는지 확인
    }
    
    public bool IsConsonant(int i)
    {
        if (i < 0 || i >= word.Length)
            throw new ArgumentOutOfRangeException(nameof(i), "인덱스가 문자열 범위를 벗어남");
        
        char c = char.ToLower(word[i]);
        return char.IsLetter(c) && !IsVowel(i);  // 문자이면서 자음이 아닌 것
    }
}
