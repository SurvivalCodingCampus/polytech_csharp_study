using CsharpStudy.SubwayAPI.Data.Models;

namespace CsharpStudy.SubwayAPI.Data.Mappers;

public static class TrainsMapper
{
    public static List<Train> ToStation(this TrainsDto dto)
    {
        // Check repository methods and logics; RealtimeStationArrival is LIST!!!
        // bool isLastTrain = (dto.RealtimeStationArrival)
        
        List<Train> trains = new List<Train>();

        foreach (var trainArrival in dto.RealtimeStationArrival)
        {
            // int arrivalC = int.Parse(trainArrival.ArvlCd);
            int.TryParse(trainArrival.ArvlCd, out var arrivalC);
            bool isLastT = (int.Parse(trainArrival.LstcarAt) == 1);
            
            trains.Add(new Train(arrivalC, isLastT));
        }
        
        return trains;
    }
}