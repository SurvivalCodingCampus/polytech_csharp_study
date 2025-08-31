namespace CsharpStudy.Func;

class Program
{
    public delegate void OnClick();

    public void SetOnClick(OnClick onClick)
    {
        onClick();
    }
    
    static void Main(string[] args)
    {
        Console.Write("Hello World!");
        Func<int, string> myFunc = age => $"나는 {age}살입니다.";
        
        Func<int, int> f = x => 2 * x + 3;

        Console.WriteLine(f(10));

        OnClick noInputOutputFunc = NoInputOutputFunc;
        program.SetOnClick(noInputOutputFunc);

        var list = new List<int>{1, 2, 3};
        list.ForEach(Console.WriteLine);
        
        //Func 람다 형태를 타입 추론을 활용하여 var 표기 (대입자 타입은 지정을 해줘야함 ex) int )
        var myFunc1 = (int x, int y) => x + y;
        
    }

    static void NoInputOutputFunc()
    {
        Console.WriteLine("인풋 아웃풋 없음");
    }
}