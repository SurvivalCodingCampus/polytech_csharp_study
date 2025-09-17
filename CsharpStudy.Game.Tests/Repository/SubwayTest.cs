using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Subway.Data;
using Subway.Models;
using Subway.Repository;

namespace CsharpStudy.Game.Tests.Repository;

[TestFixture]
[TestOf(typeof(PostRepository))]
public class SubwayTest
{

    [Test]
    public async Task METHOD()
    {
        HttpClient httpClient = new HttpClient();
        ISubwayApiDataSource dataSource = new RemotePostDataSource(httpClient);
        ISubwayRepository postRepository = new PostRepository(dataSource);

        BarvlDt barvlDt = await postRepository.GetSubwayByNameAsync("서울");
        
        Console.Write(barvlDt);
        
        Assert.That(barvlDt.barvlDtName == "서울", Is.True);
    }
}