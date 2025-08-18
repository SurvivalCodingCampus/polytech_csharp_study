namespace CsharpStudy.Game.Characters;
public class Cleric
{
    // 컴파일 상수
    public const int MaxHp = 50;
    public const int MaxMp = 10;

    private int _hp;
    public string Name { get; }
    //public int Hp { get; set; }
    public int Mp { get; set; }

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

    protected bool Equals(Cleric other)
    {
        return Name == other.Name;
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

    public override string ToString()
    {
        return $"{nameof(_hp)}: {_hp}, {nameof(Name)}: {Name}, {nameof(Mp)}: {Mp}, {nameof(Hp)}: {Hp}";
    }

    public Cleric(string name, int hp = MaxHp, int mp = MaxMp)
    {
        Name = name;
        Hp = hp;
        Mp = mp;
    }

    // 런타임 상수
    // public static int MaxMp = 10;

    public static void SetRandomMoney()
    {
        Random random = new Random();
    }
}