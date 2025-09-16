namespace CsharpStudy.Subway.Common;

public abstract record Result<TData, TError>
{
    public sealed record Success(TData Data) : Result<TData, TError>;

    public sealed record Error(TError error) : Result<TData, TError>;

}