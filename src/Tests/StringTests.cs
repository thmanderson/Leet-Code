using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static LeetCode.String;

namespace LeetCode.Tests
{
    public class StringTests
    {
        [Theory]
        [InlineData("string", "gnirts")]
        [InlineData("StRiNg", "gNiRtS")]
        [InlineData("STRING", "GNIRTS")]
        [InlineData("", "")]
        [InlineData("Hello", "olleH")]
        [InlineData("111", "111")]
        public void ReverseString_ValidInputs(string input, string expectedResult)
        {
            var actualResult = LeetCode.String.ReverseString(input);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(1,"1")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        public void FizzBuzz_ValidInputs(int i, string expectedResult)
        {
            string actualResult = SingleFizzBuzz(i);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(WordCharData))]
        public void WordFromChars_ValidInputs(string input, HashSet<char> charSet, bool expectedResult)
        {
            bool actualResult = CanMakeWordFromChars(input, charSet);
            Assert.Equal(actualResult, expectedResult);
        }

        public static readonly List<object[]> WordCharData
            = new List<object[]>
            {
                new object[] { "alaska", new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' }, true },
                new object[] { "Alaska", new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' }, false },
                new object[] { "aaaaaaaaa", new HashSet<char> { 'a' }, true },
                new object[] { "aaaaaaaaa", new HashSet<char> { 'b' }, false },
                new object[] { "", new HashSet<char> { 'a' }, true }
            };

        [Theory]
        [InlineData("USA", true)]
        [InlineData("Microsoft", true)]
        [InlineData("test", true)]
        [InlineData("USa", false)]
        [InlineData("MiCrosofT", false)]
        [InlineData("tESt", false)]
        public void TestWords_ValidInputs(string word, bool expectedResult)
        {
            bool actualResult = DetectCapitalUse(word);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("Hello, World", ",olleH dlroW")]
        [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
        public void ReverseWordsInString_ValidInputs(string input, string expectedResult)
        {
            string actualResult = ReverseWordsInString(input);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("aA", "aAAbbbb", 3)]
        [InlineData("z", "ZZ", 0)]
        public void CountJewels_ValidInputs(string J, string S, int expectedResult)
        {
            var actualResult = String.NumJewelsInStones(J, S);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("aaa", 1)]
        [InlineData("aab", 2)]
        [InlineData("abc", 3)]
        [InlineData("dvdf", 3)]
        [InlineData("abcabcbb", 3)]
        [InlineData("asjrgapa", 6)]
        [InlineData("jbpnbwwd", 4)]
        public void LongestSubstring_ValidInputs(string x, int expectedResult)
        {
            int actualResult = LengthOfLongestSubstring(x);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("aba", "aba")]
        [InlineData("abb", "bb")]
        [InlineData("babad", "bab")]
        [InlineData("aaaaaaabbbbbbb", "aaaaaaa")]
        [InlineData("aaaaaaabbbbbbbb", "bbbbbbbb")]
        public void LongestPalindrome_ValidInputs(string s, string expectedResult)
        {
            string actualResult = LongestPalindrome(s);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("PAYPALISHIRING", 1, "PAYPALISHIRING")]
        [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        public void ZigZagConvert_ValidInputs(string s, int rows, string expectedResult)
        {
            string actualResult = ZigZagConvert(s, rows);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(MorseCodeData))]
        public void MorseCode_ValidInputs(string[] input, int expectedResult)
        {
            var actualResult = UniqueMorseRepresentations(input);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(CommonPrefixData))]
        public void CommonPrefix(string[] input, string expected)
        {
            var actual = LongestCommonPrefix(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("(]", false)]
        [InlineData("[{()}]", true)]
        [InlineData("()[]{}", true)]
        [InlineData("([)]", false)]
        [InlineData("[", false)]
        [InlineData("]", false)]
        public void ValidParentheses(string input, bool expected)
        {
            var actual = ValidParantheses(input);
            Assert.True(expected == actual, "For input " + input + ", expected result " + expected + " but " + actual + " was returned.");
        }

        [Theory]
        [InlineData("","", true)]
        [InlineData("abcde", "deabc", true)]
        [InlineData("abcdf", "deabc", false)]
        public void RotateString(string A, string B, bool expected)
        {
            var actual = String.RotateString(A, B);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(PartitionData))]
        public void StringPartitions(string S, List<int> expected)
        {
            var actual = String.PartitionLabels(S);
            Assert.True(Enumerable.SequenceEqual(expected, actual));
        }

        [Theory]
        [MemberData(nameof(BattleshipData))]
        public void CountBattleships(char[,] board, int expected)
        {
            var actual = String.CountBattleships(board);
            Assert.Equal(expected, actual);
        }

        #region Test Data        

        public static readonly List<object[]> BattleshipData
            = new List<object[]>
            {
                new object[] 
                {
                    new char[,] { 
                        { 'X', '.', '.', 'X'},
                        { '.', '.', '.', 'X'},
                        { '.', '.', '.', 'X'},
                    }, 2
                },
                new object[]
                {
                    new char[,] {
                        { 'X', '.', '.', 'X'},
                        { 'X', '.', '.', 'X'},
                        { 'X', '.', '.', 'X'},
                    }, 2
                },
                new object[]
                {
                    new char[,] {
                        { 'X', '.', '.', 'X'},
                        { '.', '.', '.', 'X'},
                        { 'X', 'X', '.', 'X'},
                    }, 3
                },
                new object[]
                {
                    new char[,] {
                        { 'X', '.', '.', 'X'},
                        { '.', '.', '.', 'X'},
                        { 'X', 'X', 'X', '.'},
                    }, 3
                },
                new object[]
                {
                    new char[,] {
                        { '.', '.', '.', '.'},
                        { '.', '.', '.', '.'},
                        { '.', '.', '.', '.'},
                    }, 0
                },
            };

        public static readonly List<object[]> PartitionData
            = new List<object[]>
            {
                new object[] { "ababcbacadefegdehijhklij", new List<int> { 9, 7, 8 } },
                new object[] { "ababcbacadefegdehijhklia", new List<int> { 24 } },
                new object[] { "a", new List<int> { 1 } },
            };

        public static readonly List<object[]> CommonPrefixData
            = new List<object[]>
            {
                new object[] { new string[] { "hello", "hel", "hem", "helloo" }, "he" },
                new object[] { new string[] { }, "" },
                new object[] { new string[] { "abb" }, "abb" },
                new object[] { new string[] { "flower", "flow", "flight" }, "fl" },
                new object[] { new string[] { "abb", "abc" }, "ab" },
                new object[] { new string[] { "abb", "abb", "abb", "abb", "abbbb" }, "abb" }
            };

        public static readonly List<object[]> MorseCodeData
            = new List<object[]>
            {
                new object[] { new string[] { "gin", "zen", "gig", "msg" }, 2 },
            };

        #endregion
    }
}
