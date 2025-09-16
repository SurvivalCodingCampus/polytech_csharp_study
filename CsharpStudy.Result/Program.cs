using CsharpStudy.Result.Models;
using System.Collections.Generic;
using System.Web;
using CsharpStudy.Result.Dtos;
using CsharpStudy.Result.Mappers;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var stationName = "서울";
        
        try
        {
            // 1. API 호출
            var client = new HttpClient();
            string encodedStationName = HttpUtility.UrlEncode(stationName);
            string url = $"http://swopenAPI.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/{encodedStationName}";

            var response = await client.GetStringAsync(url);

            // 2. JSON Deserialization (DTOs 사용)
            var apiResponse = JsonConvert.DeserializeObject<ApiResponseDto>(response);

            // 3. 모델로 매핑 및 출력
            Console.WriteLine($"'{stationName}'역 실시간 도착 정보:");
            
            if (apiResponse?.RealtimeArrivalList != null)
            {
                foreach (var dto in apiResponse.RealtimeArrivalList)
                {
                    var subwayModel = dto.ToModel(); // DTO를 모델로 변환
                    
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine($"지하철 ID: {subwayModel.SubwayId}");
                    Console.WriteLine($"열차 노선: {subwayModel.TrainLineNm}");
                    Console.WriteLine($"열차 상태: {subwayModel.BtrainSttus}");
                    Console.WriteLine($"도착 메시지: {subwayModel.ArvlMsg2}");
                }
            }
            else
            {
                Console.WriteLine("도착 정보가 없습니다.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"오류 발생: {ex.Message}");
        }
    }
}