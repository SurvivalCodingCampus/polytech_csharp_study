using System.Text;

namespace CsharpStudy.Asset;

class Program
{
    static void Main(string[] args)
    {
        
        // 문자열 처리
        string s1 = "HELLO";
        
        // 일부 떼어내기
        Console.WriteLine(s1.Substring(0, 2)); // HE
        Console.WriteLine(s1.Substring(2)); // LLO
        
        // 일부 치환
        Console.WriteLine(s1.Replace("LL", "XX"));  // HEXXO
        
        // 분리
        string s2 = "1, 2, 3";
        string[] splitNumbers = s2.Split(',');  // ,를 기준으로 분리 ["1", "2", "3"]

        foreach (string s in splitNumbers)
        {
            Console.WriteLine(s);   // 1, 2, 3
        }
        
        // 대소문자 변경
        Console.WriteLine(s1.ToLower());    // 소문자로
        Console.WriteLine(s1.ToUpper());    // 대문자로
        
        // 길이
        string greeting = "Hello, world!";
        int length = greeting.Length;   // 13
        Console.WriteLine(length);
        
        string emptyString = "";
        int emptyLength = emptyString.Length;   //  0
        Console.WriteLine(emptyLength);

        // null
        string n1 = null;
        string n2 = "";
        string n3 = " ";
        string n4 = " \t\n "; // 공백, 탭, 개행 문자
        string n5 = "hello";
        
        Console.WriteLine(string.IsNullOrEmpty(n1));    //true
        Console.WriteLine(string.IsNullOrWhiteSpace(n1));   //true
        Console.WriteLine(string.IsNullOrEmpty(n2));    //true
        Console.WriteLine(string.IsNullOrWhiteSpace(n2));   //true
        Console.WriteLine(string.IsNullOrEmpty(n3));    //false
        Console.WriteLine(string.IsNullOrWhiteSpace(n3));   //true
        Console.WriteLine(string.IsNullOrEmpty(n4));    //false
        Console.WriteLine(string.IsNullOrWhiteSpace(n4));   //true
        Console.WriteLine(string.IsNullOrEmpty(n5));    //false
        Console.WriteLine(string.IsNullOrWhiteSpace(n5));   //false
        
        // 검색
        string s3 = "Java and JavaScript";
        Console.WriteLine(s3.Contains("Java")); // True (포함해?)
        Console.WriteLine(s3.EndsWith("Java")); // False (끝나?)
        Console.WriteLine(s3.IndexOf("Java"));  // 0 (정방향 문자열 탐색 없으면 -1)
        Console.WriteLine(s3.LastIndexOf("Java"));  // 9 (역방향 문자열 탐색)
        
        // 변환
        Console.WriteLine(s3.Trim());   // 좌우 공백 제거
        Console.WriteLine(s3.Replace("and", "or")); // and를 or로 바꾸기
        
        // String Builder
            StringBuilder sb = new StringBuilder();
            
            // 10000번 반복하여 문자열 결합
            for (int i = 0; i < 1000; i++)
            {
                sb.Append("C#");    // 문자열 결합 (내부 버퍼에 추가)
            }
            
            string s4 = sb.ToString();   // 완성된 결과 문자열 얻기
            Console.WriteLine($"생성된 문자열 길이: {s4.Length}");   // 20000
            Console.WriteLine(s4);   // 너무 길어서 출력 생략
            
        // + 연산자를 사용 할 경우 문자열을 결합할 때마다 새로운 객체가 생성됨.
        
        
        
    }
}