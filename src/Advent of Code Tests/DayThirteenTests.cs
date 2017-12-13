using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayThirteenTests
    {
        [Fact]
        public void FirewallSeverityTest()
        {
            int actualResult = DayThirteen.FirewallSeverity(testInput, 0);

            Assert.Equal(expectedResult, actualResult);
        }

        private List<Tuple<int, int>> testInput = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(0,3),
            new Tuple<int, int>(1,2),
            new Tuple<int, int>(4,4),
            new Tuple<int, int>(6,4),
        };
        private int expectedResult = 24;
    }
}
