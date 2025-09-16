using Newtonsoft.Json;

namespace CsharpStudy.ResultExam.SubwayExam.DTO;

// 전체 JSON 응답을 나타내는 최상위 DTO
public class SubwayArrivalDto
{
    [JsonProperty("errorMessage")] public ErrorMessage? ErrorMessage { get; set; }

    [JsonProperty("realtimeArrivalList")] public List<RealtimeArrival>? RealtimeArrivalList { get; set; }
}

// errorMessage 객체에 대한 DTO
public class ErrorMessage
{
    [JsonProperty("status")] public int? Status { get; set; }

    [JsonProperty("code")] public string? Code { get; set; }

    [JsonProperty("message")] public string? Message { get; set; }

    [JsonProperty("link")] public string? Link { get; set; }

    [JsonProperty("developerMessage")] public string? DeveloperMessage { get; set; }

    [JsonProperty("total")] public int? Total { get; set; }
}

// realtimeArrivalList 배열의 각 항목에 대한 DTO
public class RealtimeArrival
{
    [JsonProperty("beginRow")] public object? BeginRow { get; set; }

    [JsonProperty("endRow")] public object? EndRow { get; set; }

    [JsonProperty("curPage")] public object? CurPage { get; set; }

    [JsonProperty("pageRow")] public object? PageRow { get; set; }

    [JsonProperty("totalCount")] public int? TotalCount { get; set; }

    [JsonProperty("rowNum")] public int? RowNum { get; set; }

    [JsonProperty("selectedCount")] public int? SelectedCount { get; set; }

    [JsonProperty("subwayId")] public string? SubwayId { get; set; }

    [JsonProperty("subwayNm")] public object? SubwayNm { get; set; }

    [JsonProperty("updnLine")] public string? UpdnLine { get; set; }

    [JsonProperty("trainLineNm")] public string? TrainLineNm { get; set; }

    [JsonProperty("subwayHeading")] public object? SubwayHeading { get; set; }

    [JsonProperty("statnFid")] public string? StatnFid { get; set; }

    [JsonProperty("statnTid")] public string? StatnTid { get; set; }


    [JsonProperty("statnId")] public string? StatnId { get; set; }

    [JsonProperty("statnNm")] public string? StatnNm { get; set; }

    [JsonProperty("trainCo")] public object? TrainCo { get; set; }

    [JsonProperty("trnsitCo")] public string? TrnsitCo { get; set; }

    [JsonProperty("ordkey")] public string? Ordkey { get; set; }

    [JsonProperty("subwayList")] public string? SubwayList { get; set; }

    [JsonProperty("statnList")] public string? StatnList { get; set; }

    [JsonProperty("btrainSttus")] public string? BtrainSttus { get; set; }

    [JsonProperty("barvlDt")] public string? BarvlDt { get; set; }

    [JsonProperty("btrainNo")] public string? BtrainNo { get; set; }

    [JsonProperty("bstatnId")] public string? BstatnId { get; set; }

    [JsonProperty("bstatnNm")] public string? BstatnNm { get; set; }

    [JsonProperty("recptnDt")] public string? RecptnDt { get; set; }

    [JsonProperty("arvlMsg2")] public string? ArvlMsg2 { get; set; }

    [JsonProperty("arvlMsg3")] public string? ArvlMsg3 { get; set; }

    [JsonProperty("arvlCd")] public string? ArvlCd { get; set; }

    [JsonProperty("lstcarAt")] public string? LstcarAt { get; set; }
}