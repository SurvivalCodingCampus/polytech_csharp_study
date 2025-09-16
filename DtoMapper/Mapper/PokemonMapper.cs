namespace DtoMapper.Mapper;

public static class PokemonMapper
{
    public static Models.Pokemon ToModel(this PokemonDto dto)
    {
        return new Models.Pokemon(
            name: dto.Name ?? "Unknown", 
            types: dto.Types?.Select(t => t.Type?.Name ?? "Unknown").ToList() ?? new List<string>()
        );
    }
}