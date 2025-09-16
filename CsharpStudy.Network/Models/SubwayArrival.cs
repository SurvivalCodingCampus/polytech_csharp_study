// 열차 상태 enum
public enum TrainStatus
{
    Unknown = 0,
    Regular = 1,    // 일반
    Express = 2,    // 급행
    Limited = 3     // 특급
}

// 상행/하행 구분 enum
public enum TrainDirection
{
    Unknown = 0,
    Upward = 1,     // 상행
    Downward = 2    // 하행
}

// 도착 상태 코드 enum
public enum ArrivalStatus
{
    Unknown = 0,
    Entering = 1,       // 진입 (arvlCd: 0)
    Arrived = 2,        // 도착 (arvlCd: 1)
    Departed = 3,       // 출발 (arvlCd: 2)
    PreviousStation = 4, // 전역출발 (arvlCd: 3)
    PreviousArrived = 5, // 전역도착 (arvlCd: 5)
    Running = 6         // 운행중 (arvlCd: 4)
}

// 지하철 노선 enum
public enum SubwayLine
{
    Unknown = 0,
    Line1 = 1001,              // 1호선
    Line2 = 1002,              // 2호선
    Line3 = 1003,              // 3호선
    Line4 = 1004,              // 4호선
    Line5 = 1005,              // 5호선
    Line6 = 1006,              // 6호선
    Line7 = 1007,              // 7호선
    Line8 = 1008,              // 8호선
    Line9 = 1009,              // 9호선
    GyeongUiJungAng = 1063,    // 경의중앙선
    AirportRailroad = 1065,    // 공항철도
    SinBundang = 1075,         // 신분당선
    Suin = 1077,               // 수인선
    GyeongChun = 1067,         // 경춘선
    UiSinSeol = 1092,          // 우이신설선
    SeoHae = 1093              // 서해선
}

// 비즈니스 모델 - 실시간 열차 도착 정보
public class TrainArrivalInfo
{
    public int RowNumber { get; set; }
    public SubwayLine SubwayLine { get; set; }
    public string SubwayLineName { get; set; } = string.Empty;
    public TrainDirection Direction { get; set; }
    public string TrainLineName { get; set; } = string.Empty;
    public string StationId { get; set; } = string.Empty;
    public string StationName { get; set; } = string.Empty;
    public TrainStatus TrainStatus { get; set; }
    public int ArrivalTimeSeconds { get; set; }
    public string TrainNumber { get; set; } = string.Empty;
    public string DestinationStationName { get; set; } = string.Empty;
    public DateTime ReceivedDateTime { get; set; }
    public string ArrivalMessage { get; set; } = string.Empty;
    public ArrivalStatus ArrivalStatus { get; set; }
    public bool IsLastCar { get; set; }
    
    // 계산된 속성들
    public TimeSpan ArrivalTime => TimeSpan.FromSeconds(ArrivalTimeSeconds);
    public bool IsArriving => ArrivalTimeSeconds <= 60; // 1분 이내
    public bool IsImminent => ArrivalTimeSeconds <= 30; // 30초 이내
    public bool HasDeparted => ArrivalStatus == ArrivalStatus.Departed;
    public bool IsAtStation => ArrivalStatus == ArrivalStatus.Arrived || ArrivalStatus == ArrivalStatus.Entering;
    
    public string FormattedArrivalTime
    {
        get
        {
            if (HasDeparted || ArrivalTimeSeconds == 0)
                return ArrivalMessage;
            
            if (ArrivalTimeSeconds < 60)
                return $"{ArrivalTimeSeconds}초 후 도착";
            
            var minutes = ArrivalTimeSeconds / 60;
            var seconds = ArrivalTimeSeconds % 60;
            
            return seconds > 0 ? $"{minutes}분 {seconds}초 후 도착" : $"{minutes}분 후 도착";
        }
    }
    
    public string DirectionText => Direction switch
    {
        TrainDirection.Upward => "상행",
        TrainDirection.Downward => "하행",
        _ => "미정"
    };
    
    public string StatusText => TrainStatus switch
    {
        TrainStatus.Express => "급행",
        TrainStatus.Limited => "특급",
        TrainStatus.Regular => "일반",
        _ => "일반"
    };
}

// 비즈니스 모델 - 지하철 도착 정보 전체
public class SubwayArrival
{
    public List<TrainArrivalInfo> TrainArrivals { get; set; } = new();
    
    // 계산된 속성들
    public int TotalTrains => TrainArrivals.Count;
    
    public IEnumerable<TrainArrivalInfo> UpwardTrains => 
        TrainArrivals.Where(t => t.Direction == TrainDirection.Upward);
    
    public IEnumerable<TrainArrivalInfo> DownwardTrains => 
        TrainArrivals.Where(t => t.Direction == TrainDirection.Downward);
    
    public IEnumerable<TrainArrivalInfo> ExpressTrains => 
        TrainArrivals.Where(t => t.TrainStatus == TrainStatus.Express);
    
    public IEnumerable<TrainArrivalInfo> RegularTrains => 
        TrainArrivals.Where(t => t.TrainStatus == TrainStatus.Regular);
    
    public IEnumerable<TrainArrivalInfo> ArrivingTrains => 
        TrainArrivals.Where(t => t.IsArriving && !t.HasDeparted);
    
    public Dictionary<SubwayLine, List<TrainArrivalInfo>> TrainsByLine =>
        TrainArrivals
            .Where(t => t.SubwayLine != SubwayLine.Unknown)
            .GroupBy(t => t.SubwayLine)
            .ToDictionary(g => g.Key, g => g.ToList());
    
    public TrainArrivalInfo? NextUpwardTrain => 
        UpwardTrains
            .Where(t => !t.HasDeparted && t.ArrivalTimeSeconds > 0)
            .OrderBy(t => t.ArrivalTimeSeconds)
            .FirstOrDefault();
    
    public TrainArrivalInfo? NextDownwardTrain => 
        DownwardTrains
            .Where(t => !t.HasDeparted && t.ArrivalTimeSeconds > 0)
            .OrderBy(t => t.ArrivalTimeSeconds)
            .FirstOrDefault();
    
    public TrainArrivalInfo? NextTrain => 
        TrainArrivals
            .Where(t => !t.HasDeparted && t.ArrivalTimeSeconds > 0)
            .OrderBy(t => t.ArrivalTimeSeconds)
            .FirstOrDefault();
}
