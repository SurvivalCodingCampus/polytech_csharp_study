namespace CsharpStudy.SubwayExam.DTOs;

using System;
using System.Collections.Generic;

public class SubwayInfoDto
{
    public ErrorMessageDto? errorMessage { get; set; }
    public List<RealtimeArrivalDto>? realtimeArrivalList { get; set; }
}

public class ErrorMessageDto
{
    public int? status { get; set; }
    public string? code { get; set; }
    public string? message { get; set; }
    public string? link { get; set; }
    public string? developerMessage { get; set; }
    public int? total { get; set; }
}

public class RealtimeArrivalDto
{
    public object? beginRow { get; set; }
    public object? endRow { get; set; }
    public object? curPage { get; set; }
    public object? pageRow { get; set; }
    public int? totalCount { get; set; }
    public int? rowNum { get; set; }
    public int? selectedCount { get; set; }
    public string? subwayId { get; set; }
    public object? subwayNm { get; set; }
    public string? updnLine { get; set; }
    public string? trainLineNm { get; set; }
    public object? subwayHeading { get; set; }
    public string? statnFid { get; set; }
    public string? statnTid { get; set; }
    public string? statnId { get; set; }
    public string? statnNm { get; set; }
    public object? trainCo { get; set; }
    public string? trnsitCo { get; set; }
    public string? ordkey { get; set; }
    public string? subwayList { get; set; }
    public string? statnList { get; set; }
    public string? btrainSttus { get; set; }
    public string? barvlDt { get; set; }
    public string? btrainNo { get; set; }
    public string? bstatnId { get; set; }
    public string? bstatnNm { get; set; }
    public string? recptnDt { get; set; }
    public string? arvlMsg2 { get; set; }
    public string? arvlMsg3 { get; set; }
    public string? arvlCd { get; set; }
    public string? lstcarAt { get; set; }
}