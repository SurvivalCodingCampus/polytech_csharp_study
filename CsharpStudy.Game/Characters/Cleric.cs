namespace CsharpStudy.Game.Characters;

public class Cleric : IComparable<Cleric>
{
    // Compiling-time variables; No static member here.
    public const int MaxHp = 50;
    public const int MaxMp = 10;

    public string Name { get; } // Read-only.

    private int _hp;

    public int Hp // Property with redefined getter and setter
    {
        get { return _hp; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("HP는 0보다 작을 수 없습니다.");
            }
            _hp = value;
        }
    }

    public int Mp { get; set; } // Property

    public Cleric(string name, int hp = MaxHp, int mp = MaxMp) // Constructor
    {
        Name = name;
        Hp = hp;
        Mp = mp;
    }

    protected bool Equals(Cleric other)
    {
        return Name == other.Name;
    }

    public int CompareTo(Cleric? other) // the interface 'IComparable<T>' is needed.
    {
        if (other == null)
        {
            throw new ArgumentException("null과 비교할 수 없다");
        }
            
        return Name.CompareTo(other.Name);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;                  // Is null?
        if (ReferenceEquals(this, obj)) return true;    // Is this and obj pointing the same?
        if (obj.GetType() != GetType()) return false;   // Is obj's type NOT same with this'?
        return Equals((Cleric)obj);                     // Go to the protected one.
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();                      // this GetHashCode() is From 'Object' class.
    }

    public static void SetRandomMoney()
    {
        // Your codes here..
    }

    public override string ToString()
    {
        return $"{nameof(_hp)}: {_hp}, {nameof(Name)}: {Name}, {nameof(Hp)}: {Hp}, {nameof(Mp)}: {Mp}";
    }
}