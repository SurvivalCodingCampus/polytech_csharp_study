namespace CsharpStudy._2;

public class Word
{
    // 필드를 readonly로 두어 불변성을 높이고 생성자에서 ArgumentNullException으로 방어해 주세요.
    private readonly string _word;

    public Word(string w)
    {
        _word = w ?? throw new ArgumentNullException(nameof(w));
    }


    public bool IsVowel(int i)
    {
        if (i < 0 || i >= _word.Length)
            throw new ArgumentOutOfRangeException(nameof(i), "인덱스가 문자열 범위를 벗어남");
        
        char c = char.ToLower(_word[i]); // 소문자로 만들어서 대소문자 구분 없게
        // return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        return "aeiou".Contains(c);  // 모음 중에 포함되어있는지 확인
    }
    
    public bool IsConsonant(int i)
    {
        if (i < 0 || i >= _word.Length)
            throw new ArgumentOutOfRangeException(nameof(i), "인덱스가 문자열 범위를 벗어남");
        
        char c = char.ToLower(_word[i]);
        return char.IsLetter(c) && !IsVowel(i);  // 문자이면서 자음이 아닌 것
    }
}
