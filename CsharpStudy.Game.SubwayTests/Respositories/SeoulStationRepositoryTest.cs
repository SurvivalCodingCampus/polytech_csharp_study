using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Subway.Common;
using CsharpStudy.Subway.DataSources;
using CsharpStudy.Subway.Models;
using CsharpStudy.Subway.Respositories;
using NUnit.Framework;

namespace CsharpStudy.Game.SubwayTests.Respositories;

[TestFixture]
[TestOf(typeof(SeoulStationRepository))]
public class SeoulStationRepositoryTest
{

    [Test]
    public async Task Result()
    {
       ISeoulStationRepository repository = new SeoulStationRepository(new SeoulStationApiDataSource(new HttpClient()));
       

       Result<SeoulStation, SeoulStationError> result = await repository.GetSeoulStationNameAsync("서울");
       
       Assert.That(result is Result<SeoulStation, SeoulStationError>.Success, Is.True);
       
       SeoulStation seoulStation = (result as Result<SeoulStation, SeoulStationError>.Success)!.Data;
       Assert.That(seoulStation.Name, Is.EqualTo("서울"));
       
    }

    [Test]
    public async Task Result_Fail_Test()
    {
        ISeoulStationRepository repository = new SeoulStationRepository(new MockErrorDatasource());

        Result<SeoulStation, SeoulStationError> result = await repository.GetSeoulStationNameAsync("404");
        
        Assert.That(result is Result<SeoulStation, SeoulStationError>.Error, Is.True);
        
        SeoulStationError error = (result as Result<SeoulStation, SeoulStationError>.Error)!.error;
        Assert.That(error == SeoulStationError.NotFound, Is.True);
        
        result = await repository.GetSeoulStationNameAsync("NetworkError");
        Assert.That(result is Result<SeoulStation, SeoulStationError>.Error, Is.True);
            
        error = (result as Result<SeoulStation, SeoulStationError>.Error)!.error;
        Assert.That(error == SeoulStationError.NetworkError, Is.True);
        
        result = await repository.GetSeoulStationNameAsync("1111");
        
        Assert.That(result is Result<SeoulStation, SeoulStationError>.Error, Is.True);
        
        error = (result as Result<SeoulStation, SeoulStationError>.Error)!.error;
        Assert.That(error == SeoulStationError.UnknownError, Is.True);

    }
    
    class MockErrorDatasource : ISeoulStationApiDataSource
    {
        public async Task<Response<SeoulStationDto>> GetSeoulStationAsync(string stationName)
        {
            if (stationName == "404")
            {
                return new Response<SeoulStationDto>(
                    404,
                    new Dictionary<string, string>(),
                    new SeoulStationDto());
            }

            if (stationName == "NetworkError")
            {
                throw new ArgumentException("NetworkError");
            }
            return new Response<SeoulStationDto>(
                -1,
                new Dictionary<string, string>(),
                new SeoulStationDto());
        }
    }
}

