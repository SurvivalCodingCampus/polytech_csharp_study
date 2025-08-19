namespace CsharpStudy._2Semester;

public class Word
{
    string word = "cshArp";

    public bool isVowel(int i)
    {
        if (i < 0 || i >= word.Length)
        {
            return false;
        }

        char c = char.ToLower(word[i]);
        string vowel = "aeiou";
        return vowel.Contains(c); //문자열 or 컬렉션에서 특정 요소 찾을 때 사용 메서드
    }
}