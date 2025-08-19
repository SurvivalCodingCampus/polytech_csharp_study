using CsharpStudy;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{
    [Test]
    public void 모음확인()
    {
        Word word = new Word("abc");

        Assert.That(word.isVowel(0),Is.True);
        Assert.That(word.isVowel(1),Is.False);
        Assert.That(word.isVowel(2),Is.False);
    }
    [Test]
    public void 자음확인()
    {
        Word word = new Word("abc");

        Assert.That(word.isConsonant(0),Is.False);
        Assert.That(word.isConsonant(1),Is.True);
        Assert.That(word.isConsonant(2),Is.True);
    }
}