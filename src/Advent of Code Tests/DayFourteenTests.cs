using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    public class DayFourteenTests
    {
        [Theory]
        [InlineData("flqrgnkx", 128, 8108)]
        public void DefragTest(string input, int rows, int expectedResult)
        {
            var actualResult = DayFourteen.Defrag(input, rows);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("flqrgnkx", 128, 1242)]
        public void DefragGroupsTest(string input, int rows, int expectedResult)
        {
            var actualResult = DayFourteen.DefragGroups(input, rows);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
