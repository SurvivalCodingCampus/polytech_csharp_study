namespace CsharpStudy.StationAPI.Data.Common;

public abstract record Result<TData, TError>
{
    private Result(){}

    public sealed record Success(TData data) : Result<TData, TError>;
    public sealed record Error(TData error) : Result<TData, TError>;
}