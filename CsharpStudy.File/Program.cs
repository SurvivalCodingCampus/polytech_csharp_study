namespace ConsoleApp1;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        const string numString = "10.5";
        int num;

        try
        {
            // 문자열을 double로 변환 시도
            // int를 parse로 변환 할 경우 에러가 발생
            num = int.Parse(numString);
        }
        catch (Exception)
        {
            // 변환 실패 시 num을 0으로 처리
            num = 0;
        }

        Console.WriteLine(num);
    }
}