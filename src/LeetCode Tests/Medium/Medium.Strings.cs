﻿using System;
using System.Collections.Generic;
using Xunit;
using LeetCode;
using static LeetCode.Medium.Strings;

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
    }
}
