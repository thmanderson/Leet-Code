using System;
using System.Collections.Generic;
using Xunit;
using static LeetCode.String;

namespace LeetCode.Easy.Tests
{
    public class StringTests
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
                var actualResult = LeetCode.String.ReverseString(input);
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

        public class NumJewels
        {
            [Theory]
            [InlineData("aA", "aAAbbbb", 3)]
            [InlineData("z", "ZZ", 0)]
            public void CountNumJewels(string J, string S, int expectedResult)
            {
                var actualResult = String.NumJewelsInStones(J, S);
                Assert.Equal(expectedResult, actualResult);
            }
        }
        public class LongestNonRepeatingSubString
        {
            [Theory]
            [InlineData("aaa", 1)]
            [InlineData("aab", 2)]
            [InlineData("abc", 3)]
            [InlineData("dvdf", 3)]
            [InlineData("abcabcbb", 3)]
            [InlineData("asjrgapa", 6)]
            [InlineData("jbpnbwwd", 4)]
            public void ValidInputs(string x, int expectedResult)
            {
                int actualResult = LengthOfLongestSubstring(x);
                Assert.Equal(expectedResult, actualResult);
            }
        }

        public class LongestPalindromicSubstring
        {
            [Theory]
            [InlineData("aba", "aba")]
            [InlineData("abb", "bb")]
            [InlineData("babad", "bab")]
            [InlineData("aaaaaaabbbbbbb", "aaaaaaa")]
            [InlineData("aaaaaaabbbbbbbb", "bbbbbbbb")]
            public void ValidInputs(string s, string expectedResult)
            {
                string actualResult = LongestPalindrome(s);
                Assert.Equal(expectedResult, actualResult);
            }
        }

        public class ZigZagConversion
        {
            [Theory]
            [InlineData("PAYPALISHIRING", 1, "PAYPALISHIRING")]
            [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
            [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
            public void ValidInputs(string s, int rows, string expectedResult)
            {
                string actualResult = ZigZagConvert(s, rows);
                Assert.Equal(expectedResult, actualResult);
            }

        }
    }
}
