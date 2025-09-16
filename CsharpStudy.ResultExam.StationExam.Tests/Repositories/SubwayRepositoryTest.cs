using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Result.Subway.Repositories;
using CsharpStudy.ResultExam.SubwayExam.Common;
using CsharpStudy.ResultExam.SubwayExam.DataSource;
using CsharpStudy.ResultExam.SubwayExam.DTO;
using CsharpStudy.ResultExam.SubwayExam.Models;
using CsharpStudy.ResultExam.SubwayExam.Repositories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsharpStudy.ResultExam.StationExam.Tests.Repositories;

[TestFixture]
[TestOf(typeof(SubwayRepository))]
public class SubwayRepositoryTest
{
    [Test]
    public async Task Result_Test()
    {
        //ISubwayRepository repository = new SubwayRepository(new SubwayApiDataSource(new HttpClient()));
        ISubwayRepository repository = new SubwayRepository(new MockErrorDataSource());

        Result<List<Subway>, SubwayError> subwayResult = await repository.GetSubwayByEndStationNameAsync("서울");
        Assert.That(subwayResult is Result<List<Subway>, SubwayError>.Success, Is.True);

        List<Subway> subway = (subwayResult as Result<List<Subway>, SubwayError>.Success)!.data;
        Assert.That(subway[0].EndStationName, Is.EqualTo("광운대"));
    }


    [Test]
    public async Task Result_Fail_Test()
    {
        ISubwayRepository repository = new SubwayRepository(new MockErrorDataSource());
        // 404
        Result<List<Subway>, SubwayError> result = await repository.GetSubwayByEndStationNameAsync("404");
        Assert.That(result is Result<List<Subway>, SubwayError>.Error, Is.True);

        SubwayError error = (result as Result<List<Subway>, SubwayError>.Error)!.error;
        Assert.That(error == SubwayError.NotFound, Is.True);
    }
}

class MockErrorDataSource : ISubwayApiDataSource
{
    public async Task<Response<SubwayArrivalDto>> GetSubwayArrivalAsync(string stationName)
    {
        if (stationName == "404")
        {
            return new Response<SubwayArrivalDto>(
                404,
                new Dictionary<string, string>(),
                new SubwayArrivalDto()
            );
        }

        if (stationName == "서울")
        {
            return new Response<SubwayArrivalDto>(
                200,
                new Dictionary<string, string>(),
                JsonConvert.DeserializeObject<SubwayArrivalDto>(mockData)!
            );
        }


        if (stationName == "NetworkError")
        {
            throw new ArgumentException("NetworkError");
        }


        return new Response<SubwayArrivalDto>(
            -1,
            new Dictionary<string, string>(),
            new SubwayArrivalDto()
        );
        //throw new System.NotImplementedException();
    }

    private string mockData = @"{
  ""errorMessage"": {
    ""status"": 200,
    ""code"": ""INFO-000"",
    ""message"": ""정상 처리되었습니다."",
    ""link"": """",
    ""developerMessage"": """",
    ""total"": 20
  },
  ""realtimeArrivalList"": [
    {
      ""beginRow"": null,
      ""endRow"": null,
      ""curPage"": null,
      ""pageRow"": null,
      ""totalCount"": 20,
      ""rowNum"": 1,
      ""selectedCount"": 5,
      ""subwayId"": ""1001"",
      ""subwayNm"": null,
      ""updnLine"": ""상행"",
      ""trainLineNm"": ""광운대행 - 시청방면"",
      ""subwayHeading"": null,
      ""statnFid"": ""1001000134"",
      ""statnTid"": ""1001000132"",
      ""statnId"": ""1001000133"",
      ""statnNm"": ""서울"",
      ""trainCo"": null,
      ""trnsitCo"": ""4"",
      ""ordkey"": ""01000광운대0"",
      ""subwayList"": ""1001,1004,1063,1065"",
      ""statnList"": ""1001000133,1004000426,1063080313,1065006501"",
      ""btrainSttus"": ""일반"",
      ""barvlDt"": ""10"",
      ""btrainNo"": ""0664"",
      ""bstatnId"": ""1001000119"",
      ""bstatnNm"": ""광운대"",
      ""recptnDt"": ""2025-09-16 17:11:50"",
      ""arvlMsg2"": ""서울 진입"",
      ""arvlMsg3"": ""서울"",
      ""arvlCd"": ""0"",
      ""lstcarAt"": ""0""
    },
    {
      ""beginRow"": null,
      ""endRow"": null,
      ""curPage"": null,
      ""pageRow"": null,
      ""totalCount"": 20,
      ""rowNum"": 2,
      ""selectedCount"": 5,
      ""subwayId"": ""1065"",
      ""subwayNm"": null,
      ""updnLine"": ""상행"",
      ""trainLineNm"": ""인천공항2터미널행 - 공덕방면"",
      ""subwayHeading"": null,
      ""statnFid"": ""1065006502"",
      ""statnTid"": ""1065006501"",
      ""statnId"": ""1065006501"",
      ""statnNm"": ""서울"",
      ""trainCo"": null,
      ""trnsitCo"": ""4"",
      ""ordkey"": ""01000인천공항2터미널0"",
      ""subwayList"": ""1001,1004,1063,1065"",
      ""statnList"": ""1001000133,1004000426,1063080313,1065006501"",
      ""btrainSttus"": ""일반"",
      ""barvlDt"": ""0"",
      ""btrainNo"": ""A2121"",
      ""bstatnId"": ""1065006511"",
      ""bstatnNm"": ""인천공항2터미널"",
      ""recptnDt"": ""2025-09-16 17:09:41"",
      ""arvlMsg2"": ""서울 출발"",
      ""arvlMsg3"": ""서울"",
      ""arvlCd"": ""2"",
      ""lstcarAt"": ""0""
    },
    {
      ""beginRow"": null,
      ""endRow"": null,
      ""curPage"": null,
      ""pageRow"": null,
      ""totalCount"": 20,
      ""rowNum"": 3,
      ""selectedCount"": 5,
      ""subwayId"": ""1001"",
      ""subwayNm"": null,
      ""updnLine"": ""상행"",
      ""trainLineNm"": ""광운대행 - 시청방면"",
      ""subwayHeading"": null,
      ""statnFid"": ""1001000134"",
      ""statnTid"": ""1001000132"",
      ""statnId"": ""1001000133"",
      ""statnNm"": ""서울"",
      ""trainCo"": null,
      ""trnsitCo"": ""4"",
      ""ordkey"": ""01001광운대0"",
      ""subwayList"": ""1001,1004,1063,1065"",
      ""statnList"": ""1001000133,1004000426,1063080313,1065006501"",
      ""btrainSttus"": ""일반"",
      ""barvlDt"": ""0"",
      ""btrainNo"": ""0664"",
      ""bstatnId"": ""1001000119"",
      ""bstatnNm"": ""광운대"",
      ""recptnDt"": ""2025-09-16 17:08:29"",
      ""arvlMsg2"": ""전역 도착"",
      ""arvlMsg3"": ""남영"",
      ""arvlCd"": ""5"",
      ""lstcarAt"": ""0""
    },
    {
      ""beginRow"": null,
      ""endRow"": null,
      ""curPage"": null,
      ""pageRow"": null,
      ""totalCount"": 20,
      ""rowNum"": 4,
      ""selectedCount"": 5,
      ""subwayId"": ""1004"",
      ""subwayNm"": null,
      ""updnLine"": ""상행"",
      ""trainLineNm"": ""불암산행 - 회현방면"",
      ""subwayHeading"": null,
      ""statnFid"": ""1004000427"",
      ""statnTid"": ""1004000425"",
      ""statnId"": ""1004000426"",
      ""statnNm"": ""서울"",
      ""trainCo"": null,
      ""trnsitCo"": ""4"",
      ""ordkey"": ""01002불암산0"",
      ""subwayList"": ""1001,1004,1063,1065"",
      ""statnList"": ""1001000133,1004000426,1063080313,1065006501"",
      ""btrainSttus"": ""일반"",
      ""barvlDt"": ""238"",
      ""btrainNo"": ""4634"",
      ""bstatnId"": ""1004000409"",
      ""bstatnNm"": ""불암산"",
      ""recptnDt"": ""2025-09-16 17:11:25"",
      ""arvlMsg2"": ""3분 58초 후 (삼각지)"",
      ""arvlMsg3"": ""삼각지"",
      ""arvlCd"": ""99"",
      ""lstcarAt"": ""0""
    },
    {
      ""beginRow"": null,
      ""endRow"": null,
      ""curPage"": null,
      ""pageRow"": null,
      ""totalCount"": 20,
      ""rowNum"": 5,
      ""selectedCount"": 5,
      ""subwayId"": ""1001"",
      ""subwayNm"": null,
      ""updnLine"": ""상행"",
      ""trainLineNm"": ""청량리행 - 시청방면"",
      ""subwayHeading"": null,
      ""statnFid"": ""1001000134"",
      ""statnTid"": ""1001000132"",
      ""statnId"": ""1001000133"",
      ""statnNm"": ""서울"",
      ""trainCo"": null,
      ""trnsitCo"": ""4"",
      ""ordkey"": ""01014청량리0"",
      ""subwayList"": ""1001,1004,1063,1065"",
      ""statnList"": ""1001000133,1004000426,1063080313,1065006501"",
      ""btrainSttus"": ""일반"",
      ""barvlDt"": ""0"",
      ""btrainNo"": ""1936"",
      ""bstatnId"": ""1001000124"",
      ""bstatnNm"": ""청량리"",
      ""recptnDt"": ""2025-09-16 17:04:38"",
      ""arvlMsg2"": ""[14]번째 전역 (안양)"",
      ""arvlMsg3"": ""안양"",
      ""arvlCd"": ""99"",
      ""lstcarAt"": ""0""
    }
  ]
}";
}