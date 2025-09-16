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
        public Task<Response<ApiResponseDto>> GetSubwayAsync(string stationName)
        {
            if (stationName == "서운")
            {
                // API 응답 구조와 일치하는 ApiResponseDto를 반환
                var notFoundResponse = new Response<ApiResponseDto>(
                    statusCode: 404,
                    headers: new Dictionary<string, string>(),
                    body: null
                );
                return Task.FromResult(notFoundResponse);
            }

            // 성공 시나리오용 목 데이터
            var successResponse = new Response<ApiResponseDto>(
                statusCode: 200,
                headers: new Dictionary<string, string>(),
                body: new ApiResponseDto()
            );
            return Task.FromResult(successResponse);
        }
    }
    
    [Test]
    public async Task WrongStationName_ReturnsNotFoundError()
    {
        // Arrange
        var mockDataSource = new ManualMockSubwayApiDataSource();
        var repository = new SubwayRepository(mockDataSource);

        // Act
        var result = await repository.GetSubwayByNameAsync("서운");

        // Assert
        if (result is Result<List<Subway>, SubwayError>.Error errorResult)
        {
            Assert.That(errorResult.error, Is.EqualTo(SubwayError.NotFound));
        }
        else
        {
            Assert.Fail("The result was not an expected error.");
        }
    }
}