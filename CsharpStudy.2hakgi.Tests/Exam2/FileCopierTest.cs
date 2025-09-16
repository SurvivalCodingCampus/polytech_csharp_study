using System;
using System.IO;
using CsharpStudy.File.Exam2;
using NUnit.Framework;

namespace CsharpStudy._2hakgi.Tests.Exam2;

[TestFixture]
[TestOf(typeof(FileCopier))]
public class FileCopierTest
{
    private const string _sourceFilePath = "test_source.txt";
    private const string _sourceText = "오준석의 생존코딩";

    private const string _targetFilePath = "test_target_source.txt";
    private IFileCopier _fileCopier = new FileCopier();

    [SetUp]
    public void Setup()
    {
        // 테스트용 파일 생성
        System.IO.File.WriteAllText(_sourceFilePath, _sourceText);
    }

    [TearDown]
    public void TearDown()
    {
        // 테스트용 파일 삭제
        System.IO.File.Delete(_sourceFilePath);
        System.IO.File.Delete(_targetFilePath);
    }

    [Test]
    [Description("성공적으로 복사 되어야 한다")]
    public void Copy_Success()
    {
        _fileCopier.CopyFile(_sourceFilePath, _targetFilePath);

        Assert.That(System.IO.File.Exists(_targetFilePath), Is.True);

        string text = System.IO.File.ReadAllText(_targetFilePath);
        Assert.That(text, Is.EqualTo(_sourceText));
    }

    [Test]
    [Description("원본 경로가 비어있으면 안 된다")]
    public void Source_Path_Not_Empty()
    {
        Assert.Throws<ArgumentException>(() => _fileCopier.CopyFile("", _targetFilePath));
    }

    [Test]
    [Description("대상 경로가 비어있으면 안 된다")]
    public void Target_Path_Not_Empty()
    {
        Assert.Throws<ArgumentException>(() => _fileCopier.CopyFile(_sourceFilePath, ""));
    }

    [Test]
    [Description("파일이 존재해야 한다")]
    public void File_Exists()
    {
        Assert.Throws<FileNotFoundException>(() => _fileCopier.CopyFile("aasdf.ttt", "asdfas.ttt"));
    }
}