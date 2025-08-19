namespace CsharpStudy._2Semester;
// i 번째 글자가 모음인지 알려주는 isVowel() 메서드를 완성하시오
// 영어에서의 모음은 a, e, i, o, u 다섯가지이다
// 영어에는 대문자와 소문자가 있다

public class Word
{
    public string Text { get; set; }


    public Word(string text)
    {
        Text = text;
    }


    public bool IsVowel(int i)
    {
        // word[i]가 'a'와 같은지 확인
        string lowerResult = Text.ToLower();

        return (lowerResult[i] == 'a' || lowerResult[i] == 'e' ||
                lowerResult[i] == 'i' || lowerResult[i] == 'o' ||
                lowerResult[i] == 'u');
    }

    public bool IsConsonant(int i) // 자음 = false , 모음 = true;
    {
        return !IsVowel(i);
    }
}