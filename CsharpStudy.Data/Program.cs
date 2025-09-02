using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using CsharpStudy.Data;

// 리더/부서 인스턴스 생성
var leader = new Employee("홍길동", 41);
var dept = new Department("총무부", leader);

// JSON 문자열로 직렬화
string json = JsonSerializer.Serialize(dept);

// 파일로 저장
File.WriteAllText("company.json", json);
Console.WriteLine("저장 완료: company.json");