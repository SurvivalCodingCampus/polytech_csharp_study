using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.SubwayExam.Core;
using CsharpStudy.SubwayExam.DataSources;
using CsharpStudy.SubwayExam.DTOs;
using NUnit.Framework;

namespace CsharpStudy.SubwayExam.Tests.DataSources;

[TestFixture]
[TestOf(typeof(SeoulSubwayInfoDataSource))]
public class SeoulSubwayInfoDataSourceTest
{

    [Test]
    public async Task DataSources_Test()
    {
        ISubwayInfoDataSource dataSource = new SeoulSubwayInfoDataSource(new HttpClient());
        var result = await dataSource.GetSubwayInfoAsync("서울");
        
        Assert.That(result is Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto?>>.Success, Is.True);
        
        var success = result as Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto?>>.Success;
        SubwayInfoDto dto = success!.data.Body;
        Assert.That(dto.realtimeArrivalList[0].statnNm == "서울", Is.True); 
        
    }
}