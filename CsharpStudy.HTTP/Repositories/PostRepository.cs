using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public class PostRepository : IPostRepository
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

    public async Task<Post?> GetPostByIdAsync(int postId)
    {
        var response = await _dataSource.GetByIdAsync(postId);
        return response.Body;
    }

    public async Task<bool> CreatePostAsync(Post post)
    {
        try
        {
            await _dataSource.CreateAsync(post);
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
            await _dataSource.UpdateAsync(post);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeletePostAsync(int postId)
    {
        try
        {
            await _dataSource.DeleteAsync(postId);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}