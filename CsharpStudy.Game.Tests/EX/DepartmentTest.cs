using System;
using CaharpStudy._2hakgi.EX;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.EX;

[TestFixture]
[TestOf(typeof(Department))]
public class DepartmentTest
{

    [Test]
    public void METHOD()
    {
        Department department = new Department("총무부", new Emplovee("홍길동", 41));
        string expectedJson = "{\"Name\":\"총무부\",\"leader\":{\"Name\":\"홍길동\",\"Age\":41}}";
        
        string jsonString = JsonConvert.SerializeObject(department);
        
        Assert.That(jsonString, Is.EqualTo(expectedJson));

    }
}