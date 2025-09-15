using CsharpStudy.HTTP.Repositories;

namespace CsharpStudy.HTTP
{
    class Program
    {
        static async Task Main()
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://pokeapi.co") };
            var dataSource = new RemotePokemonDataSource(http);
            var repo = new PokemonRepository(dataSource);

            var pikachu = await repo.GetPokemonByNameAsync("pikachu");
            Console.WriteLine($"{pikachu.Name} / {pikachu.SpriteUrl}");
        }
    }
}