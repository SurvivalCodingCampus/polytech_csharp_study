using CsharpStudy.HTTP.Mapping;  
using CsharpStudy.HTTP.Models;
using CsharpStudy.DtoMapper;

namespace CsharpStudy.HTTP.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private IPokemonApiDataSource _api;
        public PokemonRepository(IPokemonApiDataSource api) => _api = api;

        public async Task<Pokemon> GetPokemonByNameAsync(string nameOrId)
        {
            var res = await _api.GetPokemonAsync(nameOrId);
            var dto = res.Body ?? new PokemonDto();   
            return dto.ToModel();                    
        }
    }
}