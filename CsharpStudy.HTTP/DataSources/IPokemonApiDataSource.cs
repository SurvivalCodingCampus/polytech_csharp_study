using System.Threading.Tasks;
using CsharpStudy.HTTP.Models;

namespace CsharpStudy.HTTP.DataSource
{
    public interface IPokemonApiDataSource
    {
        Task<Response<Pokemon>> GetPokemonAsync(string pokemonName);
    }
}