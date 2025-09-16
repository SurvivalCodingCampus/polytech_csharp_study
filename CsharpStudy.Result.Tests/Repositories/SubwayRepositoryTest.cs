using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CsharpStudy.Result.DataSources;
using CsharpStudy.Result.Dtos;
using CsharpStudy.Result.Models;
using CsharpStudy.Result.Repositories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsharpStudy.Result.Tests.Repositories;

[TestFixture]
[TestOf(typeof(SubwayRepository))]
public class SubwayRepositoryTest
{
    public class ManualMockSubwayApiDataSource : ISubwayApiDataSource
    {
        public Task<Response<SubwayDto>> GetSubwayAsync(string stationName)
        {
            // "서운"이라는 역 이름이 들어오면 404 Not Found 응답을 반환
            if (stationName == "서운")
            {
                var notFoundResponse = new Response<SubwayDto>(
                    statusCode: 404,
                    headers: new Dictionary<string, string>(),
                    body: null
                );
                return Task.FromResult(notFoundResponse);
            }

            // 다른 역 이름은 필요에 따라 성공 응답 등을 구현할 수 있습니다.
            var successResponse = new Response<SubwayDto>(
                statusCode: 200,
                headers: new Dictionary<string, string>(),
                body: new SubwayDto() // 예시로 빈 DTO 객체 반환
            );
            return Task.FromResult(successResponse);
        }
    }
    
    [Test]
    public async Task WrongStationName_ReturnsNotFoundError()
    {
        var mockDataSource = new ManualMockSubwayApiDataSource();
        var repository = new SubwayRepository(mockDataSource);

        // Act
        // 잘못된 역 이름으로 메서드 호출
        var result = await repository.GetSubwayByNameAsync("서운");

        // Assert
        // Result가 Error 타입인지, 그리고 그 오류 타입이 SubwayError.NotFound인지 확인
        if (result is Result<Subway, SubwayError>.Error errorResult)
        {
            Assert.That(errorResult.error, Is.EqualTo(SubwayError.NotFound));
        }
        else
        {
            // 예상치 못한 결과가 나오면 테스트를 실패시킵니다.
            Assert.Fail("The result was not an expected error.");
        }
    }
}