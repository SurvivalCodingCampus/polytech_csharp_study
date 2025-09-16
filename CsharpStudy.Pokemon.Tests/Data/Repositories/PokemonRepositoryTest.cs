using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DTO.Data.Common;
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
        
        Result<DTO.Data.Models.Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("dittooo");

        Console.WriteLine(result);
        
        switch (result)
        {
            case Result<DTO.Data.Models.Pokemon, PokemonError>.Success success:
                Console.WriteLine($"Pokemon Name: {success._Data.Name}");
                Console.WriteLine($"Sprite URL: {success._Data.OfficialArtFront}");
                Assert.Pass();
                break;
            case Result<DTO.Data.Models.Pokemon, PokemonError>.Error error:
                switch (error._Error)
                {
                    case PokemonError.NotFound:
                        Console.WriteLine($"Data couldn't be found: {error._Error}");
                        break;
                    case PokemonError.NetworkTimeout:
                        Console.WriteLine($"TIMEOUT: {error._Error}");
                        break;
                    case PokemonError.AuthenticationFailed:
                        Console.WriteLine($"Not authorized to access: {error._Error}");
                        break;
                    case PokemonError.Unknown:
                        Console.WriteLine($"Unknown error: {error._Error}");
                        break;
                }
                Assert.Fail();
                break;
        }
        
        // Assert.That(result.Name, Is.EqualTo("pidgeot"));
        // Assert.That(result.Abilities.Exists(a => a == "keen-eye"), Is.True);
        // Assert.That(result.Abilities.Exists(a => a == "big-pecks"), Is.True);
    }
}