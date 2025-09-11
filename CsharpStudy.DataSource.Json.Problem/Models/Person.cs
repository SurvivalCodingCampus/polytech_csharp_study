namespace CsharpStudy.DataSource.Json.Problem.Models;

public class Person // 데이터 담는 클래스  > 데이터 모델 
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
}