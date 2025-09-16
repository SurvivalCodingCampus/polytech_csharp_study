using System.ComponentModel;
using System.Threading.Tasks;
using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Mappers;
using CsharpStudy.Network.Models;
using CsharpStudy.Network.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Network.Test.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{
    private IDataSource<PokemonDto> _dataSource;
    private IRepository<Pokemon> _repository;

    [SetUp]
    protected void Setup()
    {
        _dataSource = new PokemonApiDatasource();
        _repository = new PokemonRepository(_dataSource);
    }


    [Test]
    [DisplayName("PokemonDto -> Pokemon 변환 테스트")]
    public void Method_2()
    {
        //given
        PokemonDto pokemonDto = new PokemonDto();
        pokemonDto.Id = 1;
        pokemonDto.Name = "picachu";
        pokemonDto.Sprites = new Sprites();
        pokemonDto.Sprites.FrontDefault = "picachuImg";
        //when

        var pokemon = Mapper.ToModel(pokemonDto);

        //then
        Assert.AreEqual(pokemon.Id, pokemonDto.Id);
        Assert.AreEqual(pokemon.Name, pokemonDto.Name);
        Assert.AreEqual(pokemon.Image, pokemonDto.Sprites.FrontDefault);
    }


    [Test]
    [DisplayName("API 통신 성공하여 200 코드가 반환된다.")]
    public async Task Method_3()
    {
        //given
        string name = "pikachu";

        //when
        var response = await _dataSource.GetNameAsync(name);

        //then
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, 200);
    }

    [Test]
    [DisplayName("포켓몬 정보를 Repository에서 가지고 온다.")]
    public async Task Method_1()
    {
        string name = "pikachu";

        var pikachu = await _repository.GetByNameAsync(name);

        Assert.IsNotNull(pikachu);
        Assert.True(pikachu.Name != null && pikachu.Name.Equals(name));
    }
}