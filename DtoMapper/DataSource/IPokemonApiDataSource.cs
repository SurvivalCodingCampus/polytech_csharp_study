namespace DtoMapper.DataSource;

public interface IPokemonApiDataSource
{
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName);
}