using CsharpStudy.SubwayExam.DTOs;
using CsharpStudy.SubwayExam.Models;

namespace CsharpStudy.SubwayExam.Mapper;

public static class SubwayMapper
{
    public static SubwayArrivalInfo ToModel(this RealtimeArrivalDto dto)
    {
        return new SubwayArrivalInfo(
            StationName: dto.statnNm ?? "",
            ArrivalTime: dto.recptnDt ?? "",
            ArrivalMessage1: dto.arvlMsg2 ?? "",
            ArrivalMessage2: dto.arvlMsg3 ?? ""
        );
    }
}