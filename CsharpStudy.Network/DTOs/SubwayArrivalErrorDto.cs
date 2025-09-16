using Newtonsoft.Json;

namespace CsharpStudy.Network.DTOs;

// API 응답의 에러 메시지 정보
public class ErrorMessage
{
    [JsonProperty("status")]
    public int Status { get; set; }
    
    [JsonProperty("code")]
    public string? Code { get; set; }
    
    [JsonProperty("message")]
    public string? Message { get; set; }
    
    [JsonProperty("link")]
    public string? Link { get; set; }
    
    [JsonProperty("developerMessage")]
    public string? DeveloperMessage { get; set; }
    
    [JsonProperty("total")]
    public int Total { get; set; }
}

// 실시간 지하철 도착 정보
public class RealtimeArrival
{
    [JsonProperty("beginRow")]
    public int? BeginRow { get; set; }
    
    [JsonProperty("endRow")]
    public int? EndRow { get; set; }
    
    [JsonProperty("curPage")]
    public int? CurPage { get; set; }
    
    [JsonProperty("pageRow")]
    public int? PageRow { get; set; }
    
    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
    
    [JsonProperty("rowNum")]
    public int RowNum { get; set; }
    
    [JsonProperty("selectedCount")]
    public int SelectedCount { get; set; }
    
    [JsonProperty("subwayId")]
    public string? SubwayId { get; set; }
    
    [JsonProperty("subwayNm")]
    public string? SubwayName { get; set; }
    
    [JsonProperty("updnLine")]
    public string? UpDownLine { get; set; }
    
    [JsonProperty("trainLineNm")]
    public string? TrainLineName { get; set; }
    
    [JsonProperty("subwayHeading")]
    public string? SubwayHeading { get; set; }
    
    [JsonProperty("statnFid")]
    public string? StationFromId { get; set; }
    
    [JsonProperty("statnTid")]
    public string? StationToId { get; set; }
    
    [JsonProperty("statnId")]
    public string? StationId { get; set; }
    
    [JsonProperty("statnNm")]
    public string? StationName { get; set; }
    
    [JsonProperty("trainCo")]
    public string? TrainCo { get; set; }
    
    [JsonProperty("trnsitCo")]
    public string? TransitCo { get; set; }
    
    [JsonProperty("ordkey")]
    public string? OrderKey { get; set; }
    
    [JsonProperty("subwayList")]
    public string? SubwayList { get; set; }
    
    [JsonProperty("statnList")]
    public string? StationList { get; set; }
    
    [JsonProperty("btrainSttus")]
    public string? TrainStatus { get; set; }
    
    [JsonProperty("barvlDt")]
    public string? ArrivalTime { get; set; }
    
    [JsonProperty("btrainNo")]
    public string? TrainNumber { get; set; }
    
    [JsonProperty("bstatnId")]
    public string? DestinationStationId { get; set; }
    
    [JsonProperty("bstatnNm")]
    public string? DestinationStationName { get; set; }
    
    [JsonProperty("recptnDt")]
    public string? ReceivedDateTime { get; set; }
    
    [JsonProperty("arvlMsg2")]
    public string? ArrivalMessage2 { get; set; }
    
    [JsonProperty("arvlMsg3")]
    public string? ArrivalMessage3 { get; set; }
    
    [JsonProperty("arvlCd")]
    public string? ArrivalCode { get; set; }
    
    [JsonProperty("lstcarAt")]
    public string? LastCarAt { get; set; }
    
}

// 메인 지하철 도착 정보 DTO 클래스
public class SubwayArrivalDto
{
    [JsonProperty("errorMessage")]
    public ErrorMessage? ErrorMessage { get; set; }
    
    [JsonProperty("realtimeArrivalList")]
    public List<RealtimeArrival>? RealtimeArrivalList { get; set; }
    
}