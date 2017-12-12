using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    [Trait("TestCategory", "UnitTests")]
    public class DaySevenTests
    {
        [Fact]
        public void TestRootTower()
        {
            string actualResult = DaySeven.GetBase(towerData);
            string expectedResult = towerResult;

            Assert.Equal(expectedResult, actualResult);
        }
        
        [Fact]
        public void TestProblemWeight()
        {
            int actualResult = DaySeven.FindProblemWeight(towerData, DaySeven.GetBase(towerData));
            int expectedResult = problemWeightResult;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestWeight()
        {
            int actualResult = DaySeven.FindWeight(towerData, DaySeven.GetBase(towerData));
            int expectedResult = weightResult;

            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<Tuple<string, List<string>>> towerData
            = new List<Tuple<string, List<string>>>
            {
                new Tuple<string, List<string>>("pbga", new List<string> { "66" } ),
                new Tuple<string, List<string>>("xhth", new List<string> { "57" } ),
                new Tuple<string, List<string>>("ebii", new List<string> { "61" } ),
                new Tuple<string, List<string>>("havc", new List<string> { "66" } ),
                new Tuple<string, List<string>>("ktlj", new List<string> { "57" } ),
                new Tuple<string, List<string>>("fwft", new List<string> { "72", "ktlj", "cntj", "xhth" } ),
                new Tuple<string, List<string>>("qoyq", new List<string> { "66" } ),
                new Tuple<string, List<string>>("padx", new List<string> { "45", "pbga", "havc", "qoyq" } ),
                new Tuple<string, List<string>>("tknk", new List<string> { "41", "ugml", "padx", "fwft" } ),
                new Tuple<string, List<string>>("jptl", new List<string> { "61" } ),
                new Tuple<string, List<string>>("ugml", new List<string> { "68", "gyxo", "ebii", "jptl" } ),
                new Tuple<string, List<string>>("gyxo", new List<string> { "61" } ),
                new Tuple<string, List<string>>("cntj", new List<string> { "57" } ),
            };

        private static readonly string towerResult = "tknk";
        private static readonly int problemWeightResult = 60;
        private static readonly int weightResult = 243 + 243 + 251 + 41;
    }
}
