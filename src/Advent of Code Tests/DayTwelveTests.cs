using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayTwelveTests
    {
        [Fact]
        public void TestLinks()
        {
            int expectedResult = 6;
            int expectedTotalGroups = 2;

            int actualResult = DayTwelve.LinkedPipes(testInput, out int actualTotalGroups);

            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedTotalGroups, actualTotalGroups);
        }

        private Dictionary<int, List<int>> testInput = new Dictionary<int, List<int>>()
        {
            { 0, new List<int> { 2 } },
            { 1, new List<int> { 1 } },
            { 2, new List<int> { 0, 3, 4 } },
            { 3, new List<int> { 2, 4 } },
            { 4, new List<int> { 2, 3, 6 } },
            { 5, new List<int> { 6 } },
            { 6, new List<int> { 4, 5 } },
        };
    }
}
