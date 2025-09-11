using System.Globalization;
using DataSourceC.DataSources;

namespace DataSourceC;

class Program
{
    static async Task Main(string[] args)
    {
        IdataSource dataSource = new JsonFileDataSource("people.json");

        List<Person> people = await dataSource.GetPeopleAsync;
        List<Person> adults = people.Where(p => p.Age >= 19).ToList();
        adults.ForEach(p => Console.WriteLine($"{p.Name} {p.Age}"));
    }
}