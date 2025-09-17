using CshapStudy.realtimeStationArrival.Common;
using CshapStudy.realtimeStationArrival.DataSources;
using CshapStudy.realtimeStationArrival.Models;
using CshapStudy.realtimeStationArrival.Repositories;

namespace CshapStudy.realtimeStationArrival;

class Program
{
    static async Task Main(string[] args)
    {
        IStationApiDataSource dataSource = new StationApiDataSource(new HttpClient());
        IStationRepository repository = new StationRepository(dataSource);

        var stationName = "온수";

        Console.WriteLine($"'{stationName}'역 실시간 도착 정보 가져오는 중...");

        var result = await repository.GetStationAsync(stationName);

        // Check if the result is a 'Success' record and extract its data
        if (result is Result<List<Station>, StationError>.Success successResult)
        {
            var arrivals = successResult.data; 

            if (!arrivals.Any())
            {
                Console.WriteLine("정보를 찾을 수 없거나 오류가 발생했습니다.");
            }
            else
            {
                Console.WriteLine("--- 도착 정보 ---");

                foreach (var arrival in arrivals)
                {
                    Console.WriteLine($"[호선: {arrival.CurrentLocationMessage}] [방면: {arrival.TrainLineName}] -> {arrival.ArvlMsg2}");
                }
            }
        }
        else if (result is Result<List<Station>, StationError>.Error errorResult)
        {
            Console.WriteLine($"오류 발생: {errorResult.error}"); // Access the error property of the Error record
        }
    }
}
