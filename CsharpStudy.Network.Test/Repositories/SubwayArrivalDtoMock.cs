using System;
using System.Collections.Generic;
using CsharpStudy.Network.DTOs;

namespace CsharpStudy.Network.Test.Repositories;

public static class SubwayArrivalMockData
{
    /// <summary>
    /// 성공적인 응답 - 서울역 실시간 도착 정보
    /// </summary>
    public static SubwayArrivalDto CreateSuccessfulResponse()
    {
        return new SubwayArrivalDto
        {
            ErrorMessage = new ErrorMessage
            {
                Status = 200,
                Code = "INFO-000",
                Message = "정상 처리되었습니다.",
                Link = "",
                DeveloperMessage = "",
                Total = 8
            },
            RealtimeArrivalList = new List<RealtimeArrival>
            {
                // 1호선 상행 - 곧 도착
                new RealtimeArrival
                {
                    RowNum = 1,
                    TotalCount = 8,
                    SelectedCount = 8,
                    SubwayId = "1001",
                    SubwayName = null,
                    UpDownLine = "상행",
                    TrainLineName = "양주행 - 시청방면",
                    SubwayHeading = null,
                    StationFromId = "1001000134",
                    StationToId = "1001000132",
                    StationId = "1001000133",
                    StationName = "서울",
                    TrainCo = null,
                    TransitCo = "4",
                    OrderKey = "01001양주0",
                    SubwayList = "1001,1004,1063,1065",
                    StationList = "1001000133,1004000426,1063080313,1065006501",
                    TrainStatus = "일반",
                    ArrivalTime = "45",
                    TrainNumber = "0096",
                    DestinationStationId = "1001000107",
                    DestinationStationName = "양주",
                    ReceivedDateTime = "2025-09-16 14:15:30",
                    ArrivalMessage2 = "45초 후 도착",
                    ArrivalMessage3 = "남영",
                    ArrivalCode = "3",
                    LastCarAt = "0"
                },
                
            }
        };
    }
    
    /// <summary>
    /// 에러 응답 - API 오류
    /// </summary>
    public static SubwayArrivalDto CreateErrorResponse()
    {
        return new SubwayArrivalDto
        {
            ErrorMessage = new ErrorMessage
            {
                Status = 500,
                Code = "ERROR-500",
                Message = "서버 내부 오류가 발생했습니다.",
                Link = "",
                DeveloperMessage = "Database connection failed",
                Total = 0
            },
            RealtimeArrivalList = null
        };
    }
    
    /// <summary>
    /// 데이터 없음 응답 - 운행 중단
    /// </summary>
    public static SubwayArrivalDto CreateNoDataResponse()
    {
        return new SubwayArrivalDto
        {
            ErrorMessage = new ErrorMessage
            {
                Status = 200,
                Code = "INFO-200",
                Message = "해당하는 데이터가 없습니다.",
                Link = "",
                DeveloperMessage = "",
                Total = 0
            },
            RealtimeArrivalList = new List<RealtimeArrival>()
        };
    }
    
    /// <summary>
    /// 단일 열차 응답 - 막차 시간대
    /// </summary>
    public static SubwayArrivalDto CreateSingleTrainResponse()
    {
        return new SubwayArrivalDto
        {
            ErrorMessage = new ErrorMessage
            {
                Status = 200,
                Code = "INFO-000",
                Message = "정상 처리되었습니다.",
                Link = "",
                DeveloperMessage = "",
                Total = 1
            },
            RealtimeArrivalList = new List<RealtimeArrival>
            {
                new RealtimeArrival
                {
                    RowNum = 1,
                    TotalCount = 1,
                    SelectedCount = 1,
                    SubwayId = "1001",
                    SubwayName = null,
                    UpDownLine = "상행",
                    TrainLineName = "양주행 - 시청방면 (막차)",
                    SubwayHeading = null,
                    StationFromId = "1001000134",
                    StationToId = "1001000132",
                    StationId = "1001000133",
                    StationName = "서울",
                    TrainCo = null,
                    TransitCo = "4",
                    OrderKey = "01001양주0",
                    SubwayList = "1001",
                    StationList = "1001000133",
                    TrainStatus = "일반",
                    ArrivalTime = "480",
                    TrainNumber = "막차",
                    DestinationStationId = "1001000107",
                    DestinationStationName = "양주",
                    ReceivedDateTime = "2025-09-16 23:45:30",
                    ArrivalMessage2 = "8분 후 도착 (막차)",
                    ArrivalMessage3 = "남영",
                    ArrivalCode = "4",
                    LastCarAt = "0"
                }
            }
        };
    }
    
    /// <summary>
    /// 혼잡 시간대 응답 - 출퇴근 시간
    /// </summary>
    public static SubwayArrivalDto CreateRushHourResponse()
    {
        return new SubwayArrivalDto
        {
            ErrorMessage = new ErrorMessage
            {
                Status = 200,
                Code = "INFO-000",
                Message = "정상 처리되었습니다.",
                Link = "",
                DeveloperMessage = "",
                Total = 12
            },
            RealtimeArrivalList = new List<RealtimeArrival>
            {
                // 여러 열차가 짧은 간격으로 도착
                new RealtimeArrival
                {
                    RowNum = 1,
                    SubwayId = "1001",
                    UpDownLine = "상행",
                    TrainLineName = "양주행",
                    StationName = "서울",
                    TrainStatus = "일반",
                    ArrivalTime = "30",
                    ArrivalMessage2 = "30초 후 도착",
                    ArrivalCode = "3",
                    ReceivedDateTime = "2025-09-16 08:30:00"
                },
                new RealtimeArrival
                {
                    RowNum = 2,
                    SubwayId = "1001",
                    UpDownLine = "상행",
                    TrainLineName = "양주행",
                    StationName = "서울",
                    TrainStatus = "일반",
                    ArrivalTime = "150",
                    ArrivalMessage2 = "2분 후 도착",
                    ArrivalCode = "4",
                    ReceivedDateTime = "2025-09-16 08:30:00"
                },
                new RealtimeArrival
                {
                    RowNum = 3,
                    SubwayId = "1001",
                    UpDownLine = "상행",
                    TrainLineName = "양주행",
                    StationName = "서울",
                    TrainStatus = "일반",
                    ArrivalTime = "270",
                    ArrivalMessage2 = "4분 후 도착",
                    ArrivalCode = "4",
                    ReceivedDateTime = "2025-09-16 08:30:00"
                }
            }
        };
    }
    
    /// <summary>
    /// JSON 문자열로 변환된 Mock 데이터
    /// </summary>
    public static string GetSuccessfulResponseJson()
    {
        return """
               {
                 "errorMessage": {
                   "status": 200,
                   "code": "INFO-000",
                   "message": "정상 처리되었습니다.",
                   "link": "",
                   "developerMessage": "",
                   "total": 3
                 },
                 "realtimeArrivalList": [
                   {
                     "rowNum": 1,
                     "totalCount": 3,
                     "selectedCount": 3,
                     "subwayId": "1001",
                     "updnLine": "상행",
                     "trainLineNm": "양주행 - 시청방면",
                     "statnId": "1001000133",
                     "statnNm": "서울",
                     "btrainSttus": "일반",
                     "barvlDt": "45",
                     "btrainNo": "0096",
                     "bstatnNm": "양주",
                     "recptnDt": "2025-09-16 14:15:30",
                     "arvlMsg2": "45초 후 도착",
                     "arvlMsg3": "남영",
                     "arvlCd": "3",
                     "lstcarAt": "0"
                   },
                   {
                     "rowNum": 2,
                     "totalCount": 3,
                     "selectedCount": 3,
                     "subwayId": "1065",
                     "updnLine": "상행",
                     "trainLineNm": "인천공항2터미널행 - 공덕방면 (급행)",
                     "statnId": "1065006501",
                     "statnNm": "서울",
                     "btrainSttus": "급행",
                     "barvlDt": "0",
                     "btrainNo": "A1025",
                     "bstatnNm": "인천공항2터미널",
                     "recptnDt": "2025-09-16 14:15:29",
                     "arvlMsg2": "서울 진입",
                     "arvlMsg3": "서울",
                     "arvlCd": "0",
                     "lstcarAt": "0"
                   },
                   {
                     "rowNum": 3,
                     "totalCount": 3,
                     "selectedCount": 3,
                     "subwayId": "1004",
                     "updnLine": "하행",
                     "trainLineNm": "안산행 - 숙대입구방면",
                     "statnId": "1004000426",
                     "statnNm": "서울",
                     "btrainSttus": "일반",
                     "barvlDt": "240",
                     "btrainNo": "4501",
                     "bstatnNm": "안산",
                     "recptnDt": "2025-09-16 14:15:30",
                     "arvlMsg2": "4분 후 도착",
                     "arvlMsg3": "숙대입구",
                     "arvlCd": "4",
                     "lstcarAt": "0"
                   }
                 ]
               }
               """;
    }
}

// 테스트 유틸리티 클래스
public static class SubwayTestHelper
{
    /// <summary>
    /// 특정 조건의 Mock 데이터 생성
    /// </summary>
    public static SubwayArrivalDto CreateCustomResponse(
        int trainCount = 5,
        bool includeExpressTrain = true,
        bool includeErrorTrain = false,
        string[] subwayLines = null)
    {
        subwayLines ??= new[] { "1001", "1004", "1065" };
        
        var trains = new List<RealtimeArrival>();
        var random = new Random();
        
        for (int i = 0; i < trainCount; i++)
        {
            var subwayId = subwayLines[i % subwayLines.Length];
            var isExpress = includeExpressTrain && random.Next(3) == 0;
            
            trains.Add(new RealtimeArrival
            {
                RowNum = i + 1,
                SubwayId = subwayId,
                UpDownLine = random.Next(2) == 0 ? "상행" : "하행",
                TrainLineName = GetTrainLineName(subwayId),
                StationName = "서울",
                TrainStatus = isExpress ? "급행" : "일반",
                ArrivalTime = random.Next(0, 600).ToString(),
                TrainNumber = $"T{1000 + i}",
                ArrivalMessage2 = $"{random.Next(1, 10)}분 후 도착",
                ArrivalCode = random.Next(0, 6).ToString(),
                ReceivedDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                LastCarAt = "0"
            });
        }
        
        return new SubwayArrivalDto
        {
            ErrorMessage = new ErrorMessage
            {
                Status = 200,
                Code = "INFO-000",
                Message = "정상 처리되었습니다.",
                Total = trainCount
            },
            RealtimeArrivalList = trains
        };
    }
    
    private static string GetTrainLineName(string subwayId)
    {
        return subwayId switch
        {
            "1001" => "양주행 - 시청방면",
            "1004" => "불암산행 - 회현방면",
            "1065" => "인천공항2터미널행 - 공덕방면",
            "1063" => "문산행 - 신촌방면",
            _ => "목적지행 - 방면"
        };
    }
}