using CsharpStudy.HTTP.Repositories;

namespace CsharpStudy.HTTP
{
    class Program
    {
        static async Task Main()
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://pokeapi.co") };

            var ds   = new RemotePokemonDataSource(http);
            var repo = new PokemonRepository(ds);

            var p1 = await repo.GetPokemonByNameAsync("pikachu");

            Console.WriteLine(p1 == null
                ? "Not Found"
                : $"{p1.Name} / {p1.SpriteUrl}");  
        }
    }
}