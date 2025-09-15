namespace Csharp_study.http.DataSources;

public interface IPokemonApiDataSource<T>
{
    Task GetPokemonAsync(string pokemonName);
}

