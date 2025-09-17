using System.Runtime.InteropServices.ComTypes;

namespace CsharpStudy.DtoMapper.DataSources;

public abstract record class Result<TData, TError>
{
    public sealed record Success(TData data) : Result<TData, TError>;
    
    public sealed record Error(TError error) : Result<TData, TError>;
}

