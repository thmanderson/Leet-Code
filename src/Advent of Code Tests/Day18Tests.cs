using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day18Tests
    {
        [Theory]
        [MemberData(nameof(InputData))]
        public void Problem1Tests(string[] input, int expectedResult)
        {
            int actualResult = Day18.Problem1(input);
            Assert.Equal(expectedResult, actualResult);
        }

        public static IEnumerable<object[]> InputData
        {
            get { yield return new object[] { instructions, 4 }; }
        }

        private static string[] instructions = new string[]
        {
            "set a 1",
            "add a 2",
            "mul a a",
            "mod a 5",
            "snd a",
            "set a 0",
            "rcv a",
            "jgz a -1",
            "set a 1",
            "jgz a -2"
        };
    }
}
