using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayTenTests
    {
        [Theory]
        [InlineData("3, 4, 1, 5", 12)]
        public void KnotHashTest(string input, int expectedResult)
        {
            int actualResult = DayTen.KnotHashPartOne(input, 5);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        [InlineData("197,97,204,108,1,29,5,71,0,50,2,255,248,78,254,63", "35b028fe2c958793f7d5a61d07a008c8")]
        public void KnotHashPartTwoTest(string input, string expectedResult)
        {
            var actualResult = DayTen.KnotHashPartTwo(input);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
