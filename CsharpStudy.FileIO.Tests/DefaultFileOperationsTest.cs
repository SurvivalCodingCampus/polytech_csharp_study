using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace CsharpStudy.FileIO.Tests;

[TestFixture]
[TestOf(typeof(DefaultFileOperations))]
public class DefaultFileOperationsTest
{
    // string _sourceTextPath = @"C:\_Workplace\polytech_csharp_study\CsharpStudy.FileIO\SampleText.txt";
    // string _destinationTextPath = @"C:\_Workplace\polytech_csharp_study\CsharpStudy.FileIO\SampleText_copy.txt";

    private string _workDir;
    private string _sourceTextPath;
    private string _destinationTextPath;
    
    [SetUp]
    public void Setup()
    {
        // if (!File.Exists(_sourceTextPath))
        // {
        //     using (var stream = File.CreateText(_sourceTextPath))
        //     {
        //         stream.Write("You have selected Microsoft Sam as the computer's default voice.");
        //     }
        // }
        //
        // if (!File.Exists(_destinationTextPath))
        // {
        //     DefaultFileOperations defaultFileOperations = new DefaultFileOperations();
        //     defaultFileOperations.CopyFile(_sourceTextPath, _destinationTextPath);
        // }
        
        // set a working directory make txt files at the Current working directory\io-tests\NewGuid
        _workDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "io-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_workDir);
        
        // combine _workDir with a file directory
        _sourceTextPath = Path.Combine(_workDir, "SampleText.txt");
        _destinationTextPath = Path.Combine(_workDir, "SampleText_copy.txt");
        Console.WriteLine($"Check your file at {_sourceTextPath}"); // Nope; will be erased after the test ends.
        
        // make a sourceText
        File.WriteAllText(_sourceTextPath, "You have selected Microsoft Sam as the computer's default voice.");
        
        // copy it
        // DefaultFileOperations dfo = new DefaultFileOperations();
        // dfo.CopyFile(_sourceTextPath, _destinationTextPath);
    }

    [Test]
    public void CHECK_BOTH_FILES_HAVE_SAME_CONTENTS()
    {
        DefaultFileOperations dfo = new DefaultFileOperations();
        dfo.CopyFile(_sourceTextPath, _destinationTextPath);
        
        var strings = new List<string>();
        strings.Add(File.ReadAllText(_sourceTextPath));
        strings.Add(File.ReadAllText(_destinationTextPath));
        
        Assert.That(strings[0], Is.EqualTo(strings[1]));
    }

    [Test]
    public void CHECK_FILE_NOT_FOUND_EXCEPTIONS()
    {
        // _sourceTextPath = _sourceTextPath.Substring(_sourceTextPath.Length - 1, 1);
        // DefaultFileOperations defaultFileOperations = new DefaultFileOperations();
        
        // make a wrong directory and try to copy a text file.
        var invalidPath = Path.Combine(_workDir, "Invalid_Location.txt");
        var dfo = new DefaultFileOperations();

        Assert.Throws<FileNotFoundException>(() => dfo.CopyFile(invalidPath, _destinationTextPath));
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(_sourceTextPath)) File.Delete(_sourceTextPath);
        if (File.Exists(_destinationTextPath)) File.Delete(_destinationTextPath);
    }
}