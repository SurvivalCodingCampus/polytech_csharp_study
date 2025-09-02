using CsharpStudy.DataProblem;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsharpStudy.DataProblem.Tests;

[TestFixture]
[TestOf(typeof(Department))]
public class DepartmentTest
{
    [Test]
    public void Department_Serialization_Test()
    {
        // 1.준비 (Arrange) : 테스트에 필요한 객체 생성 
        var leader = new Employee("홍길동", 41);
        var department = new Department("총무부",leader);
        
        // 2. 실행 (Act) : 실행 결과가 예상과 같은지 확인
        // 결과 문자열이 "총무부" 텍스트를 포함하는가?
        string jsonResult = JsonConvert.SerializeObject(department);
        
        // 3. 검증 (Assert)
        Assert.That(jsonResult.Contains("총무부"), Is.True);
        Assert.That(jsonResult.Contains("홍길동"), Is.True);
        Assert.That(jsonResult.Contains("41"), Is.True);
    }
}