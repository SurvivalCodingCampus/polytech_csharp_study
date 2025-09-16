using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Pokemon.Tests.Data.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{

    [Test]
    public async Task GET_A_POKEMON_ON_REPOSITORY_ASYNC()
    {
        PokemonRepository repository = new PokemonRepository(new PokemonDataSource(new HttpClient()));
        DTO.Data.Models.Pokemon result = await repository.GetPokemonByNameAsync("pidgeot");

        Console.WriteLine(result.ToString());
        
        Assert.That(result.Name, Is.EqualTo("pidgeot"));
        Assert.That(result.Abilities.Exists(a => a == "keen-eye"), Is.True);
        // Assert.That(result.Abilities.Exists(a => a == "big-pecks"), Is.True);
    }
}