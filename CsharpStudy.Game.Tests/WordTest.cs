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

        Assert.That(word.IsVowel(0), Is.True);
        Assert.That(word.IsVowel(1), Is.False);
        Assert.That(word.IsVowel(2), Is.False);
    }

    [Test]
    public void 자음확인()
    {
        Word word = new Word("abc");

        Assert.That(word.IsConsonant(0), Is.False);
        Assert.That(word.IsConsonant(1), Is.True);
        Assert.That(word.IsConsonant(2), Is.True);
    }

    [Test]
    public void 범위초과_확인()
    {
        Word word = new Word("abc");

        Assert.That(word.IsConsonant(-1), Is.False);
        Assert.That(word.IsConsonant(5), Is.False);
        
        Assert.That(word.IsVowel(-1), Is.False);
        Assert.That(word.IsVowel(20), Is.False);
    }
}