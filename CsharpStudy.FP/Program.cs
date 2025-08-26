namespace CsharpStudy.FP;

class Program
{
    public delegate void OnClick();

    public void SetOnClick(OnClick onClick)
    {
        onClick();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // 람다식
        Func<int, string> myFunc = age => $"나는 {age}살입니다";
        Console.WriteLine(myFunc(10));

        // f(x) = 2x + 3
        // f(10)
        Func<int, int> f = x => 2 * x + 3;

        Console.WriteLine(f(10));

        Program program = new Program();
        Console.WriteLine(program.f(10));

        OnClick onClick = () => { Console.WriteLine("클릭 되었습니다"); };

        onClick();

        // input, output 이 동일하면 함수 레퍼런스 그대로 대입
        Func<int, int, int> myFunc2 = Math.Max;

        Console.WriteLine(Math.Max(30, 10));

        program.SetOnClick(NoInputOutputFunc);

        OnClick noInputOutputFunc = NoInputOutputFunc;
        program.SetOnClick(noInputOutputFunc);

        // input, output 없는 함수
        program.SetOnClick(() => { Console.WriteLine("바로 작성"); });

        var list = new List<int> { 1, 2, 3 };
        // int => void
        list.ForEach(Console.WriteLine);
        
        // 이거를 
        Func<int, int, int> myFunc3 = (x, y) => x + y;
        // 타입 추론을 활용해서
        var myFunc4 = (int x, int y) => x + y;
        var myFunc5 = () => { Console.WriteLine("이건?"); };
        var myFunc6 = (string name) => { Console.WriteLine("이건?"); };
    }

    static void NoInputOutputFunc()
    {
        Console.WriteLine("인풋 아웃풋 없는 함수임");
    }

    int f(int x)
    {
        return 2 * x + 3;
    }
}