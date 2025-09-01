namespace CsharpStudy._2hakgi.Assignment;

public class Word
{
    private string _word = "";

    public Word(string word)
    {
        _word = word;
    }

    // i 번째 글자가 모음인지
    public bool IsVowel(int i)
    {   
        // 범위 벗어나는지 확인
        if (i < 0 || i >= _word.Length)
        {
            throw new ArgumentOutOfRangeException("인덱스가 문자열 범위를 벗어났습니다.");
        }

        // 알파벳인지 확인
        char c = _word[i];
        if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
        {
            throw new FormatException("문자가 알파벳이 아닙니다.");
        }
        
        // 소문자로 변경
        c = char.ToLower(c);
        
        // return
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
    }
    
    // i 번째 글자가 자음인지
    public bool IsConsonant(int i)
    {
        return !IsVowel(i);
    }
}