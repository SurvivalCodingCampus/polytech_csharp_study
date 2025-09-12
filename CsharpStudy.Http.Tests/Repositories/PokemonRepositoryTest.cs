using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Http.Tests.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{

    [Test]
    public async Task GET_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new RemotePokemonApiDataSource(new HttpClient())); 
      var pokemon = await repository.GetPokemonByNameAsync("ditto");
       // repository.GetPokemonByNameAsync("ditto");
        Assert.That(pokemon.Name,  Is.EqualTo("ditto"));
      
    }
}