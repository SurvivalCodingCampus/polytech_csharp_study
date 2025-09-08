using System.IO;
using CsharpStudy.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(dataProgram))]
public class DataProgramTest
{

    [Test]
    public void METHOD()
    {
        dataProgram.Emplovee emplovee = new dataProgram.Emplovee("홍길동", 49);
        dataProgram.Department department = new dataProgram.Department("홍길동", emplovee);
        
        string jsonString = JsonConvert.SerializeObject(department);

        File.WriteAllText("jsonString.json",jsonString);
    }
}