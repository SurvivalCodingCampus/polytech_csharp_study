using System.Globalization;

namespace CsharpStudy_FP;

class Program
{
    public delegate void OnClick();  // 선언

    public void SetOnClick(OnClick onClick)
    {
        onClick();
    }
    
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        // 람다식
        Func<int, string> myFunc = (age) => $"나는 {age}살입니다.";

        // f(x) = 2x + 3
        Func<int, int> f = x => 2 * x + 3;

        Console.WriteLine(f(10));
        
        Program program = new Program();
        Console.WriteLine(program.f(10));

        OnClick onClick = () =>
        {
            Console.WriteLine("클릭되었습니다.");
        };  // 함수 동작 정의
        
        onClick();  // 얘가 진짜 실행

        Func<int, int, int> myFunc2 = Math.Max;  // 함수끼리 연결 가능, 전달 가능
        
        Console.WriteLine( Math.Max(30, 10));
       
        
        //함수끼리 전달 예시
        program.SetOnClick(NoInputOutputFunc);
        program.SetOnClick(NoInputOutputFunc);
        
        // input, output 없는 함수
        program.SetOnClick(() => { Console.WriteLine("야호"); });


        // int => void
        var list = new List<int> { 1, 2, 3 };
        
        // list.ForEach(e => Console.WriteLine(e)); 아래와 동일
        list.ForEach(Console.WriteLine);
        
        // 이거를
        Func<int, int, int> myFunc3 = (x, y) => x + y;
        // 타입 추론을 활용해서 
        var myFunc4 = (int  x, int y) => x + y;
        var myFunc5 = () => { Console.WriteLine("이건 ?"); };
        var myFunc6 = (string name) => { Console.WriteLine("모지 ?"); };
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