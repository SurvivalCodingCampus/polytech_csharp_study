using CsharpStudy.DtoMapper; 
using CsharpStudy.HTTP.Models;

namespace CsharpStudy.HTTP.Mapping
{
    public static class PokemonMapper
    {
        private const string Placeholder = "https://placehold.co/128";

        public static Pokemon ToModel(this PokemonDto dto)
        {
            int id = 1;
            if (dto.Id.HasValue && dto.Id.Value > 0)
            {
                id = dto.Id.Value;
            }
            
            string name = string.IsNullOrWhiteSpace(dto.Name) ? "unknown" : dto.Name!;
            
            string spriteUrl = Placeholder;
            if (dto.Sprites != null && !string.IsNullOrWhiteSpace(dto.Sprites.FrontDefault))
            {
                spriteUrl = dto.Sprites.FrontDefault!;
            }

            return new Pokemon(id, name, spriteUrl);
        }
    }
}