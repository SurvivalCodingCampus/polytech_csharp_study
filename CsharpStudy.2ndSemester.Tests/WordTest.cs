using NUnit.Framework;

namespace CsharpStudy._2ndSemester.Tests;

[TestFixture]
public class WordTest
{
    private Word word;

    [SetUp]
    public void Setup()
    {
        word = new Word();
        word.word = "Hello World!";
    }

    [Test]
    public void TestIsVowel_InHelloWorldExclamation()
    {
        // "Hello World!"
        // 인덱스:   0 1 2 3 4 5 6 7 8 9 10 11
        // 문자:     H e l l o   W o r l  d  !
        bool[] expected = {
            false, // H
            true,  // e
            false, // l
            false, // l
            true,  // o
            false, // ' '
            false, // W
            true,  // o
            false, // r
            false, // l
            false, // d
            false  // !
        };

        Assert.Multiple(() =>
        {
            for (int i = 0; i < word.word.Length; i++)
            {
                Assert.That(word.isVowel(i), Is.EqualTo(expected[i]),
                    $"Vowel check failed at index {i} ('{word.word[i]}')");
            }
        });
    }

    [Test]
    public void TestIsConsonant_InHelloWorldExclamation()
    {
        bool[] expected = {
            true,  // H
            false, // e
            true,  // l
            true,  // l
            false, // o
            false, // ' '
            true,  // W
            false, // o
            true,  // r
            true,  // l
            true,  // d
            false  // !
        };

        Assert.Multiple(() =>
        {
            for (int i = 0; i < word.word.Length; i++)
            {
                Assert.That(word.isConsonant(i), Is.EqualTo(expected[i]),
                    $"Consonant check failed at index {i} ('{word.word[i]}')");
            }
        });
    }
}