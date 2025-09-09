using System.Globalization;

namespace _250908;

class Program
{
    public static async Task FirstBird()
    {
        await Task.Delay(1000);
        Console.WriteLine("꾸우우");
    }

    public static async Task SecondBird()
    {
        await Task.Delay(2000);
        Console.WriteLine("까악");
    }

    public static async Task ThirdBird()
    {
        await Task.Delay(3000);
        Console.WriteLine("짹쨱쨲ㄱ잭");
    }
    static async Task Main(string[] args)
    {
        for (int i = 0; i < 4; i++)
        {
            await FirstBird();
            await SecondBird();
            await ThirdBird();
            Console.WriteLine("================");
        }
        
    }
}