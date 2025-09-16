using CsharpStudy.ResultPattern.Common;
using CsharpStudy.ResultPattern.DataSources;
using CsharpStudy.ResultPattern.Repositories;

class Program
{
    static async Task Main()
    {
        var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
        var dataSource = new RemoteSubwayDataSource(http);
        var repo = new SubwayRepository(dataSource);

        Console.Write("역 이름: ");
        var station = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(station)) station = "서울";

        var (result, arrivals) = await repo.GetArrivalsAsync(station);

        switch (result)
        {
            case Result.Failure f when f.Error.Kind == SubwayError.NotFound:
                Console.WriteLine("Not found");
                break;

            case Result.Failure f when f.Error.Kind == SubwayError.Timeout:
                Console.WriteLine("Timeout");
                break;
        }
    }
}