namespace CsharpStudy.Result.Dtos;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class ApiResponseDto
{
    [JsonProperty("errorMessage")]
    public ErrorMessageDto? ErrorMessage { get; set; }

    [JsonProperty("realtimeArrivalList")]
    public List<SubwayDto?>? RealtimeArrivalList { get; set; }
}

public class ErrorMessageDto
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

public class SubwayDto
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
    public int? TotalCount { get; set; }

    [JsonProperty("rowNum")]
    public int? RowNum { get; set; }

    [JsonProperty("selectedCount")]
    public int? SelectedCount { get; set; }

    [JsonProperty("subwayId")]
    public int? SubwayId { get; set; }

    [JsonProperty("subwayNm")]
    public string? SubwayNm { get; set; }

    [JsonProperty("updnLine")]
    public string? UpdnLine { get; set; }

    [JsonProperty("trainLineNm")]
    public string? TrainLineNm { get; set; }

    [JsonProperty("subwayHeading")]
    public string? SubwayHeading { get; set; }

    [JsonProperty("statnFid")]
    public string? StatnFid { get; set; }

    [JsonProperty("statnTid")]
    public string? StatnTid { get; set; }

    [JsonProperty("statnId")]
    public string? StatnId { get; set; }

    [JsonProperty("statnNm")]
    public string? StatnNm { get; set; }

    [JsonProperty("trainCo")]
    public string? TrainCo { get; set; }

    [JsonProperty("trnsitCo")]
    public string? TrnsitCo { get; set; }

    [JsonProperty("ordkey")]
    public string? Ordkey { get; set; }

    [JsonProperty("subwayList")]
    public string? SubwayList { get; set; }

    [JsonProperty("statnList")]
    public string? StatnList { get; set; }

    [JsonProperty("btrainSttus")]
    public string? BtrainSttus { get; set; }

    [JsonProperty("barvlDt")]
    public int? BarvlDt { get; set; }

    [JsonProperty("btrainNo")]
    public string? BtrainNo { get; set; }

    [JsonProperty("bstatnId")]
    public string? BstatnId { get; set; }

    [JsonProperty("bstatnNm")]
    public string? BstatnNm { get; set; }

    [JsonProperty("recptnDt")]
    public DateTime? RecptnDt { get; set; }

    [JsonProperty("arvlMsg2")]
    public string? ArvlMsg2 { get; set; }

    [JsonProperty("arvlMsg3")]
    public string? ArvlMsg3 { get; set; }

    [JsonProperty("arvlCd")]
    public int? ArvlCd { get; set; }

    [JsonProperty("lstcarAt")]
    public int? LstcarAt { get; set; }
}