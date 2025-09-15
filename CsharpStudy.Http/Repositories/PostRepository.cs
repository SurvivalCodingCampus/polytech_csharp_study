using System.Text.Json.Serialization;
using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;
using Newtonsoft.Json;

namespace CsharpStudy.Http.Repositories;

public class PostRepository :  IPostRepository
{
    private IDataSource<Post> _dataSource;

    public PostRepository(IDataSource<Post> dataSource)
    {
        _dataSource = dataSource;
    }


    public async Task<List<Post>> GetPostsAsync()
    {
        var response = await _dataSource.GetAllAsync();
        return response.Body;
    }

    public async Task<Post?> GetPostAsync(int postId)
    {
        var response = await _dataSource.GetByIdAsync(postId);
        return response.Body;
    }

    public async Task<bool> CreatePostAsync(Post post)
    {
        try
        {
            await _dataSource.CreatePostAsync(post);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdatePostAsync(Post post)
    {
        try
        {
            await _dataSource.UpdatePostAsync(post);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        try
        {
            await _dataSource.DeletePostAsync(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}