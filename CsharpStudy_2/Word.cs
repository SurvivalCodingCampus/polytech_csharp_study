namespace CsharpStudy_2;

    public class Word 
    {
        string word = "";


        public bool IsVowel(int i)
        {
        if (i < 0 || i >= word.Length) return false; 

        char c = char.ToLower(word[i]); 
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }

        public bool IsConsonant(int i)
        {
            if (i < 0 || i >= word.Length) return false; 

            char c = word[i];
            return char.IsLetter(c) && !IsVowel(i); 
        
        }
    }