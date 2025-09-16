namespace _250915.Data.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Pokemon(int id, string name)
    {
        Id = id;
        Name = name;
    }

    protected bool Equals(Pokemon other)// Id와 Name이 같은지를 최종적으로 비교
    {
        return Id == other.Id && Name == other.Name;
    }

    public override bool Equals(object? obj) //객체 2개가 같은 객체인지 판단
    {
        if(obj is null) return false;
        if(ReferenceEquals(this, obj)) return true;
        if(obj.GetType() != GetType()) return false;
        return Equals((Pokemon)obj); // 위에 모든 조건을 합격하면 bool Equals 함수 호출
    }

    public override int GetHashCode() //동일한 속성을 가진 두 객체는 반드시 같은 해시 코드 반환
    {
        return HashCode.Combine(Id, Name);
    }

    public override string ToString()//객체의 정보를 사람이 읽기 쉬운 문자열 형태로 변환
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
    }
}