using CsharpStudy.Result.Dtos;

namespace CsharpStudy.Result.Models;

public class Subway
{
    public int SubwayId { get; }
    public string TrainLineNm { get; }
    public string BtrainSttus { get; }
    public string ArvlMsg2 { get; }

    public Subway(int subwayId, string trainLineNm, string btrainSttus, string arvlMsg2)
    {
        SubwayId = subwayId;
        TrainLineNm = trainLineNm;
        this.TrainLineNm = trainLineNm;
        this.BtrainSttus = btrainSttus;
        this.ArvlMsg2 = arvlMsg2;
    }
}
