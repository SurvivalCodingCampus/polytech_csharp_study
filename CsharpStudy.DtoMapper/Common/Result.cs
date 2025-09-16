using CsharpStudy.DtoMapper.Repositories;

namespace CsharpStudy.DtoMapper.Common;

public abstract record Result<TData, TError>
{
    public sealed record Success(TData data) : Result<TData, TError>;
    public sealed record Error(PokemonError error) : Result<TData, TError>;
};