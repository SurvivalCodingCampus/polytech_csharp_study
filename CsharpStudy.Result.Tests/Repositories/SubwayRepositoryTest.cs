using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Result.Common;
using CsharpStudy.Result.DataSources;
using CsharpStudy.Result.DTOs;
using CsharpStudy.Result.Models;
using CsharpStudy.Result.Repositories;

using NUnit.Framework;
namespace CsharpStudy.Result.Tests.Repositories;

[TestFixture]
[TestOf(typeof(SubwayRepository<SubwayDto>))]
public class SubwayRepositoryTest
{

    [Test]
    public async Task getSubwayInfoTest()
    {
        ISubwayApiDataSource<SubwayDto> dataSource = new SubwayApiDataSource(new HttpClient());
        SubwayRepository<SubwayDto> subwayRepository = new SubwayRepository<SubwayDto>(dataSource);

        Result<Subway, SubwayError> result = await subwayRepository.GetSubwayByNameAsync("서울");
        
        switch (result)
        {
            // Success case
            
            case Result<Subway, SubwayError>.Success success:
                Console.WriteLine("지하철 정보를 성공적으로 가져왔습니다.");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"역 이름: {success.data.StationName}");
                Console.WriteLine($"노선명: {success.data.TrainLineNum}");
                Console.WriteLine($"도착 정보: {success.data.Massage}");
                Console.WriteLine($"지하철 ID: {success.data.SubwayId}");
                break;

            // Error case
            case Result<Subway, SubwayError>.Error error:
                Console.WriteLine("지하철 정보를 가져오는 데 실패했습니다.");
                Console.WriteLine("-----------------------------");
                switch (error.error)
                {
                    case SubwayError.InvalidInput:
                        Console.WriteLine("오류: 잘못된 입력입니다. 역 이름을 다시 확인해주세요.");
                        break;
                    case SubwayError.NotFound:
                        Console.WriteLine("오류: 해당 지하철 역 정보를 찾을 수 없습니다.");
                        break;
                    case SubwayError.NetworkError:
                        Console.WriteLine("오류: 네트워크 연결에 문제가 발생했습니다.");
                        break;
                    case SubwayError.UnknownError:
                        Console.WriteLine("오류: 알 수 없는 서버 오류가 발생했습니다.");
                        break;
                    default:
                        Console.WriteLine($"알 수 없는 오류: {error.error}");
                        break;
                }
                break;
        }
    }
}