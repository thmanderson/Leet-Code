using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DaySixTests
    {
        [Theory]
        [InlineData(new int[] { 0, 2, 7, 0 }, 5, 4)]
        public void RedistributeBlocksTests(int[] input, int expectedResult, int expectedLoopSize)
        {
            // Arrange & Act
            int actualResult = DaySix.Redistribute(input, out int actualLoopSize);

            // Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedLoopSize, actualLoopSize);
        }
    }
}
