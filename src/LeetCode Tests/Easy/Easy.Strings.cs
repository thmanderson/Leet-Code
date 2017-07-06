using System;
using System.Collections.Generic;
using Xunit;
using LeetCode;
using static LeetCode.Easy;

namespace LeetCodeTests.Easy
{
    public class Strings
    {
        public class ReverseString
        {
            [Theory]
            [InlineData("string", "gnirts")]
            [InlineData("StRiNg", "gNiRtS")]
            [InlineData("STRING", "GNIRTS")]
            [InlineData("", "")]
            [InlineData("Hello", "olleH")]
            [InlineData("111", "111")]
            public void ValidInputs(string input, string expectedResult)
            {
                string actualResult = ReverseString(input);
                Assert.Equal(expectedResult, actualResult);
            }
        }
        public class FizzBuzz
        {
            [Theory]
            [InlineData(1,"1")]
            [InlineData(3, "Fizz")]
            [InlineData(5, "Buzz")]
            [InlineData(15, "FizzBuzz")]
            public void FizzBuzz_Individual(int i, string expectedResult)
            {
                string actualResult = SingleFizzBuzz(i);
                Assert.Equal(expectedResult, actualResult);
            }

            [Theory]
            [MemberData(nameof(FizzBuzzData))]
            public void FizzBuzz_Group(int i, List<string> expectedResult)
            {

            }
            private static readonly List<object[]> _fizzBuzzData
                = new List<object[]>
                {
                    new object[] { 5, new List<string> {"1","2","Fizz","4","Buzz"} }
                };
            public static IEnumerable<object[]> FizzBuzzData
            {
                get { return _fizzBuzzData; }
            }
        }
        public class WordFromCharSet
        {
            [Theory]
            [MemberData(nameof(WordCharData))]
            public void ValidInputs(string input, HashSet<char> charSet, bool expectedResult)
            {
                bool actualResult = CanMakeWordFromChars(input, charSet);
                Assert.Equal(actualResult, expectedResult);
            }

            private static readonly List<object[]> _wordCharData
                = new List<object[]>
                {
                    new object[] { "alaska", new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' }, true },
                    new object[] { "Alaska", new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' }, false },
                    new object[] { "aaaaaaaaa", new HashSet<char> { 'a' }, true },
                    new object[] { "aaaaaaaaa", new HashSet<char> { 'b' }, false },
                    new object[] { "", new HashSet<char> { 'a' }, true }
                };
            public static IEnumerable<object[]> WordCharData
            {
                get { return _wordCharData; }
            }

        }
        public class DetectCapitals
        {
            [Theory]
            [InlineData("USA", true)]
            [InlineData("Microsoft", true)]
            [InlineData("test", true)]
            [InlineData("USa", false)]
            [InlineData("MiCrosofT", false)]
            [InlineData("tESt", false)]
            public void TestWords(string word, bool expectedResult)
            {
                bool actualResult = DetectCapitalUse(word);
                Assert.Equal(expectedResult, actualResult);
            }
        }
        public class UncommonSubSequence
        {
            [Theory]
            [InlineData("aaa","bbb",3)]
            [InlineData("aaa", "aaa", -1)]
            [InlineData("aa", "baab", 4)]
            [InlineData("baab", "aa", 4)]
            [InlineData("aa", "baaccccccaab", 12)]
            public void ValidInputs(string x, string y, int expectedResult)
            {
                int actualResult = LongestUncommonSequence(x, y);
                Assert.Equal(expectedResult, actualResult);
            }
        }
        public class ReverseWordsInString
        {
            [Theory]
            [InlineData("Hello, World", ",olleH dlroW")]
            [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
            public void ValidInputs(string input, string expectedResult)
            {
                string actualResult = ReverseWordsInString(input);
                Assert.Equal(expectedResult, actualResult);
            }
        }
    }
}
