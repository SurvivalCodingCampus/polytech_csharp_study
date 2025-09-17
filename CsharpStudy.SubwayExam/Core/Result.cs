namespace CsharpStudy.SubwayExam.Core;

public abstract record Result<TData, TError>
{
    public sealed record Success(TData data) : Result<TData, TError>;

    public sealed record Error(TError? errro) : Result<TData, TError>;
}

// 귀찮은 버전
// public abstract record Result<TData>
// {
//     public sealed record Success(TData data) : Result<TData>;
//
//     public sealed record Error(string message) : Result<TData>;
// }