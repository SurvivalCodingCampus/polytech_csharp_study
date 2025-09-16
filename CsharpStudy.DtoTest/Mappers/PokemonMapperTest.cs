using System.Net.Http;
using System.Collections.Generic;
using System.Runtime;
using System.Threading.Tasks;
using CshapStudy.DtoMapper.DataSource;
using CshapStudy.DtoMapper.Mappers;
using CshapStudy.DtoMapper.Repositories;
using NUnit.Framework;
using CshapStudy.DtoMapper.DTOs;
using CshapStudy.DtoMapper.Models;

namespace CsharpStudy.DtoTest.Mappers;

[TestFixture]
[TestOf(typeof(PokemonMapper))]
public class PokemonMapperTest
{
    [Test]

    public async Task GET_Diito()
    {
        IPokemonApiDataSource dataSource = new PokemonApiDataSource(new HttpClient());
        Response<PokemonDto> response = await dataSource.GetPokemonAsync("ditto");
        PokemonDto pokemonDto = response.Body;
        Pokemon pokemon = pokemonDto.ToModel();
        Assert.That(pokemon.Name, Is.EqualTo("ditto"));

    }
    [Test]
    public async Task GET_Ditto_Image_Url()
    {

        IPokemonApiDataSource dataSource = new PokemonApiDataSource(new HttpClient());
    

        Response<PokemonDto> response = await dataSource.GetPokemonAsync("ditto");
        PokemonDto pokemonDto = response.Body;
        Pokemon pokemon = pokemonDto.ToModel();

 
        Assert.That(pokemon.Name, Is.EqualTo("ditto"));
        
        Assert.That(pokemon.Imageurl, Is.Not.Null.And.Not.Empty);
        
    }

    
}