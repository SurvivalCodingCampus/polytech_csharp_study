using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.DataSource;
using NUnit.Framework;


namespace CsharpStudy.Http.Tests.DataSource;

[TestFixture]
[TestOf(typeof(RemotePostDataSource))]
public class RemotePostDataSourceTest
{
    [Test]
    public async Task Post_GET_Test()
    {
        RemotePostDataSource dataSource = new RemotePostDataSource(new HttpClient());
        var response = await dataSource.GetAllAsync();

        Assert.That(response.StatusCode, Is.EqualTo(200));
        Assert.That(response.Body.Count, Is.EqualTo(100));
    }
}