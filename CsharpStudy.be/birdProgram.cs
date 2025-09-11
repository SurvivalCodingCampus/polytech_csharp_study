
namespace CsharpStudy.be;

class birdProgram
{
    public static async Task Main(string[] args)
    {
        birdProgram birdProgram =  new birdProgram();
        
        var t1 = birdProgram.PrintString_bird_1();
        var t2 = birdProgram.PrintString_bird_2();
        var t3 = birdProgram.PrintString_bird_3();
        
        await Task.WhenAll(t1, t2, t3);
        
    }

    public async Task<string> bird_1()
    {
        await Task.Delay(1000);
        return "꾸우";
    }
    public async Task<string> bird_2()
    {
        await Task.Delay(2000);
        return "까악";
    }
    public async Task<string> bird_3()
    {
        await Task.Delay(3000);
        return "짹짹";
    }

    public async Task PrintString_bird_1()
    {
        List<String> list = new List<String>();
        for (int i = 0; i < 4; i++)
        {
            list.Add(await bird_1());
            Console.WriteLine(list[i]);
        }
    }
    public async Task PrintString_bird_2()
    {
        List<String> list = new List<String>();
        for (int i = 0; i < 4; i++)
        {
            list.Add(await bird_2());
            Console.WriteLine(list[i]);
        }
    }
    public async Task PrintString_bird_3()
    {
        List<String> list = new List<String>();
        for (int i = 0; i < 4; i++)
        {
            list.Add(await bird_3());
            Console.WriteLine(list[i]);
        }
    }
}