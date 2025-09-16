namespace CsharpStudy.Result.DTOs;

using Newtonsoft.Json;
using System.Collections.Generic;

public class SubwayDto
{
    [JsonProperty("errorMessage")]
    public ErrorMessage? ErrorMessage { get; set; }

    [JsonProperty("realtimeStationArrival")]
    public List<RealtimeStationArrivalDto>? RealtimeStationArrival { get; set; }
}

public class ErrorMessage
{
    [JsonProperty("status")]
    public int? Status { get; set; }

    [JsonProperty("code")]
    public string? Code { get; set; }

    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("link")]
    public string? Link { get; set; }

    [JsonProperty("developerMessage")]
    public string? DeveloperMessage { get; set; }

    [JsonProperty("total")]
    public int? Total { get; set; }
}

public class RealtimeStationArrivalDto
{
    [JsonProperty("rowNum")]
    public int? RowNum { get; set; }

    [JsonProperty("subwayId")]
    public string? SubwayId { get; set; }

    [JsonProperty("updnLine")]
    public string? UpdnLine { get; set; }

    [JsonProperty("trainLineNm")]
    public string? TrainLineNm { get; set; }

    [JsonProperty("statnFid")]
    public string? StatnFid { get; set; }

    [JsonProperty("statnTid")]
    public string? StatnTid { get; set; }

    [JsonProperty("statnId")]
    public string? StatnId { get; set; }

    [JsonProperty("statnNm")]
    public string? StatnNm { get; set; }

    [JsonProperty("ordkey")]
    public string? Ordkey { get; set; }

    [JsonProperty("subwayList")]
    public string? SubwayList { get; set; }

    [JsonProperty("btrainSttus")]
    public string? BtrainSttus { get; set; }

    [JsonProperty("barvlDt")]
    public string? BarvlDt { get; set; }

    [JsonProperty("btrainNo")]
    public string? BtrainNo { get; set; }

    [JsonProperty("bstatnId")]
    public string? BstatnId { get; set; }

    [JsonProperty("bstatnNm")]
    public string? BstatnNm { get; set; }

    [JsonProperty("recptnDt")]
    public string? RecptnDt { get; set; }

    [JsonProperty("arvlMsg2")]
    public string? ArvlMsg2 { get; set; }

    [JsonProperty("arvlMsg3")]
    public string? ArvlMsg3 { get; set; }

    [JsonProperty("arvlCd")]
    public string? ArvlCd { get; set; }
}