using System.Runtime.CompilerServices;

namespace CsharpStudy.Asynchronous.Entities;

public abstract class Bird
{
    public virtual async Task<int> CallsAsync()
    {
        await Task.Delay(0);
        Console.WriteLine("(대략 새가 우는 소리) (0ms)");
        return 1;
    }
    
    public static async Task<int> ProvideTimeoutWithToken(CancellationToken token)
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

        return 200; // unreachable
    }
}