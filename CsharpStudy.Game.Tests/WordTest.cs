using System;
using CaharpStudy._2hakgi;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{

    [Test]
    public void i번째_글자가_모음인지_알려주는_함수()
    {
        Word word = new Word("bad");
        Console.WriteLine(word.IsVowel(1));
        Console.WriteLine(word.IsVowel(2));
        Console.WriteLine(word.IsConsonant(0));
        Console.WriteLine(word.IsConsonant(1));
    }
}