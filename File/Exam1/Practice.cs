namespace File;

public class Practice
{
    //1. 다음과 같은 코드를 작성, 실행 후 runtime error를 발생시키고, 어떤 Exception이 발생하는지 확인
    /*static void Main(string[] args)
    {
        int? result=int.MyTryParse("10.5");
        int value = result ?? 0;
        Console.WriteLine(value);
    }*/
    static void Solution3()
    {
        const string numString = "10.5";
        int value = numString.TryParseInt() ?? 0;
        Console.WriteLine(value);
    }
    
    static void Solution2()
    {
        var numString = "10.5";
        int num;
        int.TryParse(numString, out num);
        Console.WriteLine(num);
    }

    static void Solution1()
    {
        var numString = "10.5";
        int num;
        try
        {
            num = int.Parse(numString);
        }
        catch (FormatException e)
        {
            num = 0;
        }
        Console.WriteLine(num);
    }
    //2. 1에서 작성한 코드를 수정하여 try-catch()문을 사영하여 예외처리 하시오
    //예외가 발생하면 num을 0으로 처리
    
    
}