using System;
using System.Net;
using CsharpStudy.Exception_File;
using NUnit.Framework;
using System.IO;

namespace CsharpStudy.Exception_File.Tests;

[TestFixture]
[TestOf(typeof(DefaultFileOperations))]
public class DefaultFileOperationsTest
{

    [Test]
    public void FileCopy()
    {
        string helloText = "Hello World!";
        File.WriteAllText("hello.txt", helloText);
        
        DefaultFileOperations fileCopy = new DefaultFileOperations();
        fileCopy.CopyFile("hello.txt", "hello (2).txt");

        Console.WriteLine(File.ReadAllText("hello (2).txt"));
    }

    [Test]
    public void Exception()
    {
        DefaultFileOperations fileCopy = new DefaultFileOperations();
        fileCopy.CopyFile("exception.txt", "exception (2).txt");
    }

    [Test]
    public void SameFileName()
    {
        DefaultFileOperations fileCopy = new DefaultFileOperations();
        Assert.Throws<ArgumentException>(() =>
            fileCopy.CopyFile("exception.txt", "exception.txt"));
    }
}