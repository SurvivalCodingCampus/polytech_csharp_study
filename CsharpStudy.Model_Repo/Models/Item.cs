namespace Model_Repo.Models;

public class Item
{
    public int Count => _count;
    public int Id => _id;
    public string Name => _name;


    private readonly int _id;
    private readonly string _name;
    private int _count;

    public Item(int id, string name, int count)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

        this._id = id;
        this._name = name;
        this._count = count;
    }


    public void AddCount(Item added)
    {
        _count += added.Count;
    }

    private bool Equals(Item other)
    {
        return _id == other._id && _name == other._name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Item)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _name);
    }

    public override string ToString()
    {
        return $"{nameof(_id)}: {_id}, {nameof(_name)}: {_name}, {nameof(_count)}: {_count}";
    }
}