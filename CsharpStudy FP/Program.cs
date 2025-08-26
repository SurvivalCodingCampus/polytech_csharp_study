using System.Globalization;

namespace CsharpStudy_FP;

class Program
{
    public delegate void Onclick();

    public void SetOnclick(Onclick onclick)
    {
        onclick();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        Func<int, string> myFunc = (age) => $"나는 {age}살입니다";
        Console.WriteLine(myFunc(10));
        
        Func<int,int> f = x => 2 * x + 3;
        
        Console.WriteLine(f(10));
        
        Program program = new Program();
        Console.WriteLine(program.f(10));

        Onclick onclick = () =>
        {
            Console.WriteLine("클릭 되었습니다");
        };
        
        onclick();
        
        Func<int, int, int> myFunc2 = Math.Max;

        Console.WriteLine(Math.Max(30, 10));
        
        Onclick noInputOutputFunc = NoInputOutputFunc;
        program.SetOnclick(NoInputOutputFunc);

        program.SetOnclick(() => { Console.WriteLine("바로 작성"); });
        
        static void Main(string[] args)
        {
            Onclick noInputOutputFunc = NoInputOutputFunc;
            program.SetOnclick(noInputOutputFunc);

            // input, output 없는 함수
            program.SetOnclick(() => { Console.WriteLine("바로 작성"); });

            var list = new List<int> { 1, 2, 3 };
            // int => Console.WriteLine(int)
            list.ForEach(Console.WriteLine);

            // 이거를 Func<int,int,int> myFunc3 = (x, y) => x + y;
            Func<int, int, int> myFunc3 = (x, y) => x + y;
            // 타입 추론도 가능
            var myFunc4 = (int x, int y) => x + y;
            var myFunc5 = () => { Console.WriteLine("이건?"); };
            var myFunc6 = (string name) => { Console.WriteLine("이건?"); };
        }

    }

    static void NoInputOutputFunc()
    {
        Console.WriteLine("인풋 아웃풋 없는 함수임");
    }

    int f(int x)
    {
        return x * 2 + 3;
    }
}