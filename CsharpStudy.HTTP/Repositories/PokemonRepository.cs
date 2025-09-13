using System.Threading.Tasks;
using CsharpStudy.HTTP.Models;

namespace CsharpStudy.HTTP.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private IPokemonApiDataSource _dataSource;

        public PokemonRepository(IPokemonApiDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
        {
            var res = await _dataSource.GetPokemonAsync(pokemonName);
            // 200~299만 유효, 아니면 null
            return (res.StatusCode >= 200 && res.StatusCode < 300) ? res.Body : null;
        }
    }
}