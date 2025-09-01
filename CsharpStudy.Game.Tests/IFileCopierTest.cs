using System.IO;
using CshapStudy.File;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(IFileCopier))]
public class IFileCopierTest
{

    [Test]
    public void 기본파일_복사()
    {
        string text = "Hello World";
        File.WriteAllText(@"C:\Users\goono\test.txt", text);
        File.WriteAllText(@"C:\Users\goono\test2.txt",null);
        string sourceFilePath = @"C:\Users\goono\test.txt"; 
        string destinationFilePath = @"C:\Users\goono\test2.txt";
        
        DefaultFileOperations defaultFileOperations = new DefaultFileOperations();
        defaultFileOperations.CopyFile(sourceFilePath, destinationFilePath);
        
        string result = File.ReadAllText(destinationFilePath);
        Assert.That(result, Is.EqualTo(text));
    }
    [Test]
    public void 여러줄_파일_복사()
    {
        string text = "Hello World\n 이것은 테스트 파일입니다.\n 옳은 출력을 확인합니다.\n20250901";
        File.WriteAllText(@"C:\Users\goono\test.txt", text);
        File.WriteAllText(@"C:\Users\goono\test2.txt",null);
        string sourceFilePath = @"C:\Users\goono\test.txt"; 
        string destinationFilePath = @"C:\Users\goono\test2.txt";
        
        DefaultFileOperations defaultFileOperations = new DefaultFileOperations();
        defaultFileOperations.CopyFile(sourceFilePath, destinationFilePath);
        
        string result = File.ReadAllText(destinationFilePath);
        Assert.That(result, Is.EqualTo(text));
    }
    
    [Test]
    public void Exception_FilePath_is_Wrong()
    {
        string destinationFilePath = @"C:\Users\goono\test2.txt";
        
        DefaultFileOperations defaultFileOperations = new DefaultFileOperations();
        defaultFileOperations.CopyFile("?", destinationFilePath);
    }
}