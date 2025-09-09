namespace CsharpStudy.DataSource;

public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    protected bool Equals(Person other)
    {
        return Name == other.Name && Age == other.Age;
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
        return HashCode.Combine(Name, Age);
    }
}