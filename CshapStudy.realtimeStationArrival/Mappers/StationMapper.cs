using CshapStudy.realtimeStationArrival.DTOs;
using CshapStudy.realtimeStationArrival.Models;
using System.Collections.Generic;
using System.Linq;

namespace CshapStudy.realtimeStationArrival.Mappers;

public static class StationMapper
{
    public static List<Station> ToModels(this StationDto dto)
    {

        if (dto?.RealtimeArrivalList == null)
        {
            return new List<Station>();
        }
        
        return dto.RealtimeArrivalList.Select(arrival => new Station(
            trainLineName: arrival.TrainLineNm ?? "정보 없음", 
            destinationStation: arrival.BstatnNm ?? "정보 없음",
            currentLocationMessage: arrival.ArvlMsg3 ?? "정보 없음",
            subwayLineId: arrival.SubwayId ?? "정보 없음"
        )).ToList();
    }
}