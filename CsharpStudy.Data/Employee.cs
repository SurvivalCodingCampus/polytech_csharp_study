namespace CsharpStudy.Data;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Employee() {}

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}