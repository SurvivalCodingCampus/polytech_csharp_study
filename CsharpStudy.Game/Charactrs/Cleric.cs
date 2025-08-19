namespace CsharpStudy.Game.Charactrs;

public class Cleric : IComparer<Cleric>
{
    //컴파일타임 상수
    public const int MaxHp = 50;
    public const int MaxMp = 10;
    
    public string Name { get; }
    
    private int _hp;

    public int HP
    {
        get { return _hp; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("HP는 0보다 작을 수 없습니다.");
            }
            _hp = value;
        }
    }
    public int Mp { get; set; }

    public Cleric(string name, int hp = MaxHp, int mp = MaxMp)
    {
        Name = name;
        HP = hp;
        Mp = mp;
    }

    protected bool Equals(Cleric other)
    {
        return Name == other.Name;
    }

    public int Compare(Cleric? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException("null과 비교할 수 없다");
        }
        
        return Name.CompareTo(other.Name);
    }

    public int Compare(Cleric? x, Cleric? y)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Cleric)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public static void SetRandomMoney()
    {
        
    }

    public override string ToString()
    {
        return $"{nameof(_hp)}: {_hp}, {nameof(Name)}: {Name}, {nameof(HP)}: {HP}, {nameof(Mp)}: {Mp}";
    }


    //런타임 상수
    //public static int MaxMp = 10;
}