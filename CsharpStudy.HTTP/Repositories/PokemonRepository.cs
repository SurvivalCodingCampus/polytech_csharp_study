using CsharpStudy.HTTP.Common;
using CsharpStudy.HTTP.DTOs;
using CsharpStudy.HTTP.DataSources;

namespace CsharpStudy.HTTP.Repositories;

public sealed class PokemonRepository(IPokemonApiDataSource api) : IPokemonRepository
{
    public async Task<(Result result, PokemonDto? data)> GetByNameAsync(string name)
    {
        try
        {
            var dto = await api.GetPokemonAsync(name);
            if (dto is null)
                return (Result.Fail(new Error(PokemonError.Unknown, "Empty response")), null);

            return (Result.Ok(), dto);
        }
        catch (TaskCanceledException ex)
        {
            return (Result.Fail(new Error(PokemonError.Timeout, ex.Message, ex)), null);
        }
        catch (HttpRequestException ex)
        {
            var kind = ex.StatusCode == System.Net.HttpStatusCode.NotFound
                ? PokemonError.NotFound
                : PokemonError.Network;

            return (Result.Fail(new Error(kind, ex.Message, ex)), null);
        }
        catch (Exception ex)
        {
            return (Result.Fail(new Error(PokemonError.Unknown, ex.Message, ex)), null);
        }
    }
}