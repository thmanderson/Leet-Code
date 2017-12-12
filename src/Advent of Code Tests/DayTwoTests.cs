using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayTwoTests
    {
        [Theory]
        [InlineData(new int[] { 5, 1, 9, 5 }, 8)]
        [InlineData(new int[] { 7, 5, 3 }, 4)]
        [InlineData(new int[] { 2, 4, 6, 8 }, 6)]
        public void CheckSumTests(int[] row, int expectedResult)
        {
            // Arrange & Act
            int actualResult = DayTwo.CheckSum(row);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new int[] { 5, 9, 2, 8 }, 4)]
        [InlineData(new int[] { 9, 4, 7, 3 }, 3)]
        [InlineData(new int[] { 3, 8, 6, 5 }, 2)]
        public void DivisorTests(int[] row, int expectedResult)
        {
            // Arrange & Act
            int actualResult = DayTwo.WholeDivisor(row);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
