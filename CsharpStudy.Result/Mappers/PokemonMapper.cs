//using CsharpStudy.DtoMapper.DTO;

using CsharpStudy.Result.Models;

namespace CsharpStudy.Result.Mappers;

/// DTO를 Model로 변환하는 로직을 담고 있는 정적(static) 클래스입니다.
public static class PokemonMapper // DTO를 Model로 변환
{
    /// PokemonDto를 Pokemon 모델로 변환하는 확장 메서드(extension method)입니다.
    /// 'this PokemonDto dto' 구문 덕분에 'dto.ToModel()' 형태로 편리하게 호출할 수 있습니다.
    ///
    /// <param name="dto">변환할 PokemonDto 객체</param>
    /// <returns>변환된 Pokemon 모델 객체</returns>
    public static Pokemon ToModel(this PokemonDto dto) // 변환할 PokemonDto 객체
    {
        // Pokemon 모델을 생성하여 반환합니다.


        return new Pokemon( // 변환된 Pokemon 모델 객체

            // dto.Name이 null이면 빈 문자열("")을 사용합니다. (Null-coalescing operator)
            // 이를 통해 NullReferenceException을 방지하고 non-nullable인 Model의 요구사항을 충족시킵니다.
            //name: dto.Name ?? "",
            Name: dto.Name ?? "",

            // DTO의 속성이 중첩되어 있고 각 단계가 null일 수 있으므로,
            // '?'(Null-conditional operator)를 사용하여 안전하게 접근합니다.
            // 최종적으로 FrontDefault가 null이면 빈 문자열("")을 사용합니다.
            //imageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
            ImageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
        );
    }
}