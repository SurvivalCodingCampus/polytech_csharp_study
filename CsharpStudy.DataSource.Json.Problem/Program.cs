using CsharpStudy.DataSource.Json.Problem.DataSources;
using CsharpStudy.DataSource.Json.Problem.Interfaces;
using CsharpStudy.DataSource.Json.Problem.Models;

namespace CsharpStudy.DataSource.Json.Problem;

internal static class Program // 애플리케이션 진입점  
{
    static async Task Main(string[] args) // args '.exe' 확장자 > 실행파일 > 터미널에서 파일이름치면 인자로 받아서 실행됨  > 쓸일 없음 
    {
        IDateSource dateSource = new JsonFileDataSources("people.json"); // 인터페이스를 JsonFileDataSource 클래스에서 구현

        // 1. 데이터를 불러와 필터링하는 로직 > dateSource로부터 사람들의 목록 데이터를 가져오는 작업이 끝날 때까지 기다렸다가(await)
        var people = await dateSource.GetPeopleAsync();
        var adults = people.Where(p => p.Age >= 19).ToList();
        // Where : 조건식을 통한 필터링된 상태 만들기 
        // ToList : 필터릴ㅇ된 결과를 통해 새로운 List<Person> 객체 최종적으로 만들어냄 
        adults.ForEach(p => Console.WriteLine($"-{p.Name} ({p.Age}세)"));

        // 2. 데이터를 추가하고 저장하는 로직 
        people.Add(new Person("김민지", 15));
        await dateSource.SavePeopleAsync(people);
        Console.WriteLine("\n김민지님 추가 후 저장 완료.");

        // 3. 데이터를 삭제하는 로직 
        var toDelete = people.FirstOrDefault(p => p.Name == "이민준");
        if (toDelete != null)
        {
            people.Remove(toDelete);
            await dateSource.SavePeopleAsync(people);
            Console.WriteLine("\n이민준 삭제 후 저장 완료");
        }
    }
}