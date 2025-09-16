namespace CsharpStudy.Result.Models;

// public record Subway(string Name, string ArriveInfo);
public class Subway
{
    public string StationName { get; }
    public string TrainLineNum { get; }
    public string Massage { get; }
    public string SubwayId { get; }

    public Subway(string statnNm, string trainLineNm, string arvlMsg2, string subwayId)
    {
        StationName = statnNm;
        TrainLineNum = trainLineNm;
        Massage = arvlMsg2;
        SubwayId = subwayId;
    }
}