namespace FP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Func<int, string> myFunc = age => $"나는 {age}살입니다";
        
        Func<int, int> f = x => 2 * x + 3;
        
        Console.WriteLine(f(10));
        
        Program program = new Program();
        Console.WriteLine(program.f(10));

        OnClick onClick = () =>
        {
            Console.WriteLine("클릭 되었습니다");
        };
        onClick();

        Func<int, int, int> myFunc2 = Math.Max;
        
        Console.WriteLine(Math.Max(30, 10));

        program.SetOnClick(NoInputOutputFunc);
        
        OnClick noInputOutputFunc = NoInputOutputFunc;
        program.SetOnClick(noInputOutputFunc);

        program.SetOnClick(() => { Console.WriteLine("바로 작성"); });
        
        var list=new List<int>{1,2,3};
        list.ForEach(Console.WriteLine);
        
        Func<int, int, int> myFunc3 = (x, y) => x+ y;

        var myFunc4 = (int x, int y) => x + y;
        var myFunc5 = () => { Console.WriteLine("이건?"); };
        var myFunc6 = (string name) => { Console.WriteLine("이건?"); };

    }

    static void NoInputOutputFunc()
    {
        Console.WriteLine("인풋 아웃풋 없는 함수");
    }

    int f(int x)
    {
        return 2 * x + 3;
    }
}