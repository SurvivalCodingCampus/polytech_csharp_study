namespace Csharp.Study.DataSource;

public interface IDataSource //'사람데이터 다루는 저장소라면 최소한 이 두 기능을 제공해라' 약속
{
    Task<List<Person>> GetPeopleAsync(); //읽기

    Task SavePeopleAsync(List<Person> people); //쓰기
}