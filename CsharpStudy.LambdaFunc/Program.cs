using CsharpStudy.LambdaFunc.Trader;

namespace CsharpStudy.LambdaFunc;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("연습문제1");
        MainClass.RunLambdaExample(args);
        
        Console.WriteLine("연습문제2");
        MainClass.RunCityExample();
        
        Console.WriteLine("연습문제3");
        MainClass.CambridgeTradersExample();
        
        Console.WriteLine("연습문제4");
        MainClass.TraderNamesExample();
        
        Console.WriteLine("연습문제5");
        MainClass.MilanTraderExample();
        
        Console.WriteLine("연습문제6");
        MainClass.CambridgeValuesExample();
        
        Console.WriteLine("연습문제6");
        MainClass.MaxValueExample();
    }
}