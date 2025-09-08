using System.Diagnostics;
using CsharpStudy.Asynchronous.Entities;

namespace CsharpStudy.Asynchronous;

class Program
{
    public static async Task BirdsAllSing()
    {
        var parrot = new Parrot();
        var crow =  new Crow();
        var sparrow = new Sparrow();

        var tasks = new List<Task<int>>()
        {
            parrot.CallsAsync(), crow.CallsAsync(), sparrow.CallsAsync()
        };
        // var results = await Task.WhenAll(tasks);
        await Task.WhenAll(tasks);
    }
    
    static async Task Main(string[] args)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        await BirdsAllSing();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
    }
}