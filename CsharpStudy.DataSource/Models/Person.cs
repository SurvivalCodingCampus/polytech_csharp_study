namespace CsharpStudy.DataSource.Models;

public class Person
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }
    
    // Constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"- 이름 : {this.Name}, 나이 : {this.Age} 세";
    }
}