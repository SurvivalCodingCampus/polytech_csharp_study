namespace CsharpStudy.Result.Models;

/// 애플리케이션 내부에서 사용할 포켓몬 '모델' 클래스입니다.
/// DTO와 달리, 앱에 정말 필요한 데이터(이름, 이미지 URL)만 가집니다.
/// 속성들이 non-nullable(string)이므로, 이 객체가 생성된 시점에는 유효한 데이터를 가지고 있음이 보장됩니다.
///

// 아래 것과 동일
public record Pokemon(string Name, string ImageUrl);

// public class Pokemon // 앱에서 사용하는 데이터 모델
// {
//     

// // 읽기 전용 속성(get;)으로, 생성 시에만 값이 할당되고 이후에는 변경할 수 없습니다. (불변성)
// public string Name { get; }
// public string ImageUrl { get; }
// //public object Sprites { get; set; }
//
// public Pokemon(string name, string imageUrl) // 생성자 
// {
//     Name = name;
//     ImageUrl = imageUrl;
// }
//
// // 아래 메서드들(Equals, GetHashCode, ToString)은 객체의 비교, 해시, 문자열 표현을 위해
// // 재정의된 것으로, 객체를 더 효과적으로 다루기 위한 좋은 습관입니다.
// protected bool Equals(Pokemon other)
// {
//     return Name == other.Name && ImageUrl == other.ImageUrl;
// }
//
// public override bool Equals(object? obj)
// {
//     if (obj is null) return false;
//     if (ReferenceEquals(this, obj)) return true;
//     if (obj.GetType() != GetType()) return false;
//     return Equals((Pokemon)obj);
// }
//
// public override int GetHashCode()
// {
//     return HashCode.Combine(Name, ImageUrl);
// }
//
// public override string ToString()
// {
//     return $"{nameof(Name)}: {Name}, {nameof(ImageUrl)}: {ImageUrl}";
// }
//}