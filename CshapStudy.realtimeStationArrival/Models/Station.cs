using CshapStudy.realtimeStationArrival.DTOs;

namespace CshapStudy.realtimeStationArrival.Models;

public class Station : StationDto
{
    public string TrainLineName { get; }
    public string DestinationStation { get; }
    public string CurrentLocationMessage { get; }
    public string SubwayLineId { get; }

    public Station(string trainLineName, string destinationStation, string currentLocationMessage, string subwayLineId)
    {
        TrainLineName = trainLineName;
        DestinationStation = destinationStation;
        CurrentLocationMessage = currentLocationMessage;
        SubwayLineId = subwayLineId;
        
    }
    public string SubwayId { get; set; }
    public string TrainLineNm { get; set; }
    public string ArvlMsg2 { get; set; }
}