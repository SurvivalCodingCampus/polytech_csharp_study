namespace CshapStudy.realtimeStationArrival.Models;

public class Station
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
}