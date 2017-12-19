using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayFifteenTests
    {
        [Theory]
        [InlineData(65, 8921, 588)]
        public void GeneratorTest(int inputA, int inputB, int expectedResult)
        {
            var actualResult = DayFifteen.GeneratorCount(inputA, inputB, 40000000);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(65, 8921, 309)]
        public void SecondGeneratorTest(int inputA, int inputB, int expectedResult)
        {
            var actualResult = DayFifteen.SecondGeneratorCount(inputA, inputB, 5000000);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
