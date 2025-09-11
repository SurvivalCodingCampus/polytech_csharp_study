namespace CsharpStudy.DataSource.Models;

public class Person
{
    // private string _name
    // 프로퍼티
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}