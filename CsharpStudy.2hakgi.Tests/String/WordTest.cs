using CsharpStudy._2hakgi.String;
using JetBrains.Annotations;
using NUnit.Framework;

namespace CsharpStudy._2hakgi.Tests.String;

[TestFixture]
[TestSubject(typeof(Word))]
public class WordTest
{

    [Test]
    public void IsVowel_Test()
    {
        Word word = new Word("aeiouAEIOU");
     
        // Assert.AreEqual(true, word.IsVowel(0));
    }
}