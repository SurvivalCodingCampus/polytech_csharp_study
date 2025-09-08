namespace CsharpStudy.Asynchronous.Entities;

public class Sparrow : Bird
{
    public override async Task<int> CallsAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            await Task.Delay(3000);
            Console.WriteLine("(3000ms) 참새 짹짹");
        }

        return 200;
    }
}