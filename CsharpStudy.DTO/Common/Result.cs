namespace CsharpStudy.DTO.Common;

public abstract record Result<TData, TError>
{
    public sealed record Success(TData data) : Result<TData, TError>;

    public sealed record Error(TError eror) : Result<TData, TError>;
}