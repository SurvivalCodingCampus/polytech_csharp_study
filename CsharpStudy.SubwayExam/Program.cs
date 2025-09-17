using CsharpStudy.SubwayExam.DataSources;
using CsharpStudy.SubwayExam.Models;
using CsharpStudy.SubwayExam.Repository;
using CsharpStudy.SubwayExam.Core;

namespace CsharpStudy.SubwayExam;

class Program
{
    static async Task Main(string[] args)
    {
        ISubwayInfoDataSource dataSource = new SeoulSubwayInfoDataSource(new HttpClient());
        ISubwayRepository repository = new SeoulSubwayRepository(dataSource);

        var result = await repository.GetArrivalInfoAsync("서울");
        switch (result)
        {
            case Result<List<SubwayArrivalInfo>, SubwayError>.Success successResult:
                successResult.data.ForEach(Console.WriteLine);
                break;
            case Result<List<SubwayArrivalInfo>, SubwayError>.Error errorResult:
                Console.WriteLine(errorResult.errro);
                break;
        }
    }
}