using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace CsharpStudy._2Semester;

class Program
{
    static void Main(string[] args)
    {
        Word word = new Word("String");
        Console.Write("1부터 i번째 글자 중 알기 원하는 번호를 작성해주세요. : ");

        int input = Convert.ToInt32(Console.ReadLine());
        string result = (word.IsVowel((input - 1))) ? "모음" : "자음";

        Console.Write($"{input}번째 글자는 '{result}' 입니다");
    }
}