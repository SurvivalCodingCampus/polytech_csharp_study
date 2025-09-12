using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;
using NUnit.Framework;

namespace CsharpStudy.HTTP.Tests.DataSources;

[TestFixture]
[TestOf(typeof(PokemonApiDataSource))]
public class PokemonApiDataSourceTest
{

    [Test]
    public async Task GET_ONE_POKEMON_TEST()
    {
        IPokemonApiDataSource<Pokemon> dataSource = new PokemonApiDataSource(new HttpClient());
        Response<Pokemon> response = await dataSource.GetPokemonAsync("charizard");

        Console.WriteLine(response.Body.Sprites.OfficialArtwork);
        Console.WriteLine(response.Body.Sprites.OfficialArtwork.OfficialArtworkUrl);
        
        Assert.That(response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Body.Name, Is.EqualTo("charizard"));
    }
}