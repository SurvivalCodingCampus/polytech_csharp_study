using System;
namespace CsharpStudy.Exception;

class Program
{
    static void Main(string[] args)
    {
        var numString = "10.5";
        int num;

        try
        {
            num = int.Parse(numString);
        }
        catch (System.Exception) // Exception을 클래스가 아니라 네임스페이스로 해석해 충돌 오류 떠서 수정
        {
            num = 0;
        }

        Console.WriteLine(num);
    }
}