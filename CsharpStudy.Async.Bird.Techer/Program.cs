namespace CsharpStudy.Async.Bird.Techer;


public class Bird
{
    public Bird(int time, string sound)
    {
        Time = time;
        Sound = sound;
    }

    public int Time { get; private set; }
    public string Sound { get; private set; }


    public async Task CryAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            Console.WriteLine(Sound);
            await Task.Delay(Time);
        }
    }
}



class Program
{
    static async Task Main(string[] args)
    {
        Bird bird1 = new Bird(1000, "꾸우");
        Bird bird2 = new Bird(2000, "까악");
        Bird bird3 = new Bird(3000, "짹짹");

        // 동시출발 
        bird1.CryAsync();
        bird2.CryAsync();
        bird3.CryAsync();
        
        List<Bird> birds = new List<Bird>
        {
            bird1, bird2, bird3
        };
        
        
        //await Task.WhenAll(birds.Select(bird => bird.CryAsync()));
        // await Task.WhenAll(
        //     bird1.CryAsync(),
        //     bird2.CryAsync(),
        //     bird3.CryAsync()
        //     );
        
        
        // 10초 후에 다물어
        await Task.Delay(10000);
    }
}