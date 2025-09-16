using CsharpStudy.DtoMapper;

namespace CsharpStudy.HTTP
{
    public interface IPokemonApiDataSource
    {
        Task<Response<PokemonDto>> GetPokemonAsync(string nameOrId);
    }
}