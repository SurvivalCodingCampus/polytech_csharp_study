namespace CsharpStudy.SubwayAPI.Data.Mappers;

public static class StationMapper
{
    public static StationDto ToStation(this StationDto dto)
    {
        // Check repository methods and logics; RealtimeStationArrival is LIST!!!
        bool isLastTrain = (dto.RealtimeStationArrival)
    }
}