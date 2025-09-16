using CsharpStudy.HTTP.Common;
using CsharpStudy.HTTP.DataSources;
using CsharpStudy.HTTP.Repositories;

class Program
{
    static async Task Main()
    {
        var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
        var dataSource = new RemotePokemonDataSource(http);
        var repo = new PokemonRepository(dataSource);

        var (result, data) = await repo.GetByNameAsync("dittooo");

        switch (result)
        {
            case Result.Success:
                break;

            case Result.Failure f when f.Error.Kind == PokemonError.NotFound:
                break;

            case Result.Failure f when f.Error.Kind == PokemonError.Timeout:
                break;

            case Result.Failure f when f.Error.Kind == PokemonError.Network:
                break;

            case Result.Failure f:
                break;
        }
    }
}