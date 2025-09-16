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
        var firstArrival = dto.RealtimeStationArrival?.FirstOrDefault();

        return new Models.Subway(
            statnNm: firstArrival.StatnNm,
            trainLineNm: firstArrival.TrainLineNm,
            arvlMsg2: firstArrival.ArvlMsg2,
            subwayId: firstArrival.SubwayId
        );
    }
}