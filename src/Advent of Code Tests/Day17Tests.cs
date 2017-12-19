using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class Day17Tests
    {
        [Theory]
        [InlineData(3, 638)]
        public void Problem1Tests(int input, int expectedResult)
        {
            var actualResult = Day17.Problem1(input);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
