using Newtonsoft.Json;
using System.Collections.Generic;

public class SeoulStationDto
{
    [JsonProperty("errorMessage")]
    public ErrorMessage? ErrorMessage { set; get; }

    [JsonProperty("realtimeArrivalList")]
    public List<RealtimeArrivalList>? RealtimeArrivalList { set; get; }
}

public class ErrorMessage
{
    [JsonProperty("status")]
    public int? Status { set; get; }

    [JsonProperty("code")]
    public string? Code { set; get; }

    [JsonProperty("message")]
    public string? Message { set; get; }

    [JsonProperty("link")]
    public string? Link { set; get; }

    [JsonProperty("developerMessage")]
    public string? DeveloperMessage { set; get; }

    [JsonProperty("total")]
    public int? Total { set; get; }
}

public class RealtimeArrivalList
{
    [JsonProperty("beginRow")]
    public int? BeginRow { set; get; }

    [JsonProperty("endRow")]
    public int? EndRow { set; get; }

    [JsonProperty("curPage")]
    public int? CurPage { set; get; }

    [JsonProperty("pageRow")]
    public int? PageRow { set; get; }

    [JsonProperty("totalCount")]
    public int? TotalCount { set; get; }

    [JsonProperty("rowNum")]
    public int? RowNum { set; get; }

    [JsonProperty("selectedCount")]
    public int? SelectedCount { set; get; }

    [JsonProperty("subwayId")]
    public string? SubwayId { set; get; }

    [JsonProperty("subwayNm")]
    public string? SubwayNm { set; get; }

    [JsonProperty("updnLine")]
    public string? UpdnLine { set; get; }

    [JsonProperty("trainLineNm")]
    public string? TrainLineNm { set; get; }

    [JsonProperty("subwayHeading")]
    public string? SubwayHeading { set; get; }

    [JsonProperty("statnFid")]
    public string? StatnFid { set; get; }

    [JsonProperty("statnTid")]
    public string? StatnTid { set; get; }

    [JsonProperty("statnId")]
    public string? StatnId { set; get; }

    [JsonProperty("statnNm")]
    public string? StatnNm { set; get; }

    [JsonProperty("trainCo")]
    public string? TrainCo { set; get; }

    [JsonProperty("trnsitCo")]
    public string? TrnsitCo { set; get; }

    [JsonProperty("ordkey")]
    public string? Ordkey { set; get; }

    [JsonProperty("subwayList")]
    public string? SubwayList { set; get; }

    [JsonProperty("statnList")]
    public string? StatnList { set; get; }

    [JsonProperty("btrainSttus")]
    public string? BtrainSttus { set; get; }

    [JsonProperty("barvlDt")]
    public string? BarvlDt { set; get; }

    [JsonProperty("btrainNo")]
    public string? BtrainNo { set; get; }

    [JsonProperty("bstatnId")]
    public string? BstatnId { set; get; }

    [JsonProperty("bstatnNm")]
    public string? BstatnNm { set; get; }

    [JsonProperty("recptnDt")]
    public string? RecptnDt { set; get; }

    [JsonProperty("arvlMsg2")]
    public string? ArvlMsg2 { set; get; }

    [JsonProperty("arvlMsg3")]
    public string? ArvlMsg3 { set; get; }

    [JsonProperty("arvlCd")]
    public string? ArvlCd { set; get; }

    [JsonProperty("lstcarAt")]
    public string? LstcarAt { set; get; }
}