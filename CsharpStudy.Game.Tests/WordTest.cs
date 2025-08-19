using System;
using CsharpStudy._2Semester;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{
    [Test]
    public void IsVowelAtIndex_ShouldReturnTrue()
    {
        Word word = new Word("StringTestCode");
        bool result = word.IsVowel(7);
        Assert.That(result, Is.True);
        
    }
    [Test]
    public void IsConsonantAtIndex_ShouldReturnTrue()
    {
        Word word = new Word("StringTestCode");
        bool result = word.IsConsonant(4);
        Assert.That(result, Is.True);
    }
}