using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.DTOs;
using CsharpStudy.DtoMapper.Models;

namespace CsharpStudy.DtoMapper;

public class MockPokemon : IPokemonApiDataSource
{
    private readonly Dictionary<int, Pokemon> _pokedex = new Dictionary<int, Pokemon>
    {
        {1, new Pokemon(25, "Pikachu")},
        {2, new Pokemon(132, "Ditto")}

    };


    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {

        var foundPokemon = _pokedex.Values.FirstOrDefault(p => p.Name == pokemonName);

        PokemonDto? mockDto;

        if (foundPokemon != null)
        {
            // 2. 일치하는 포켓몬을 찾았을 경우, mockDto를 채웁니다.
            mockDto = new PokemonDto
            {
                Id = foundPokemon.Id,
                Name = foundPokemon.Name,
                
            };

            // 3. 성공 응답을 반환합니다.
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };
            return new Response<PokemonDto>(200, headers, mockDto);
        }
        else
        {
            // 4. 포켓몬을 찾지 못했을 경우, 에러 응답을 반환합니다.
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };
            return new Response<PokemonDto>(404, headers, null);
        }
    }
}