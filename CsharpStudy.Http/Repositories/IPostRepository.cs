using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public interface IPostRepository
{
    Task<List<Post>> GetPostsAsync();
    Task<Post?> GetPostByIdAsync(int postId);
    Task<bool> CreatePostAsync(Post post);
    Task<bool> UpdatePostAsync(Post post);
    Task<bool> DeletePostAsync(int postId);
}