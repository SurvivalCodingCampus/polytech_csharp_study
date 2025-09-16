namespace CsharpStudy.HTTP.Models
{
    public sealed record Pokemon(
        int Id,           // 식별자
        string Name,   
        string SpriteUrl  // 대표 이미지 URL
    )
    {
        public override string ToString() => $"{Name} (#{Id})";
    }
}