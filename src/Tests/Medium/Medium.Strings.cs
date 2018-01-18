using System;
using System.Collections.Generic;
using Xunit;
using LeetCode;
using static LeetCode.Medium.String;

namespace LeetCodeTests.Medium
{
    public class Strings
    {
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
