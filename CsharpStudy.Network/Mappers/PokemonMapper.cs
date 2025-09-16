using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Models;

namespace CsharpStudy.Network.Mappers;

public class PokemonMapper
{

    public static Pokemon ToModel(PokemonDto dto)
    {
        return new Pokemon(
            id: dto.Id,
            name: dto.Name ?? "",
            image: dto.DefaultSpriteUrl ?? ""
            );
    }
    
}



public static class SubwayArrivalMapper
{
    public static SubwayArrival ToModel(this SubwayArrivalDto dto)
    {
        var model = new SubwayArrival();
        
        
        // RealtimeArrivalList 매핑
        if (dto.RealtimeArrivalList != null)
        {
            model.TrainArrivals = dto.RealtimeArrivalList
                .Select(MapToTrainArrivalInfo)
                .ToList();
        }
        
        return model;
    }
    
    private static TrainArrivalInfo MapToTrainArrivalInfo(RealtimeArrival dto)
    {
        return new TrainArrivalInfo
        {
            RowNumber = dto.RowNum,
            SubwayLine = MapToSubwayLine(dto.SubwayId),
            SubwayLineName = GetSubwayLineName(MapToSubwayLine(dto.SubwayId)),
            Direction = MapToTrainDirection(dto.UpDownLine),
            TrainLineName = dto.TrainLineName ?? string.Empty,
            StationId = dto.StationId ?? string.Empty,
            StationName = dto.StationName ?? string.Empty,
            TrainStatus = MapToTrainStatus(dto.TrainStatus),
            ArrivalTimeSeconds = ParseArrivalTime(dto.ArrivalTime),
            TrainNumber = dto.TrainNumber ?? string.Empty,
            DestinationStationName = dto.DestinationStationName ?? string.Empty,
            ReceivedDateTime = ParseDateTime(dto.ReceivedDateTime),
            ArrivalMessage = dto.ArrivalMessage2 ?? string.Empty,
            ArrivalStatus = MapToArrivalStatus(dto.ArrivalCode),
            IsLastCar = dto.LastCarAt == "1"
        };
    }
    
    private static SubwayLine MapToSubwayLine(string? subwayId)
    {
        if (string.IsNullOrEmpty(subwayId) || !int.TryParse(subwayId, out int id))
            return SubwayLine.Unknown;
        
        return id switch
        {
            1001 => SubwayLine.Line1,
            1002 => SubwayLine.Line2,
            1003 => SubwayLine.Line3,
            1004 => SubwayLine.Line4,
            1005 => SubwayLine.Line5,
            1006 => SubwayLine.Line6,
            1007 => SubwayLine.Line7,
            1008 => SubwayLine.Line8,
            1009 => SubwayLine.Line9,
            1063 => SubwayLine.GyeongUiJungAng,
            1065 => SubwayLine.AirportRailroad,
            1075 => SubwayLine.SinBundang,
            1077 => SubwayLine.Suin,
            1067 => SubwayLine.GyeongChun,
            1092 => SubwayLine.UiSinSeol,
            1093 => SubwayLine.SeoHae,
            _ => SubwayLine.Unknown
        };
    }
    
    private static string GetSubwayLineName(SubwayLine line)
    {
        return line switch
        {
            SubwayLine.Line1 => "1호선",
            SubwayLine.Line2 => "2호선",
            SubwayLine.Line3 => "3호선",
            SubwayLine.Line4 => "4호선",
            SubwayLine.Line5 => "5호선",
            SubwayLine.Line6 => "6호선",
            SubwayLine.Line7 => "7호선",
            SubwayLine.Line8 => "8호선",
            SubwayLine.Line9 => "9호선",
            SubwayLine.GyeongUiJungAng => "경의중앙선",
            SubwayLine.AirportRailroad => "공항철도",
            SubwayLine.SinBundang => "신분당선",
            SubwayLine.Suin => "수인선",
            SubwayLine.GyeongChun => "경춘선",
            SubwayLine.UiSinSeol => "우이신설선",
            SubwayLine.SeoHae => "서해선",
            _ => "알 수 없음"
        };
    }
    
    private static TrainDirection MapToTrainDirection(string? direction)
    {
        if (string.IsNullOrEmpty(direction))
            return TrainDirection.Unknown;
        
        return direction switch
        {
            "상행" => TrainDirection.Upward,
            "하행" => TrainDirection.Downward,
            _ => TrainDirection.Unknown
        };
    }
    
    private static TrainStatus MapToTrainStatus(string? status)
    {
        if (string.IsNullOrEmpty(status))
            return TrainStatus.Regular;
        
        return status switch
        {
            "급행" => TrainStatus.Express,
            "특급" => TrainStatus.Limited,
            "일반" => TrainStatus.Regular,
            _ when status.Contains("급행") => TrainStatus.Express,
            _ when status.Contains("특급") => TrainStatus.Limited,
            _ => TrainStatus.Regular
        };
    }
    
    private static ArrivalStatus MapToArrivalStatus(string? code)
    {
        if (string.IsNullOrEmpty(code))
            return ArrivalStatus.Unknown;
        
        return code switch
        {
            "0" => ArrivalStatus.Entering,      // 진입
            "1" => ArrivalStatus.Arrived,       // 도착
            "2" => ArrivalStatus.Departed,      // 출발
            "3" => ArrivalStatus.PreviousStation, // 전역출발
            "4" => ArrivalStatus.Running,       // 운행중
            "5" => ArrivalStatus.PreviousArrived, // 전역도착
            _ => ArrivalStatus.Unknown
        };
    }
    
    private static int ParseArrivalTime(string? arrivalTime)
    {
        if (string.IsNullOrEmpty(arrivalTime) || !int.TryParse(arrivalTime, out int time))
            return 0;
        
        return Math.Max(0, time); // 음수 방지
    }
    
    private static DateTime ParseDateTime(string? dateTimeStr)
    {
        if (string.IsNullOrEmpty(dateTimeStr))
            return DateTime.MinValue;
        
        if (DateTime.TryParse(dateTimeStr, out DateTime result))
            return result;
        
        return DateTime.MinValue;
    }
}