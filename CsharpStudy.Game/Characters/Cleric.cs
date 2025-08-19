namespace CsharpStudy.Game.Characters;

public class Cleric : IComparable<Cleric>
{
    // const : 컴파일타임 상수
    // static : 런타임 상수
    public const int MaxHp = 50;
    public const int MaxMp = 10;
    
    public string Name{ get; }
    
    private int _hp;
    
    // getter/setter를 직접 재정의하는 것은 지양
    // getter나 setter 재정의 시 둘 다 재정의를 해야 함. 하나만 재정의 불가
    public int Hp
    {
        get { return _hp; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hp cannot be less than 0");
            }
            _hp = value;
        }
    }
    public int Mp{ get; set; }

    
    // Generate Code -> Equality Members : 동등성 체크 및 해시코드 설정
    protected bool Equals(Cleric other)
    {
        return Name == other.Name;
    }

    // ? : null을 허용하는 문법
    // other에 null이 들어올 수 있으므로, if문을 사용하여 other이 null일 시 오류를 발생시키도록 함
    public int CompareTo(Cleric? other)
    {
        if (other == null)
        {
            throw new ArgumentException("null과 비교할 수 없다.");
        }
        
        return Name.CompareTo(other.Name);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Cleric)obj);
    }
    //

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public Cleric(string name, int hp = MaxHp, int mp = MaxMp)
    {
        Name = name;
        Hp = hp;
        _hp = hp;
        Mp = mp;
    }

    public static void SetRandomMoney()
    {
        Console.WriteLine("SetRandomMoney");
    }

    // Generate Code -> Formatting Members
    public override string ToString()
    {
        return $"{nameof(_hp)}: {_hp}, {nameof(Name)}: {Name}, {nameof(Hp)}: {Hp}, {nameof(Mp)}: {Mp}";
    }
}