using System.IO;
using System.Net;
using CsharpStudy.Data;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsharpStudy._2hakgi.Tests;

[TestFixture]
[TestSubject(typeof(Employee))]
public class EmployeeTest
{
    private const string textemployee = "employee.json";

    [Test]
    public void JsonSerialization()
    {
        
    }
}
