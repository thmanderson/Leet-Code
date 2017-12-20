using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using AdventOfCode;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayOneTests
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void InverseCaptchaExamples(string input, int expectedResult)
        {
            // Arrange & Act
            int actualResult = AdventOfCode.Day1.InverseCaptcha(input);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void HalfwayCaptchaExamples(string input, int expectedResult)
        {
            // Arrange & Act
            int actualResult = AdventOfCode.Day1.HalfwayCaptcha(input);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
