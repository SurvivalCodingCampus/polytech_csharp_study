namespace CsharpStudy._2;

public class Word
{
    private string word = "";

    public Word(string word)
    {
        foreach (var ch in word)
        {
            if (!Char.IsLetter(ch))
            {
                throw new ArgumentException("영어 대소문자 입력");
            }
        }
        this.word = word;
    }

    public bool IsVowel(int i)
    {
        // 대문자의 경우 소문자로 변경
        // Index0f: 문자열/문자 배열에서 특정 문자가 처음으로 나타나는 인덱스 반환. 존재하지 않으면 -1 반환

        if (i < 0 || i >= word.Length)
        {
            throw new ArgumentException("문자열 길이를 벗어남");
        }
        
        string vowel = "aeiou";
        char ch = Char.ToLower(word[i]);
        return vowel.IndexOf(ch) >= 0;
    }

    public bool IsConsonant(int i)
    {
        return !IsVowel(i);
    }
}