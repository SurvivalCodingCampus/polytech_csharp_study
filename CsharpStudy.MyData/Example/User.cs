namespace CsharpStudy.MyData.Example;

public class User
{
    public string Name { get; }
    public string Email { get; }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public override string ToString()
    {
        return "Name: " + Name + ", Email: " + Email;
    }
}