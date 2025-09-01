using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace CsharpStudy.FileIO.Tests;

[TestFixture]
[TestOf(typeof(DefaultFileOperations))]
public class DefaultFileOperationsTest
{
    string _sourceTextPath = @"C:\_Workplace\polytech_csharp_study\CsharpStudy.FileIO\SampleText.txt";
    string _destinationTextPath = @"C:\_Workplace\polytech_csharp_study\CsharpStudy.FileIO\SampleText_copy.txt";
    
    [SetUp]
    public void Setup()
    {
        if (!File.Exists(_sourceTextPath))
        {
            using (var stream = File.CreateText(_sourceTextPath))
            {
                stream.Write("You have selected Microsoft Sam as the computer's default voice.");
            }
        }

        if (!File.Exists(_destinationTextPath))
        {
            DefaultFileOperations defaultFileOperations = new DefaultFileOperations();
            defaultFileOperations.CopyFile(_sourceTextPath, _destinationTextPath);
        }
    }

    [Test]
    public void CHECK_BOTH_FILES_HAVE_SAME_CONTENTS()
    {
        var strings = new List<string>();
        strings.Add(File.ReadAllText(_sourceTextPath));
        strings.Add(File.ReadAllText(_destinationTextPath));
        
        Assert.That(strings[0], Is.EqualTo(strings[1]));
    }

    [Test]
    public void CHECK_FILE_NOT_FOUND_EXCEPTIONS()
    {
        _sourceTextPath = _sourceTextPath.Substring(_sourceTextPath.Length - 1, 1);
        DefaultFileOperations defaultFileOperations = new DefaultFileOperations();

        Assert.Catch<FileNotFoundException>(() => defaultFileOperations.CopyFile(_sourceTextPath, _destinationTextPath));
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(_sourceTextPath)) File.Delete(_sourceTextPath);
        if (File.Exists(_destinationTextPath)) File.Delete(_destinationTextPath);
    }
}