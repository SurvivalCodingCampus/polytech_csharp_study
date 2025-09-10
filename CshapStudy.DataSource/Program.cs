using System.Globalization;

namespace CshapStudy.DataSource;

class Program
{
    static async Task Main(string[] args)
    {


        IDataSource dataSource = new JsonFileDataSource("people.json");


        var peopele = await dataSource.GetPeolpeAsync();
        var adults = peopele.Where(p => p.Age >= 19).ToList();
        Console.WriteLine("성인만 출력");
        adults.ForEach(p => Console.WriteLine($"-{p.Name}({p.Age}세)"));

        peopele.Add(new Person { Name = "김민지", Age = 15 });
        await dataSource.SavePeopleAsync(peopele);
        Console.WriteLine("\n김민지 추가 후 저장 완료");

        var toDelete = peopele.FirstOrDefault(p => p.Name == "이민준");
        if (toDelete != null)
        {
            peopele.Remove(toDelete);
            await dataSource.SavePeopleAsync(peopele);
            Console.WriteLine("\n이민준 삭제 후 저장 완료");
            
        }
    }
}