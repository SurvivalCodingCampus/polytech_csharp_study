using CsharpStudy.DataSource.Json.Problem.Models;

namespace CsharpStudy.DataSource.Json.Problem.Interfaces;

// 인터페이스(Interface)는 메서드를 갖도록 강제 
// '데이터를 가져오거나 저장하는 기능'의 인터페이스 
public interface IDateSource // 데이터 소스 계약 정의 
{
    Task<List<Person>> GetPeopleAsync(); // 메서드 
    Task SavePeopleAsync(List<Person> people); // 메서드 
}