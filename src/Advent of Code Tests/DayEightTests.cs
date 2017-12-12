using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayEightTests
    {
        [Theory]
        [InlineData(new string[] { "b inc 5 if a > 1", "a inc 1 if b < 5", "c dec -10 if a >= 1", "c inc -20 if c == 10" }, 1, 10 )]
        public void InstructionTests(string[] input, int expectedResult, int expectedLargest)
        {
            var actualResult = DayEight.LargestAfterInstructions(input, out int actualLargest);

            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedLargest, actualLargest);
        }
    }
}
