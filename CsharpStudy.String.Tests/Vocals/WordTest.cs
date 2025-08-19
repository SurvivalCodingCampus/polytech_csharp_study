using System;
using CsharpStudy.String.Vocals;
using NUnit.Framework;

namespace CsharpStudy.String.Tests.Vocals;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{

    [Test]
    public void IsVowel_Method_Test()
    {
        Word word = new Word("This is a word");
        int index = 3;          // 's', Consonant.

        Console.WriteLine(word.GetChar(index));
        Assert.That(word.IsVowel(index), Is.False);
    }
    
    [Test]
    public void IsConsonant_Method_Test()
    {
        Word word = new Word("This is a word");
        int index = 3;          // 's', Consonant.

        Console.WriteLine(word.GetChar(index));
        Assert.That(word.IsConsonant(index), Is.True);
    }

    [Test]
    public void Out_Of_Range_Test()
    {
        Word word = new Word("This is a word");
        Assert.Throws<ArgumentOutOfRangeException>(() => word.GetChar(99999));
    }

    [Test]
    public void Non_Letter_Test()
    {
        Word word = new Word("This is a word");
        Assert.That(false, Is.EqualTo(word.IsConsonant(4))); // Whitespace; false
    }
}