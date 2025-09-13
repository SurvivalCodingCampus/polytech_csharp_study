using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.HTTP.Repositories;
using CsharpStudy.HTTP.Models;   // ← 있으면 더 안정적

namespace CsharpStudy.HTTP
{
    class Program
    {
        static async Task Main()
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://pokeapi.co") };

            var ds   = new RemotePokemonDataSource(http);
            var repo = new PokemonRepository(ds);

            var p1 = await repo.GetPokemonByNameAsync("pikachu");   // ← 변수명 p1

            Console.WriteLine(p1 == null
                ? "Not Found"
                : $"{p1.name} / {p1.imageUrl}");
        }
    }
}