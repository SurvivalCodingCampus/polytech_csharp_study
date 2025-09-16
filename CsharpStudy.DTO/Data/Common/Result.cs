namespace CsharpStudy.DTO.Data.Common;

public abstract record Result<TData, TError>
{
    private Result(){}

    public sealed record Success(TData _Data) : Result<TData, TError>;
    public sealed record Error(TError _Error) : Result<TData, TError>;
}