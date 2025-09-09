using System.Runtime.CompilerServices;

namespace CsharpStudy.Asynchronous.Entities;

public abstract class Bird
{
    protected int TimeElapsed = 0;
    public virtual async Task CallsAsync()
    {
        Console.WriteLine("(대략 새가 우는 소리) (0ms)");
        await Task.Delay(0);
    }
    
    public static async Task ProvideTimeoutWithToken(CancellationToken token)
    {
        try
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000, token);
                token.ThrowIfCancellationRequested(); // Cancelled by requested
            }
            
            throw new TimeoutException(); // Exception thrown in 5000ms
        }
        catch (TimeoutException t)
        {
            Console.WriteLine($"Timeout. 5000ms passed; {t.Message}");
            throw;
        }

    }
}