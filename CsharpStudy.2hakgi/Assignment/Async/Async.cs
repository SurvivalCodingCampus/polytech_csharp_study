namespace CsharpStudy._2hakgi.Assignment;

public class Async
{
    static async Task Bird(string sound, int seconds, int repeatCnt)
    {
        for (int i = 0; i < repeatCnt; i++)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} {sound}");
            if (i < repeatCnt - 1)
            {
                await Task.Delay(seconds * 1000);
            }
        }
    }
    static async Task Main(string[] args)
    {
        List<Task> birdList = new List<Task>();
        birdList.Add(Bird("꾸우",1,4));
        birdList.Add(Bird("까악",2,4));
        birdList.Add(Bird("짹짹",3,4));

        await Task.WhenAll(birdList);
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} 완료");
    }
}