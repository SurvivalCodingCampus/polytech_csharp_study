using System.IO;
using FileSystem;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(FileSystemFD))]
public class FileSystemFDTest
{

    [Test]
    public void METHOD()
    {
        FileSystemFD fileSystemFd = new FileSystemFD();

        string adress = "Test.txt";
        
        File.WriteAllText(adress, "이건 테스트 코드 입니다");
        string readAdress = File.ReadAllText(adress);
        
        fileSystemFd.Copy(adress, readAdress);
        
    }
    
    
    
}