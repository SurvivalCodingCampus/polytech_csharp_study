using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;
using NUnit.Framework;

namespace CsharpStudy.Http.Tests.DataSources;

[TestFixture]
[TestOf(typeof(RemotePostDataSource))]
public class RemotePostDataSourceTest
{
    [Test]
    public async Task Post_GET_Test()
    {
        IDataSource<Post> dataSource = new RemotePostDataSource(new HttpClient());
        var response = await dataSource.GetAllAsync();
        
        Assert.That(response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Body.Count, Is.EqualTo(100));
    }
}