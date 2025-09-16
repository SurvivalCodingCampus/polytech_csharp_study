namespace CsharpStudy.SubwayAPI.Data.Models;

public class Station
{
    public int ArrivalCode { get; }
    // 0: Entering
    // 1: Arrived
    // 2: Departed
    // 3: Departed from the last station
    // 4: Entering the last station
    // 5: Arrived at the last station
    // 99 : Driving
    public bool IsLastTrain { get; }

    public Station(int arrivalCode, bool isLastTrain)
    {
        ArrivalCode = arrivalCode;
        IsLastTrain = isLastTrain;
    }
}