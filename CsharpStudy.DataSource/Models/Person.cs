namespace CsharpStudy.DataSource;

public class Person
{
    public string Name
    {
        get => _name; 
        set => _name = value;
    }

    public int Age
    {
        get => _age; 
        set => _age = value < 0 ? 0 : value;
    }
    
    private string _name;
    private int _age;

    public Person(string name, int age)
    {
        _name = name;
        _age = age;
    }

    protected bool Equals(Person other)
    {
        return _name == other._name && _age == other._age;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Person)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_name, _age);
    }
}