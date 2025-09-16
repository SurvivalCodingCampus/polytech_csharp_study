using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.DataSources.Mocks;
using CsharpStudy.DTO.Data.Mappers;
using NUnit.Framework;

namespace CsharpStudy.Pokemon.Tests.Data.Mappers
{
    [TestFixture]
    [TestOf(typeof(PokemonMapper))]
    public class PokemonMapperTest
    {

        [Test]
        public async Task IS_NAME_LITERALLY_MISSING_ASYNC()
        {
            HttpClient httpClient = new HttpClient();
            MockPokemonDataSource mock = new MockPokemonDataSource(httpClient);

            Response<PokemonDto> response = await mock.GetPokemonAsync("charizard");
            PokemonDto dto = response.Body;
            DTO.Data.Models.Pokemon result = dto.ToPokemon();
            
            Assert.That(result.Name, Is.EqualTo("Missing"));
        }
        
        [Test]
        public async Task IS_PLACEHOLDER_LOADED()
        {
            HttpClient httpClient = new HttpClient();
            MockPokemonDataSource mock = new MockPokemonDataSource(httpClient);

            Response<PokemonDto> response = await mock.GetPokemonAsync("charizard");
            PokemonDto dto = response.Body;
            DTO.Data.Models.Pokemon result = dto.ToPokemon();
            
            Assert.That(result.OfficialArtFront, Is.EqualTo("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png"));
        }
    }
}