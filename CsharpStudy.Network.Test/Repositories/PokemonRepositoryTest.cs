using System.ComponentModel;
using System.Threading.Tasks;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Models;
using CsharpStudy.Network.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Network.Test.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{
    private IDataSource<Pokemon> _dataSource;
    private IRepository<Pokemon> _repository;

    [SetUp]
    protected void Setup()
    {
        _dataSource = new PokemonApiDatasource();
        _repository = new PokemonRepository(_dataSource);
    }


    [Test]
    [DisplayName("포켓몬 정보를 가지고 온다.")]
    public async Task Method_1()
    {
        string name = "pikachu";

        var pikachu = await _repository.GetByNameAsync(name);
        
        Assert.IsNotNull(pikachu);
        Assert.True(pikachu.Name != null && pikachu.Name.Equals(name));
    }

}