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
        int length = (word.Text.Length + 1);
        Console.Write("$1 이상 {word.Text.Length} 이하의 숫자를 입력하세요");

        string? line = Console.ReadLine(); // 콘솔 입력 = 문자열로 들어옴 + null 값 포함
        // 유효성 검사 / out : 메서드에 매개변수 전달시, 해당 매개변수가 참조로 전달되로고 지정 키워드
        if (!int.TryParse(line, out int input)) // 문자열 -> 정수로 안전 변환 시도 
        {
            Console.WriteLine("유효한 숫자를 입력하세요.");
            return;
        }

        if (input < 1 || input > word.Text.Length)
        {
            Console.WriteLine($"1 이상 {word.Text.Length} 이하의 숫자를 입력하세요.");
            return;
        }

        // 범위 체크(사용자는 1부터 세니 '-1' 해주기)
        bool isVowel = word.IsVowel(input - 1);
        string result = isVowel ? "모음" : "자음";
        Console.WriteLine($"{input}번째 글자는 '{result}' 입니다");
    }
}