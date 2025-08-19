// See https://aka.ms/new-console-template for more information

namespace CsharpStudy._2ndSemester;

public class Word
{
    public String word = "";
    
    public bool isVowel(int i)
    {
            
        switch (word.ToLower()[i])
        {
            case 'a':
                return true;
            case 'e':
                return true;
            case 'i':
                return true;
            case 'o':
                return true;
            case 'u':
                return true;
            default: return false;
        }
    }

    public bool isConsonant(int i)
    {
        if (isVowel(i) == true)
        {
            return false;
        }
        else if (word.ToLower()[i] - 'a' >=0 && word.ToLower()[i] - 'a' < 26)
        {
            return true;
        }
        else return false;
    }
}