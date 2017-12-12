using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayThreeTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(7, 2)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        [InlineData(312051, 430)]
        public void SpiralDistanceTest(int startPoint, int expectedResult)
        {
            // Arrange & Act
            var actualResult = DayThree.SpiralDistance(startPoint);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
