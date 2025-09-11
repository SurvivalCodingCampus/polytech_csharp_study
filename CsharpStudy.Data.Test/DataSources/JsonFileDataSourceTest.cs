using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using CsharpStudy.DataSource;
using NUnit.Framework;

namespace CsharpStudy.Data.Test.DataSources;

[TestFixture]
[TestOf(typeof(JsonFileDataSource))]
public class JsonFileDataSourceTest
{


    // 객체 생성 테스트
    [Test]
    [DisplayName("객체 생성시 이름이 없는경우 예외가 발생한다.")]
    public void METHOD_1()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var jsonFileDataSource = new JsonFileDataSource("");
        });
    }
    [Test]
    [DisplayName("객체 생성시 파일이 없는경우 파일이 생성된다.")]
    public void METHOD_2()
    {
        var bemakeFile = "beMake.file";
        JsonFileDataSource jsonFileDataSource = new JsonFileDataSource(bemakeFile);
        Assert.True(File.Exists(bemakeFile));
    }
    
    // 파일로 저장 및 불러오기 테스트
    [Test]
    [DisplayName("데이터를 파일로 저장한 파일을 다시 가져올 경우 데이터가 동일하다.")]
    public async Task METHOD_3()
    {
        List<Person> people = new();
        
        people.Add(new Person("낑깡", 10));
        
        JsonFileDataSource jsonFileDataSource = new JsonFileDataSource("test.json");

        await jsonFileDataSource.SavePeopleAsync(people);
        var getPeople = await jsonFileDataSource.GetPeopleAsync();
        
        Assert.AreEqual(getPeople, people);
    }

    
}