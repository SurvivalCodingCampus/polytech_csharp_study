namespace CsharpStudy.Network.Repositories;


public record Result<TData, TError>
{
    public Result()
    {
    }
    
    public sealed record Success(TData data) : Result<TData, TError>;
    public sealed record Error(TError data) : Result<TData, TError>;
};