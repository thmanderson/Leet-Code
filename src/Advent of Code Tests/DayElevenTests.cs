using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    public class DayElevenTests
    {
        [Theory]
        [InlineData(new string[] { "ne", "ne", "ne" }, 3)]
        [InlineData(new string[] { "ne", "ne", "sw", "sw" }, 0)]
        [InlineData(new string[] { "ne", "ne", "s", "s" }, 2)]
        [InlineData(new string[] { "se", "sw", "se", "sw", "sw" }, 3)]
        public void HexStepsTest(string[] input, int expectedResult)
        {
            int actualResult = DayEleven.HexStepsTaken(input, out int furtherDistance);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
