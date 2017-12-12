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
        [InlineData(new int[] { 3, 4, 1, 5 }, new int[] { 0, 1, 2, 3, 4}, 12)]
        public void KnotHashTest(int[] lengths, int[] input, int expectedResult)
        {
            int actualResult = DayTen.KnotHash(lengths, input);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
