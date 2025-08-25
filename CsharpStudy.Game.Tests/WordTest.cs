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
        Word word = new Word("aeiouAEIOU");
        int length = word.Text.Length;
        for (int i = 0; i < length; i++)
        {
            bool result = word.IsVowel(i);
            Assert.That(result, Is.True);
        }
    }

    [Test]
    public void IsConsonantAtIndex_ShouldReturnTrue()
    {
        Word word = new Word("bcdfghjklmnpqrstvwxyz");
        int length = word.Text.Length;
        for (int i = 0; i < length; i++)
        {
            bool result = word.IsConsonant(i);
            Assert.That(result, Is.True);
        }
    }
}