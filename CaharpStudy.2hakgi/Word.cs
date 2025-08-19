namespace CaharpStudy._2hakgi;

public class Word
{
    public Word(string word)
    {
        this.word = word;
    }

    string word = " ";

    public bool IsVowel(int i) //i번째 글자가 모음인지 알려주는 함수, 모음은 a,e,i,o,u 다섯가지
    {
        //word[i]가 'a'와 같은지 확인
        return word[i] == 'a';
    }

    public bool IsConsonant(int i) // i번째 글자가 자음인지 알려주는 함수
    {
        
    }
}
