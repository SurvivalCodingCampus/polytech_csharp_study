namespace CaharpStudy._2hakgi;

public class Word
{
    string word = " ";
    
    public Word(string word)
    {
        this.word = word;
    }

    public bool IsVowel(int i) //i번째 글자가 모음인지 알려주는 함수, 모음은 a,e,i,o,u 다섯가지
    {
        char c = char.ToLower(word[i]);
        
        if(i < 0 || i >= word.Length) return false;
        //word[i]가 'a'와 같은지 확인
        if(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') return true;
        return false;
    }

    public bool IsConsonant(int i) // i번째 글자가 자음인지 알려주는 함수
    {
        char c = char.ToLower(word[i]);
        
        if(i < 0 || i >= word.Length) return false;
        //word[i]가 'a'와 같은지 확인
        if(!(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')) return true;
        return false;
        
    }
}
