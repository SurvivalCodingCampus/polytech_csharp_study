namespace CsharpStudy.Asynchronous.Entities;

public class Parrot : Bird
{
    public override async Task<int> CallsAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            await Task.Delay(1000);
            Console.WriteLine("(1000ms) 앵무 꾸우");
        }
        
        return 200;
    }
}