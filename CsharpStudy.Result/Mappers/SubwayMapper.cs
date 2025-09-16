using CsharpStudy.Result.DTOs;

namespace CsharpStudy.Result.Mappers;

public static class SubwayMapper
{
    /*
    public static Models.Subway ToSubwayModel(this SubwayDto dto)
    {
        return new Models.Subway(
            Name: dto.RealtimeStationArrival. ?? "", 
        );
    }
    */
    public static Models.Subway ToSubwayModel(this SubwayDto dto)
    {
        // RealtimeStationArrival 리스트가 null이거나 비어있을 경우를 대비하여 첫 번째 요소를 안전하게 가져옵니다.
        var firstArrival = dto.RealtimeStationArrival?.FirstOrDefault();

        return new Models.Subway(
            statnNm: firstArrival?.StatnNm ?? "정보 없음",
            trainLineNm: firstArrival?.TrainLineNm ?? "정보 없음",
            arvlMsg2: firstArrival?.ArvlMsg2 ?? "정보 없음",
            subwayId: firstArrival?.SubwayId ?? "정보 없음"
        );
    }
}