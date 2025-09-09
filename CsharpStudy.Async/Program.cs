using System.Diagnostics;

namespace CsharpStudy.Async;

class Program
{
    static async Task Sec_1()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine("꾸우");
    }

    static async Task Sec_2()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        Console.WriteLine("까악");
    }

    static async Task Sec_3()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        Console.WriteLine("쨱짹");
    }

    static async Task Run()
    {
        await Sec_1();
        await Sec_1();
        await Sec_1();
        await Sec_1();
    }

    static async Task Run2()
    {
        await Sec_2();
        await Sec_2();
        await Sec_2();
        await Sec_2();
    }

    static async Task Run3()
    {
        await Sec_3();
        await Sec_3();
        await Sec_3();
        await Sec_3();
    }

    static async Task Timer()
    {
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 1; i <= 13; i++)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine(sw);
        }

    }

    static async Task Main(string[] args)
    {
        List<Task> tasks = new List<Task>()
        {
            Run(), Run2(), Run3(), Timer()
        };
        
        await Task.WhenAll(tasks);
    }
}