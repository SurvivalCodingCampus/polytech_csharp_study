namespace CsharpStudy.Async;

class Program
{
    static Task MyTaskAsync()
    {
        Task.Delay(3000)
            .ContinueWith(task => Console.WriteLine("MyTask"));
        return Task.CompletedTask;
    }

    static async Task MyTaskAsync2()
    {
        await Task.Delay(3000);
        Console.WriteLine("MyTask2");
    }

    static async Task<int> GetInt1()
    {
        await Task.Delay(1000);
        return 1;
    }
    static async Task<int> GetInt2()
    {
        await Task.Delay(1000);
        return 2;
    }
    static async Task<int> GetInt3()
    {
        await Task.Delay(1000);
        return 3;
    }
    static async Task<int> GetInt4()
    {
        await Task.Delay(1000);
        return 4;
    }
    static async Task<int> GetInt5()
    {
        await Task.Delay(1000);
        return 5;
    }

    static async Task Main(string[] args)
    {
        List<Task<int>> list = new List<Task<int>>();
        list.Add(GetInt1());
        Console.WriteLine("1초");
        list.Add(GetInt2());
        Console.WriteLine("2초");
        list.Add(GetInt3());
        Console.WriteLine("3초");
        list.Add(GetInt4());
        Console.WriteLine("4초");
        list.Add(GetInt5());
        Console.WriteLine("5초");

        await Task.WhenAll(list);
        Console.WriteLine("모든 작업 완료");
    }

    static async Task AsyncExam()
    {
        Console.WriteLine("MyTask Start");
        // await MyTaskAsync();
        await MyTaskAsync2();
        Console.WriteLine("MyTask End");
    }
    
    // 비동기를 순차 실행
    static async Task AsyncExam2()
    {
        List<int> list = new List<int>();
        list.Add(await GetInt1());
        Console.WriteLine("1초");
        list.Add(await GetInt2());
        Console.WriteLine("2초");
        list.Add(await GetInt3());
        Console.WriteLine("3초");
        list.Add(await GetInt4());
        Console.WriteLine("4초");
        list.Add(await GetInt5());
        Console.WriteLine("5초");
    }

    // 병렬 처리
    static async Task AsyncExam3()
    {
        List<Task<int>> list = new List<Task<int>>();
        list.Add(GetInt1());
        Console.WriteLine("1초");
        list.Add(GetInt2());
        Console.WriteLine("2초");
        list.Add(GetInt3());
        Console.WriteLine("3초");
        list.Add(GetInt4());
        Console.WriteLine("4초");
        list.Add(GetInt5());
        Console.WriteLine("5초");

        await Task.WhenAll(list);
        Console.WriteLine("모든 작업 완료");
    }
}