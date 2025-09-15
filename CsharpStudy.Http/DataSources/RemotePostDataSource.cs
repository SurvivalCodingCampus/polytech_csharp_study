using CsharpStudy.Http.Models;
using Newtonsoft.Json;

namespace CsharpStudy.Http.DataSources;

public class RemotePostDataSource : IDataSource<Post>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon/Snorlax";
    private HttpClient _httpClient;

    public RemotePostDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<List<Post>>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/posts");

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<List<Post>>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<List<Post>>(jsonString) ?? []
        );
    }

    public async Task<Response<Post>> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/posts/{id}");

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<Post>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Post>(jsonString)
        );
    }

    public async Task<Response<Post>> CreateAsync(Post item)
    {
        var jsonContent = new StringContent(
            JsonConvert.SerializeObject(item),
            System.Text.Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync($"{BaseUrl}/posts", jsonContent);

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<Post>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Post>(jsonString)
        );
    }

    public async Task<Response<Post>> UpdateAsync(Post item)
    {
        var jsonContent = new StringContent(
            JsonConvert.SerializeObject(item),
            System.Text.Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PutAsync($"{BaseUrl}/posts/{item.id}", jsonContent);

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<Post>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Post>(jsonString)
        );
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{BaseUrl}/posts/{id}");

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<bool>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: true
        );
    }
}