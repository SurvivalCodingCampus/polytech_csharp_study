using System.Threading.Tasks;
using CsharpStudy.HTTP.DataSource;
using CsharpStudy.HTTP.Models;
using CsharpStudy.HTTP.Repositories;

namespace CsharpStudy.HTTP.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IPokemonApiDataSource _dataSource;

        public PokemonRepository(IPokemonApiDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
        {
            var response = await _dataSource.GetPokemonAsync(pokemonName);
            return response.Body;
        }
    }
}