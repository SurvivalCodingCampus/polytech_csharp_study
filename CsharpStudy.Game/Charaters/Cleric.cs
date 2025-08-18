namespace CsharpStudy.Game.Charaters;

public class Cleric
{
    public const int MaxHp = 50;
    public const int MaxMp = 10;

    public string Name { get; }
    private int _hp;

    public int Hp
    {
        get { return _hp;}
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("HP는 0보다 작을 수 없습니다.");
            }

            _hp = value;
        }
    }
    public int Mp { get; set; }

    public Cleric(string name, int hp = MaxHp, int mp = MaxMp)
    {
        Name = name;
        Hp = hp;
        Mp = mp;
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

    public static void SetRandomMoney()
    {
        
    }

    public override string ToString()
    {
        return $"{nameof(_hp)}: {_hp}, {nameof(Name)}: {Name}, {nameof(Hp)}: {Hp}, {nameof(Mp)}: {Mp}";
    }
}