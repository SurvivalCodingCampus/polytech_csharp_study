using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DTO_Mapper.DataSources;
using CsharpStudy.DTO_Mapper.Repositories;
using NUnit.Framework;

namespace CsharpStudy.DTO_Mapper.Tests.DataSources;

[TestFixture]
[TestOf(typeof(RemotePokemonDataSource))]
public class RemotePokemonDataSourceTest
{

    [Test]
    public async Task Get_Pokemon_Name()
    {
        var dataSource = new RemotePokemonDataSource(new HttpClient());
        var repo = new PokemonRepository(dataSource);

        var pokemon = await repo.GetPokemonByNameAsync("pikachu");
        
        Assert.That(pokemon?.Name, Is.EqualTo("pikachu"));
        Assert.That(pokemon?.Url, Is.EqualTo("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/25.png"));
    }
}