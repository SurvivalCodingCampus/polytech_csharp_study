namespace CsharpStudy.DataSource;

class Program
{
    static async Task Main(string[] args)
    {
        IDataSource dataSource = new JsonFileDataSource("people.json");
        
        //1. 데이터를 불러와 필터링하는 로직
        var people = await dataSource.GetPeopleAsync();
        var adult = people.Where(p => p.Age >= 19).ToList();
        Console.WriteLine("성인만 출력");
        adult.ForEach(p => Console.WriteLine($" - {p.Name} ({p.Age}) - {p.Age}세)"));
        
        //2. 데이터를 추가하고 저장하는 로직
        people.Add(new Person("김민지", 15));
        await dataSource.SavePeopleAsync(people);
        Console.WriteLine("\n김민지 추가 후 저장 완료");
        
        //3. 데이터를 삭제하는 로직
        var toDelete = people.FirstOrDefault(p => p.Name == "이민준");
        if (toDelete != null)
        {
            people.Remove(toDelete);
            await dataSource.SavePeopleAsync(people);
            Console.WriteLine("\n이민준 삭제 후 저장완료");
        }
    }

    static async Task InitializeData()
    {
        IDataSource dataSource = new JsonFileDataSource("people.json");

        List<Person> people = new List<Person>();
        
        people.Add(new Person("이민준", 15));
        people.Add(new Person("장현수", 14));
        people.Add(new Person("임승빈", 43));

       await dataSource.SavePeopleAsync(people);
    }
    
}