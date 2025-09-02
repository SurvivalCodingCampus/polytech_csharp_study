namespace CsharpStudy.ExceptionProblem01;

class Program
{
    static void Main(string[] args)
    {
        //------[과제] 예외 Part ------

        int num = 0;

        try
        {
            var numString = "10.5";
            num = int.Parse(numString); // int형이 와야하는데 float가 옴 
            Console.WriteLine(num); // 런타임 에러 
        }
        catch (FormatException e)
        {
            Console.WriteLine("값이 int 범위를 벗어났습니다.");
            Console.WriteLine(e.Message);
        }
        finally // 성공/실패해도 실행됨 
        {
            Console.WriteLine("예외처리 수행완료");
        }

        Console.WriteLine(num);
    }
}