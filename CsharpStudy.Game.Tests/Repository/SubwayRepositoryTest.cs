using System;
using System.Net.Http;
using System.Threading.Tasks;
using CshapStudy.SubwayData.Common;
using CshapStudy.SubwayData.DTO;
using CshapStudy.SubwayData.Model;
using CshapStudy.SubwayData.Repository;
using CsharpStudy.HttpPokeMon.DataSources;
using CsharpStudy.HttpPokeMon.DTO;
using CsharpStudy.HttpPokeMon.Models;
using CsharpStudy.HttpPokeMon.Repository;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Repository;

[TestFixture]
[TestOf(typeof(SubwayRepository<SubwayDto>))]
public class SubwayRepositoryTest
{

    [Test]
    public async Task METHOD()
    {
        ISubwayApiDataSource<SubwayDto> dataSource = new RemoteSubwayDataSource(new HttpClient());
        SubwayRepository<SubwayDto> subwayRepository = new SubwayRepository<SubwayDto>(dataSource);

        var result = await subwayRepository.GetSubwayByNameAsync("서울");

        switch (result)
        {
            case Result<Subway, SubwayError>.Success subwayResult:
                Console.WriteLine($"역명: {subwayResult.data.Name}");
                Console.WriteLine($"노선: {subwayResult.data.TrainLineNum}");
                Console.WriteLine($"도착정보: {subwayResult.data.time}");
                Console.WriteLine($"ID: {subwayResult.data.id}");
                break;
            case Result<Subway, SubwayError>.Error subwayError:
                switch (subwayError.error)
                {
                    case SubwayError.NotFound:
                        Console.WriteLine("오류: 해당 역을 찾을 수 없습니다.");
                        break;
                    case SubwayError.NetworkTimeout:
                        Console.WriteLine("오류: 네트워크 연결 시간 초과.");
                        break;
                    default:
                        Console.WriteLine("알 수 없는 오류가 발생했습니다");
                        break;
                }
                break;
        }   
    }
}
