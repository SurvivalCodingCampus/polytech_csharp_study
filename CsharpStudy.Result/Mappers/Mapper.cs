

using CsharpStudy.Result.Dtos;

namespace CsharpStudy.Result.Mappers;

public static class Mapper
{
    public static Models.Subway ToModel(this SubwayDto dto)
    {
        return new Models.Subway(
            subwayId: dto.SubwayId ?? 0,
            trainLineNm: dto.TrainLineNm ?? "", 
            btrainSttus: dto.BtrainSttus ?? "",
            arvlMsg2: dto.ArvlMsg2 ?? ""
        );
    }
}