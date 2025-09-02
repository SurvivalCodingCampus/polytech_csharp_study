namespace CsharpStudy.Data;

public class Department
{
    public string Name { get; set; }
    public Employee leader { get; set; }

    public Department() { }

    public Department(string name, Employee leader)
    {
        Name = name;
        this.leader = leader;
    }
}