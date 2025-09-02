namespace CsharpStudy.Data;


public class Employee
{
    public string Name { get; }
    public int Age { get; }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
    }

    protected bool Equals(Employee other)
    {
        return Name == other.Name && Age == other.Age;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Employee)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }
}

public class Department
{
    public string Name { get; }
    public Employee leader { get; }

    public Department(string name, Employee leader)
    {
        Name = name;
        this.leader = leader;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(leader)}: {leader}";
    }

    protected bool Equals(Department other)
    {
        return Name == other.Name && leader.Equals(other.leader);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Department)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, leader);
    }
    
}

