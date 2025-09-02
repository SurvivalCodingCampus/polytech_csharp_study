using System;
using System.IO;
using NUnit.Framework;

namespace CsharpStudy.Data.Test;

public class SerializeTestClass
{

    private readonly string _testDirectory;
    
    public SerializeTestClass()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), $"FileCopierTests_{Guid.NewGuid()}");
        Directory.CreateDirectory(_testDirectory);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
    }
    
    [Test]
    [Description("직렬화 -> 역직렬화 시 두 객체는 동일하다")]
    public void Test_1()
    {
        var initDepartment = Program.InitDepartment();
        string sourcePath = Path.Combine(_testDirectory, "data.json");
        Program.Serialrize(initDepartment,sourcePath);
        var desiDepartment = Program.DeserialrizeOrNull<Department>(sourcePath);
        Console.WriteLine(desiDepartment);
        Assert.AreEqual(initDepartment, desiDepartment);
    }
    
    
    
}