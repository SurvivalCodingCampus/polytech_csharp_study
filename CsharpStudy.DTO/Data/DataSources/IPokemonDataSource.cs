namespace CsharpStudy.DTO.Data.DataSources;

public interface IPokemonDataSource
{
    Task<Response<PokemonDto>> GetPokemonAsync(string name);
}