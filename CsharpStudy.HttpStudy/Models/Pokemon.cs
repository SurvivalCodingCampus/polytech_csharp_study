using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CsharpStudy.HttpStudy.Data;

public class Pokemon
{
    public string? Name { get; set; }
    public string ImageUrl { get; set; }

    public Pokemon(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    private bool Equals(Pokemon other)
    {
        return Name == other.Name && ImageUrl == other.ImageUrl;
    }
    public override bool Equals(object? obj)
    {
        if (obj is null) return false; // null이면 0
        if (ReferenceEquals(this, obj)) return true; // 참조 비교
        if (obj.GetType() != GetType()) return false; // 타입 비교
        return Equals((Pokemon)obj); // 셋다 아니면 위에다가 넣어서 값 나오게
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, ImageUrl); //두개 합치기
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(ImageUrl)}: {ImageUrl}"; // 두개 합쳐서 스트링으로 이거 그대로 직렬화가능
    }
}