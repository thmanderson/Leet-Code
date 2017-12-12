using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DayFourTests
    {
        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void PassphraseTests(string passphrase, bool expectedResult)
        {
            // Arrange & Act
            bool actualResult = DayFour.IsPassphraseValid(passphrase);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("abcde fghij", true)]
        [InlineData("abcde xyz ecdab", false)]
        [InlineData("a ab abc abd abf abj", true)]
        [InlineData("iiii oiii ooii oooi oooo", true)]
        [InlineData("oiii ioii iioi iiio", false)]
        public void ComplexPassphraseTests(string passphrase, bool expectedResult)
        {
            // Arrange & Act
            bool actualResult = DayFour.IsPassphraseValidComplex(passphrase);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
