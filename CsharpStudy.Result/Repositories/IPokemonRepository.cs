using CsharpStudy.DtoMapper.Common;
using CsharpStudy.DtoMapper.Repositories;
using CsharpStudy.Result.Models;

namespace CsharpStudy.Result.Repositories;

/// Pokemon 데이터에 접근하는 Repository의 인터페이스입니다.
/// 애플리케이션의 다른 부분(예: UI)은 이 인터페이스에만 의존하게 됩니다.
/// 결과물로 DTO가 아닌, 바로 사용할 수 있는 Pokemon '모델'을 반환하는 것이 특징입니다.
public interface IPokemonRepository
{
    Task<Result<Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName);
}