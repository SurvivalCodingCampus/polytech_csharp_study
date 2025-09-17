using CsharpStudy.ResultExam.SubwayExam.DTO;

namespace CsharpStudy.ResultExam.SubwayExam.DataSource;

public interface ISubwayApiDataSource
{
    /// <summary>
    /// 특정 역의 실시간 지하철 도착 정보를 비동기적으로 가져옵니다.
    /// </summary>
    /// <param name="stationName">정보를 조회할 지하철역 이름 (예: "서울")</param>
    /// <returns>지하철 도착 정보가 담긴 DTO 객체. 실패 시 null을 반환할 수 있음.</returns>
    Task<Response<SubwayArrivalDto>> GetSubwayArrivalAsync(string stationName);
    // stationName : "서울"
    // BaseUrl링크 뒤에 보길 원하는 특정 url 정보
}