namespace CsharpStudy.Asynchronous.Entities;

public class Crow : Bird
{
    public override async Task<int> CallsAsync()
    {
        for (var i = 0; i < 4; i++)
        {
            await Task.Delay(2000);
            Console.WriteLine("(2000ms) 까마귀 까악");
        }
        
        return 200;
    }
}