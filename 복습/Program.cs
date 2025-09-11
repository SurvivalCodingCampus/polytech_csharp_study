using System.Globalization;

namespace 복습;

class Program
{
    public delegate void MyDelegate(int num);
    
    static void Main(string[] args)
    {
        string? name = null;
        Console.WriteLine(name?.Substring(0, 2)); //안전한 호출 만일 앞이 null이면 터짐
        
        /*List<int> list = new List<int>();
        Action<int> myFunc = (int i) => Console.WriteLine("end");
        MyDelegate myDelegate = (int i) => Console.WriteLine("end");*/
        
        /*
        Program program = new Program();
        myFunc = program.MyFunc;
        list.ForEach(e => Console.WriteLine("end"));
        */
        
        
        List<string> tasks = new List<string>();
        Action myFunc2 = () => Console.WriteLine("Cyphers");
        Action<string> myFunc3 = (string s) => Console.WriteLine("Pyramid");
        tasks.ForEach(s => Console.WriteLine("Pyramid"));
    }
    
    void MyFunc(int i)
    {
        Console.WriteLine("func");
    }
}