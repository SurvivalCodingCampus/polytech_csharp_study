namespace Csharp_study.http.DataSources;

public interface IPokemonApiDataSource<T>
{
    Task <Response>GetPokemonAsync(string pokemonName);
}

