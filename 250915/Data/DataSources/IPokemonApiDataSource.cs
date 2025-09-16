namespace _250915.Data.DataSources;

public interface IPokemonApiDataSource<T>
{
    public Task<Response> GetPokemonAsync(string pokemonName);
    
}