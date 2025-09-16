using Newtonsoft.Json;

public class StationDto
{
    [JsonProperty("errorMessage")]
    public ErrorMessageDto ErrorMessage { get; set; }

    [JsonProperty("realtimeStationArrival")]
    public List<RealtimeStationArrivalDto> RealtimeStationArrival { get; set; }
}

public class ErrorMessageDto
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("developerMessage")]
    public string DeveloperMessage { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }
}

public class RealtimeStationArrivalDto
{
    [JsonProperty("rowNum")]
    public int RowNum { get; set; }

    [JsonProperty("selectedCount")]
    public int SelectedCount { get; set; }

    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }

    [JsonProperty("subwayId")]
    public string SubwayId { get; set; }

    [JsonProperty("subwayNm")]
    public string SubwayNm { get; set; }

    [JsonProperty("statnId")]
    public string StatnId { get; set; }

    [JsonProperty("statnNm")]
    public string StatnNm { get; set; }

    [JsonProperty("rtSntId")]
    public string RtSntId { get; set; }

    [JsonProperty("barvlDt")]
    public string BarvlDt { get; set; }

    [JsonProperty("btrainSttus")]
    public string BtrainSttus { get; set; }

    [JsonProperty("bstatnId")]
    public string BstatnId { get; set; }

    [JsonProperty("bstatnNm")]
    public string BstatnNm { get; set; }

    [JsonProperty("recptnDt")]
    public string RecptnDt { get; set; }

    [JsonProperty("updnLine")]
    public string UpdnLine { get; set; }

    [JsonProperty("trainCo")]
    public string TrainCo { get; set; }

    [JsonProperty("arvlMsg2")]
    public string ArvlMsg2 { get; set; }

    [JsonProperty("arvlMsg3")]
    public string ArvlMsg3 { get; set; }

    [JsonProperty("arvlCd")]
    public string ArvlCd { get; set; }

    [JsonProperty("statnFid")]
    public string StatnFid { get; set; }

    [JsonProperty("statnTid")]
    public string StatnTid { get; set; }
}