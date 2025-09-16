
namespace CsharpStudy.Subway.Mappers;

public static class SeoulStationMapper
{
    public static Models.SeoulStation ToModel(this SeoulStationDto dto)
    {
        return new Models.SeoulStation(
            Name: dto.RealtimeArrivalList[0].StatnNm ?? ""
        );
    }
    
}