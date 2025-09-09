namespace CsharpStydy.Async;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task FirstBirdAsync()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("꾸우");
            if (i < 3) await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    static async Task SecondBirdAsync()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("까악");
            if (i < 3) await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }

    static async Task ThirdBirdAsync()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("짹짹");
            if (i < 3) await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
    
    static async Task Main()
    {
        await Task.WhenAll(
            FirstBirdAsync(),
            SecondBirdAsync(),
            ThirdBirdAsync()
        );
    }
    
    
}