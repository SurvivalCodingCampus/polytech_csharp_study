using CsharpStudy.ResultExam.SubwayExam.DTO;

namespace CsharpStudy.ResultExam.SubwayExam
    .Mappers;

public static class SubwayMapper // DTO를 Model로 변환
{
    public static List<Models.Subway> ToModel(this SubwayArrivalDto dto)
    {
        return dto.RealtimeArrivalList
            ?.Select(e => new ResultExam.SubwayExam.Models.Subway(e.BstatnNm ?? "", e.BtrainSttus ?? ""))
            .ToList() ?? [];
        //     // return new Models.Subway(
        //     //     EndStationName:
        //     //     dto.RealtimeArrivalList.BstatnNm ?? "",
        //     //
        //     //
        //     //     TrainType:
        //     //     dto.RealtimeArrivalList.BtrainSttus ?? "");
        //
        //     // 1. 리스트에서 첫 번째 도착 정보를 가져옵니다.
        //     //    리스트가 비어있으면 firstArrival은 null이 됩니다.
        //     var firstArrival = dto.RealtimeArrivalList?.FirstOrDefault();
        //
        //     // 2. 첫 번째 도착 정보가 없으면, null을 반환하고 메서드를 종료합니다.
        //     if (firstArrival == null)
        //     {
        //         return null;
        //     }
        //
        //     // 3. 첫 번째 도착 정보가 있으면, 해당 정보로 Subway 모델을 생성합니다.
        //     return new Models.Subway(
        //         EndStationName: firstArrival.BstatnNm ?? "정보 없음",
        //         TrainType: firstArrival.BtrainSttus ?? "정보 없음"
        //     );
    }
}