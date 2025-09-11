using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace CsharpStudy._2hakgi.Assignment.DataSource;

public class JsonFileDataSource : IDataSource
{
    private string _filePath;

    public JsonFileDataSource(string fileName)
    {  
        // 실행 경로: bin/Debug/net8.0/
        string baseDir = AppContext.BaseDirectory;

        // 프로젝트 루트로 이동 (bin/Debug/net8.0에서 세 단계 위)
        string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"../../.."));

        // 최종 JSON 파일 경로
        _filePath = Path.Combine(projectRoot, "Assignment/DataSource" , fileName);
    }

    // DataSource에서 await를 사용하고 있으니까 async
    public async Task<List<Person>> GetPeopleAsync()
    {
        List<Person>? people = new List<Person>(); // null일지도 모름
        try
        {
            string text = await System.IO.File.ReadAllTextAsync(_filePath);
            people = JsonSerializer.Deserialize<List<Person>>(text);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("파일이 존재하지 않습니다.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("경로가 올바르지 않습니다.");
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return people;
    }

    public async Task SavePeopleAsync(List<Person> people)
    {
        if (people == null)
        {
            throw new ArgumentNullException(nameof(people));
        }
        
        // 인코딩
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) //
        };

        await System.IO.File.WriteAllTextAsync(
            _filePath,
            JsonSerializer.Serialize(people, options)
        );
    }
}