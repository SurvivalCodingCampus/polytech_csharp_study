using System.Text.Json.Serialization;

namespace CsharpStudy.ResultPattern.DTOs;

public sealed class SubwayResponse
{
    [JsonPropertyName("realtimeArrivalList")]
    public List<RealtimeArrival>? RealtimeArrivalList { get; set; }
}

public sealed class RealtimeArrival
{
    [JsonPropertyName("trainLineNm")] public string? TrainLineNm { get; set; }
    [JsonPropertyName("arvlMsg2")]    public string? ArrivalMessage { get; set; }
    [JsonPropertyName("barvlDt")]     public string? RemainSeconds { get; set; }
}

public sealed record Arrival(string Line, string Message, int? RemainSec);