

using CsharpStudy.Result.Dtos;
using CsharpStudy.Result.Models;


namespace CsharpStudy.Result.Mappers;

public static class Mapper
{
    public static List<Subway> ToModels(this ApiResponseDto dto)
    {
        // RealtimeArrivalList가 null이거나 비어있으면 빈 리스트 반환
        if (dto?.RealtimeArrivalList == null)
        {
            return new List<Subway>();
        }

        // LINQ의 Select 메서드를 사용하여 각 RealtimeArrivalDto를 Subway 모델로 변환
        return dto.RealtimeArrivalList
            .Select(arrivalDto => new Subway(
                subwayId: arrivalDto!.SubwayId ?? 0,
                trainLineNm: arrivalDto.TrainLineNm ?? "",
                btrainSttus: arrivalDto.BtrainSttus ?? "",
                arvlMsg2: arrivalDto.ArvlMsg2 ?? ""
            ))
            .ToList();
    }
}