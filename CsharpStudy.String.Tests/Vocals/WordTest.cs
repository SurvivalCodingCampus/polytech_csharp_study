using System;
using CsharpStudy.String.Vocals;
using NUnit.Framework;

namespace CsharpStudy.String.Tests.Vocals;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{

    [Test]
    public void IsVowel_And_IsConsonant_Method_Test()
    {
        Word word = new Word("This is a word");
        int index = 3;          // 's', Consonant.

        Console.WriteLine(word.GetChar(index));
        Assert.That(word.IsVowel(index), Is.False);
        Assert.That(word.IsConsonant(index), Is.True);
    }
}