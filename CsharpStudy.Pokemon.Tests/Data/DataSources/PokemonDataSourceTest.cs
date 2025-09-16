using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.Mappers;
using NUnit.Framework;

namespace CsharpStudy.Pokemon.Tests.Data.DataSources;

[TestFixture]
[TestOf(typeof(PokemonDataSource))]
public class PokemonDataSourceTest
{

    [Test]
    public async Task GET_A_POKEMON_ASYNC()
    {
        PokemonDataSource dataSource = new PokemonDataSource(new HttpClient());
        Response<PokemonDto> response = await dataSource.GetPokemonAsync("caterpie");
        PokemonDto dto = response.Body;
        DTO.Data.Models.Pokemon pokemon = dto.ToPokemon();
        
        Console.WriteLine(pokemon.ToString());
        
        Assert.That(pokemon.Name, Is.EqualTo("caterpie"));
        Assert.That(pokemon.Abilities.Exists(a => a == "shield-dust"), Is.True);
        Assert.That(pokemon.Abilities.Exists(a => a == "run-away"), Is.True);

    }
}