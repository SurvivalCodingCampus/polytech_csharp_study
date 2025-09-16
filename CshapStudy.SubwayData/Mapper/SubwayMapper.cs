using CshapStudy.SubwayData.DTO;
using CshapStudy.SubwayData.Model;

namespace CshapStudy.SubwayData.Mapper;
public static class SubwayMapper
{
    // RealtimeArrivalDto를 Subway 모델로 변환하는 확장 메서드
    public static Subway ToSubwayModel(this RealtimeArrivalDto dto)
    {
        // SubwayId를 int로 파싱
        if (!int.TryParse(dto.SubwayId, out int id))
        {
            id = 0; // 기본값 설정
        }

        // 실제 노선명 결정 (SubwayId 기반)
        string lineName = GetLineNameFromId(dto.SubwayId);

        // 도착 시간 정보 생성
        string timeInfo = CreateArrivalTimeInfo(dto);

        return new Subway(
            trainLineNum: lineName, // 실제 노선명 사용
            id: id,
            name: dto.StationName,
            time: timeInfo
        );
    }

    // SubwayId를 기반으로 노선명 반환
    private static string GetLineNameFromId(string subwayId)
    {
        return subwayId switch
        {
            "1001" => "1호선",
            "1002" => "2호선", 
            "1003" => "3호선",
            "1004" => "4호선",
            "1005" => "5호선",
            "1006" => "6호선",
            "1007" => "7호선",
            "1008" => "8호선",
            "1009" => "9호선",
            "1065" => "공항철도", // 현재 출력된 ID
            "1063" => "경의중앙선",
            "1067" => "우이신설선",
            "1075" => "수인분당선",
            "1077" => "신분당선",
            "1092" => "우이신설선",
            _ => $"알 수 없는 노선({subwayId})"
        };
    }

    // 도착시간 정보를 더 명확하게 생성
    private static string CreateArrivalTimeInfo(RealtimeArrivalDto dto)
    {
        // 디버깅용 로그 (필요시 활성화)
        // Console.WriteLine($"ArrivalTime: '{dto.ArrivalTime}', ArrivalMessage2: '{dto.ArrivalMessage2}', TrainLineNm: '{dto.TrainLineNm}'");

        // 도착시간이 있는 경우
        if (!string.IsNullOrWhiteSpace(dto.ArrivalTime) && dto.ArrivalTime != "0")
        {
            return $"{dto.ArrivalTime}초 후 도착"; // 보통 초 단위로 옴
        }

        // ArrivalMessage2가 유용한 정보인지 확인
        if (!string.IsNullOrWhiteSpace(dto.ArrivalMessage2))
        {
            // "서울 출발" 같은 정보면 더 유용한 형태로 변환
            if (dto.ArrivalMessage2.Contains("출발"))
            {
                return $"열차 운행중 ({dto.ArrivalMessage2})";
            }
            
            return dto.ArrivalMessage2;
        }

        // ArrivalMessage3도 확인
        if (!string.IsNullOrWhiteSpace(dto.ArrivalMessage3))
        {
            return dto.ArrivalMessage3;
        }

        // TrainLineNm에 행선지 정보가 있으면 활용
        if (!string.IsNullOrWhiteSpace(dto.TrainLineNm))
        {
            return $"운행중 - {dto.TrainLineNm}";
        }

        return "도착 정보 없음";
    }

    // SubwayDto의 RealtimeArrivalList를 Subway 모델 리스트로 변환
    public static List<Subway> ToSubwayModels(this SubwayDto subwayDto)
    {
        return subwayDto.RealtimeArrivalList
            .Select(dto => dto.ToSubwayModel())
            .ToList();
    }

    // RealtimeArrivalDto 리스트를 Subway 모델 리스트로 변환
    public static List<Subway> ToSubwayModels(this List<RealtimeArrivalDto> dtos)
    {
        return dtos.Select(dto => dto.ToSubwayModel()).ToList();
    }
}

// 디버깅을 위한 확장 메서드
public static class SubwayDebugExtensions
{
    public static void PrintDebugInfo(this RealtimeArrivalDto dto)
    {
        Console.WriteLine("=== API 응답 디버그 정보 ===");
        Console.WriteLine($"SubwayId: {dto.SubwayId}");
        Console.WriteLine($"StationName: {dto.StationName}");
        Console.WriteLine($"TrainLineNm: {dto.TrainLineNm}");
        Console.WriteLine($"ArrivalTime: '{dto.ArrivalTime}'");
        Console.WriteLine($"ArrivalMessage2: '{dto.ArrivalMessage2}'");
        Console.WriteLine($"ArrivalMessage3: '{dto.ArrivalMessage3}'");
        Console.WriteLine($"UpdnLine: {dto.UpdnLine}");
        Console.WriteLine($"TrainStatus: {dto.TrainStatus}");
        Console.WriteLine("========================");
    }
}