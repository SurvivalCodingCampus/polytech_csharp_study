using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public interface IPostRepository
{
    Task<List<Post>> GetPostsAsync();
    Task<Post?> GetPostAsync(int id);
    Task<Post> CreatePostAsync(Post post);
    Task<Post> UpdatePostAsync(Post post);
    Task<Post> DeletePostAsync(int id);
}