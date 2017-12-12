using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayFiveTests
    {
        [Theory]
        [InlineData(new int[] { 0, 3, 0 , 1, -3 }, 5)]
        public void MazeTests(int[] maze, int expectedResult)
        {
            // Arrange & Act
            int actualResult = DayFive.JumpsToEscapeMaze(maze);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new int[] { 0, 3, 0, 1, -3 }, 10)]
        public void MazeTestsComplex(int[] maze, int expectedResult)
        {
            // Arrange & Act
            int actualResult = DayFive.JumpsToEscapeComplexMaze(maze);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
