using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CsharpStudy.Network.Datasources;
using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Mappers;
using CsharpStudy.Network.Models;
using CsharpStudy.Network.Repositories;
using NUnit.Framework;
using static CsharpStudy.Network.Test.Repositories.SubwayArrivalMockData;

namespace CsharpStudy.Network.Test.Repositories;

[TestFixture]
[TestOf(typeof(SubwayRepository))]
public class SubwayRepositoryTest
{
    private IDataSource<SubwayArrivalDto> _dataSource;
    private IRepository<Result<SubwayArrival, SubwayApiError>> _repository;

    [SetUp]
    protected void Setup()
    {
        _dataSource = new SubwayApiDatasource();
        _repository = new SubwayRepository(_dataSource);
    }


    [Test]
    [DisplayName("SubwayArrivalDto -> SubwayArrival 변환 테스트")]
    public void Method_3()
    {
        //given
        SubwayArrivalDto subwayArrivalDto = CreateSuccessfulResponse();

        //when
        var subwayArrival = subwayArrivalDto.ToModel();


        // 열차 정보 검증
        Assert.AreEqual(1, subwayArrival.TotalTrains);
        Assert.IsNotNull(subwayArrival.TrainArrivals);
        Assert.AreEqual(1, subwayArrival.TrainArrivals.Count);

        var trainInfo = subwayArrival.TrainArrivals.First();
        Assert.AreEqual(1, trainInfo.RowNumber);
        Assert.AreEqual(SubwayLine.Line1, trainInfo.SubwayLine);
        Assert.AreEqual("1호선", trainInfo.SubwayLineName);
        Assert.AreEqual(TrainDirection.Upward, trainInfo.Direction);
        Assert.AreEqual("상행", trainInfo.DirectionText);
        Assert.AreEqual("양주행 - 시청방면", trainInfo.TrainLineName);
        Assert.AreEqual("서울", trainInfo.StationName);
        Assert.AreEqual(TrainStatus.Regular, trainInfo.TrainStatus);
        Assert.AreEqual("일반", trainInfo.StatusText);
        Assert.AreEqual(45, trainInfo.ArrivalTimeSeconds);
        Assert.AreEqual("0096", trainInfo.TrainNumber);
        Assert.AreEqual("양주", trainInfo.DestinationStationName);
        Assert.AreEqual(ArrivalStatus.PreviousStation, trainInfo.ArrivalStatus);
        Assert.IsFalse(trainInfo.IsLastCar);
    }


    [Test]
    [DisplayName("API 통신 성공하여 200 코드가 반환된다.")]
    public async Task Method_2()
    {
        //given
        string name = "서울";

        //when
        var response = await _dataSource.GetNameAsync(name);

        //then
        Assert.IsNotNull(response);
        Assert.AreEqual(response.StatusCode, 200);
    }

    [Test]
    [DisplayName("역의 정보를 Repository에서 가지고 온다.")]
    public async Task Method_1()
    {
        //given
        string name = "서울";

        //when
        Result<SubwayArrival, SubwayApiError> result = await _repository.GetByNameAsync(name);

        //then
        Assert.IsNotNull(result);
        Assert.That(result is Result<SubwayArrival, SubwayApiError>.Success);
        Result<SubwayArrival, SubwayApiError>.Success success = (Result<SubwayArrival, SubwayApiError>.Success)result;
        Assert.That(success.data.TrainArrivals.First().StationName, Is.EqualTo(name));
    }


    [Test]
    [DisplayName("잘못된 이름를 보내면 Error.NotFound 가 반환된다.")]
    public async Task Method_4()
    {
        //given
        string name = "서울울";

        //when
        Result<SubwayArrival, SubwayApiError> result = await _repository.GetByNameAsync(name);

        //then
        Assert.IsNotNull(result);
        Assert.That(result is Result<SubwayArrival, SubwayApiError>.Error);
        Result<SubwayArrival, SubwayApiError>.Error error = (Result<SubwayArrival, SubwayApiError>.Error)result;
        Assert.That(error.data is SubwayApiError.NotFound);
    }
}