using System.Text.Json.Serialization;

namespace CshapStudy.realtimeStationArrival.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

public class StationDto
{
    [JsonPropertyName("errorMessage")]
    public ErrorMessage ErrorMessage { get; set; }

    [JsonPropertyName("realtimeArrivalList")]
    public List<RealtimeArrival> RealtimeArrivalList { get; set; }
    
}

public class ErrorMessage
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("developerMessage")]
    public string DeveloperMessage { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}

public class RealtimeArrival
{
    [JsonPropertyName("beginRow")]
    public object BeginRow { get; set; }

    [JsonPropertyName("endRow")]
    public object EndRow { get; set; }

    [JsonPropertyName("curPage")]
    public object CurPage { get; set; }

    [JsonPropertyName("pageRow")]
    public object PageRow { get; set; }

    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }

    [JsonPropertyName("rowNum")]
    public int RowNum { get; set; }

    [JsonPropertyName("selectedCount")]
    public int SelectedCount { get; set; }

    [JsonPropertyName("subwayId")]
    public string SubwayId { get; set; }

    [JsonPropertyName("subwayNm")]
    public object SubwayNm { get; set; }

    [JsonPropertyName("updnLine")]
    public string UpdnLine { get; set; }

    [JsonPropertyName("trainLineNm")]
    public string TrainLineNm { get; set; }

    [JsonPropertyName("subwayHeading")]
    public object SubwayHeading { get; set; }

    [JsonPropertyName("statnFid")]
    public string StatnFid { get; set; }

    [JsonPropertyName("statnTid")]
    public string StatnTid { get; set; }

    [JsonPropertyName("statnId")]
    public string StatnId { get; set; }

    [JsonPropertyName("statnNm")]
    public string StatnNm { get; set; }

    [JsonPropertyName("trainCo")]
    public object TrainCo { get; set; }

    [JsonPropertyName("trnsitCo")]
    public string TrnsitCo { get; set; }

    [JsonPropertyName("ordkey")]
    public string Ordkey { get; set; }

    [JsonPropertyName("subwayList")]
    public string SubwayList { get; set; }

    [JsonPropertyName("statnList")]
    public string StatnList { get; set; }

    [JsonPropertyName("btrainSttus")]
    public string BtrainSttus { get; set; }

    [JsonPropertyName("barvlDt")]
    public string BarvlDt { get; set; }

    [JsonPropertyName("btrainNo")]
    public string BtrainNo { get; set; }

    [JsonPropertyName("bstatnId")]
    public string BstatnId { get; set; }

    [JsonPropertyName("bstatnNm")]
    public string BstatnNm { get; set; }

    [JsonPropertyName("recptnDt")]
    public string RecptnDt { get; set; }

    [JsonPropertyName("arvlMsg2")]
    public string ArvlMsg2 { get; set; }

    [JsonPropertyName("arvlMsg3")]
    public string ArvlMsg3 { get; set; }

    [JsonPropertyName("arvlCd")]
    public string ArvlCd { get; set; }

    [JsonPropertyName("lstcarAt")]
    public string LstcarAt { get; set; }
}