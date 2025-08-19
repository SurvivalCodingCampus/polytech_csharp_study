using CsharpStudy._2;
using NUnit.Framework;

namespace CsharpStudy._2.Tests;

[TestFixture]
[TestOf(typeof(Word))]
public class WordTest
{

    [Test]
    public void IsVowel_자음찾기()
    {
        Word w = new Word("apple");
        Assert.That(w.IsVowel(0)); // 'a'
        Assert.That(w.IsVowel(4)); // 'e'
    }
}