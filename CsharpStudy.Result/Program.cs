using CsharpStudy.Result.Models;
using System.Collections.Generic;
using System.Web;
using CsharpStudy.Result.Dtos;
using CsharpStudy.Result.Mappers;
using CsharpStudy.Result.DataSources;
using CsharpStudy.Result.Repositories;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        ISubwayApiDataSource dataSource = new SubwayApiDataSource(httpClient);
        ISubwayRepository repository = new SubwayRepository(dataSource);

       var stationName = "서울";
        var result = await repository.GetSubwayByNameAsync(stationName);

        if (result is Result<List<Subway>, SubwayError>.Success successResult)
        {
            Console.WriteLine($"Status: 성공");

            if (successResult.data.Count > 0)
            {
                foreach (var subway in successResult.data)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine($"지하철 ID: {subway.SubwayId}");
                    Console.WriteLine($"열차 노선: {subway.TrainLineNm}");
                    Console.WriteLine($"열차 상태: {subway.BtrainSttus}");
                    Console.WriteLine($"도착 메시지: {subway.ArvlMsg2}");
                }
            }
            else
            {
                Console.WriteLine("도착 정보가 없습니다.");
            }
        }
        else if (result is Result<List<Subway>, SubwayError>.Error errorResult)
        {
            Console.WriteLine($"오류 발생: {errorResult.error}");
        }
    }
}

