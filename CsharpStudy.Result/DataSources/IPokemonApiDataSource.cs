//using CsharpStudy.DtoMapper.DTO;

namespace CsharpStudy.Result.DataSources;

/// Pokemon API 데이터 소스에 대한 인터페이스입니다.
/// 이 인터페이스를 구현하는 클래스는 GetPokemonAsync 메서드를 반드시 제공해야 합니다.
/// 인터페이스를 사용하면 의존성 주입(DI)이 용이해지고 테스트하기 쉬운 코드를 작성할 수 있습니다.
public interface IPokemonApiDataSource
{
    /// 지정된 이름의 포켓몬 데이터를 비동기적으로 가져옵니다
    /// <param name="pokemonName">가져올 포켓몬의 이름</param>
    /// <returns>API 응답(Response)을 담고 있는 Task. 응답의 Body에는 PokemonDto가 들어있습니다.</returns>
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName); // 가져올 포켓몬 이름 
}