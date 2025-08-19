using System;
using CsharpStudy._2;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{
    [Test]
    public void ConstructorTest()
    {
        var exception = Assert.Throws<ArgumentException>(() => new Word("Hel45"));
    }
    
    [Test]
    public void IsVowelTest()
    {
        Word str1 = new Word("AeIoU");
        Word str2 = new Word("kmJQP");

        for (int i = 0; i < 5; i++)
        {
            Assert.That(str1.IsVowel(i), Is.True);
        }

        for (int i = 0; i < 5; i++)
        {
            Assert.That(str2.IsVowel(i), Is.False);
        }
    }

    [Test]
    public void IsConsonantTest()
    {
        Word str1 = new Word("AeIoU");
        Word str2 = new Word("kmJQP");

        for (int i = 0; i < 5; i++)
        {
            Assert.That(str1.IsConsonant(i), Is.False);
        }

        for (int i = 0; i < 5; i++)
        {
            Assert.That(str2.IsConsonant(i), Is.True);
        }
    }
}