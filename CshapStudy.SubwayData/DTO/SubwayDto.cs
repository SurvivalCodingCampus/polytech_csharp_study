using System.Text.Json.Serialization;

namespace CshapStudy.SubwayData.DTO;

// API 응답의 최상위 구조
public class SubwayDto
{
    [JsonPropertyName("errorMessage")]
    public ErrorMessage ErrorMessage { get; set; } = null!;
    
    [JsonPropertyName("realtimeArrivalList")]
    public List<RealtimeArrivalDto> RealtimeArrivalList { get; set; } = new();
}

// 에러 메시지 정보
public class ErrorMessage
{
    [JsonPropertyName("status")]
    public int Status { get; set; }
    
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;
    
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
    
    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;
    
    [JsonPropertyName("developerMessage")]
    public string DeveloperMessage { get; set; } = string.Empty;
    
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

// 실시간 도착 정보 DTO
public class RealtimeArrivalDto
{
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }
    
    [JsonPropertyName("rowNum")]
    public int RowNum { get; set; }
    
    [JsonPropertyName("selectedCount")]
    public int SelectedCount { get; set; }
    
    [JsonPropertyName("subwayId")]
    public string SubwayId { get; set; } = string.Empty;
    
    [JsonPropertyName("subwayNm")]
    public string? SubwayNm { get; set; }
    
    [JsonPropertyName("updnLine")]
    public string UpdnLine { get; set; } = string.Empty;
    
    [JsonPropertyName("trainLineNm")]
    public string TrainLineNm { get; set; } = string.Empty;
    
    [JsonPropertyName("subwayHeading")]
    public string? SubwayHeading { get; set; }
    
    [JsonPropertyName("statnFid")]
    public string StationFromId { get; set; } = string.Empty;
    
    [JsonPropertyName("statnTid")]
    public string StationToId { get; set; } = string.Empty;
    
    [JsonPropertyName("statnId")]
    public string StationId { get; set; } = string.Empty;
    
    [JsonPropertyName("statnNm")]
    public string StationName { get; set; } = string.Empty;
    
    [JsonPropertyName("trainCo")]
    public string? TrainCo { get; set; }
    
    [JsonPropertyName("trnsitCo")]
    public string TransitCo { get; set; } = string.Empty;
    
    [JsonPropertyName("ordkey")]
    public string OrderKey { get; set; } = string.Empty;
    
    [JsonPropertyName("subwayList")]
    public string SubwayList { get; set; } = string.Empty;
    
    [JsonPropertyName("statnList")]
    public string StationList { get; set; } = string.Empty;
    
    [JsonPropertyName("btrainSttus")]
    public string TrainStatus { get; set; } = string.Empty;
    
    [JsonPropertyName("barvlDt")]
    public string ArrivalTime { get; set; } = string.Empty;
    
    [JsonPropertyName("btrainNo")]
    public string TrainNumber { get; set; } = string.Empty;
    
    [JsonPropertyName("bstatnId")]
    public string BeginStationId { get; set; } = string.Empty;
    
    [JsonPropertyName("bstatnNm")]
    public string BeginStationName { get; set; } = string.Empty;
    
    [JsonPropertyName("recptnDt")]
    public string ReceivedDateTime { get; set; } = string.Empty;
    
    [JsonPropertyName("arvlMsg2")]
    public string ArrivalMessage2 { get; set; } = string.Empty;
    
    [JsonPropertyName("arvlMsg3")]
    public string ArrivalMessage3 { get; set; } = string.Empty;
    
    [JsonPropertyName("arvlCd")]
    public string ArrivalCode { get; set; } = string.Empty;
    
    [JsonPropertyName("lstcarAt")]
    public string LastCarAt { get; set; } = string.Empty;

    // DTO를 기존 Subway 모델로 변환하는 메서드
    // public Model.Subway ToSubwayModel()
    // {
    //     // SubwayId를 int로 파싱
    //     if (!int.TryParse(SubwayId, out int id))
    //     {
    //         id = 0; // 기본값 설정
    //     }
    //
    //     // 도착 시간 정보 생성 (도착시간 + 도착메시지)
    //     string timeInfo = string.IsNullOrWhiteSpace(ArrivalTime) || ArrivalTime == "0"
    //         ? ArrivalMessage2
    //         : $"{ArrivalTime}분 후 도착 - {ArrivalMessage2}";
    //
    //     return new Model.Subway(
    //         trainLineNum: TrainLineNm,
    //         id: id,
    //         name: StationName,
    //         time: timeInfo
    //     );
    // }
}

// 확장 메서드로 리스트 변환을 쉽게 처리
// public static class SubwayDtoExtensions
// {
//     public static List<Model.Subway> ToSubwayModels(this List<RealtimeArrivalDto> dtos)
//     {
//         return dtos.Select(dto => dto.ToSubwayModel()).ToList();
//     }
// }