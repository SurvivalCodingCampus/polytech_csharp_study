using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.Mappers; // ToModel() 확장 메서드를 사용하기 위해 추가

namespace CsharpStudy.DtoMapper.Repositories;

/// IPokemonRepository 인터페이스의 실제 구현체입니다.
public class PokemonRepository : IPokemonRepository // 비즈니스 로직 처리
{
    // 데이터 소스에 대한 의존성을 가집니다. 구현체(PokemonApiDataSource)가 아닌 인터페이스(IPokemonApiDataSource)에 의존합니다.
    private IPokemonApiDataSource _dataSource;

    public PokemonRepository(IPokemonApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    /// 데이터 소스로부터 DTO를 가져와 Model로 변환하여 반환하는 전체 과정을 담당합니다.
    public async Task<Models.Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        try
        {
            // 1. DataSource를 통해 API로부터 데이터를 가져옵니다. 결과는 Response<PokemonDto> 형태입니다.
            var response = await _dataSource.GetPokemonAsync(pokemonName);
            // 2. 응답의 Body에서 실제 PokemonDto를 추출합니다.
            var dto = response.Body;
            // 3. Mapper(확장 메서드)를 사용하여 DTO를 애플리케이션 Model로 변환합니다.
            return dto.ToModel();
        }
        catch (Exception e)
        {
            // 네트워크 오류, JSON 파싱 오류 등 어떤 예외가 발생하더라도
            // 프로그램이 중단되지 않고 null을 반환하여 안정성을 확보합니다.
            // 실제 서비스에서는 여기에 로깅(logging) 코드를 추가하는 것이 좋습니다.
            return null;
        }
    }
}