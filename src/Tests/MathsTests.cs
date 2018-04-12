using System;
using System.Collections.Generic;
using LeetCode.Model;
using static LeetCode.Maths;
using Xunit;

namespace LeetCode.Tests
{
    public class MathsTests
    {
        [Theory]
        [MemberData(nameof(PerimeterData))]
        public void IslandPerimeter_ValidInputs(int[,] grid, int expectedResult)
        {
            int actualResult = CalculateIslandPerimeter(grid);
            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<object[]> _perimeterData
            = new List<object[]>
            {
                new object[] { new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }, 0 },
                new object[] { new int[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } }, 16 },
                new object[] { new int[,] { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 1, 1, 1, 0 } }, 18 },
                new object[] { new int[,] { { 0, 0 }, { 1, 1 } }, 6 }
            };
        public static IEnumerable<object[]> PerimeterData
        {
            get { return _perimeterData; }
        }
        
        [Theory]
        [MemberData(nameof(ComplementData))]
        public void ComplementNumber_ValidInputs(int number, int expectedResult)
        {
            int actualResult = FindComplementNumber(number);
            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<object[]> _complementData
            = new List<object[]>
            {
                new object[] { 3, 0 },
                new object[] { 5, 2 },
                new object[] { 7, 0 },
                new object[] { 8, 7 }
                //new object[] { 2147483647, 0 },
                //new object[] { 2147483646, 1 },
                //new object[] { 2147483645, 2 },
                //new object[] { 2147483644, 3 }
            };
        public static IEnumerable<object[]> ComplementData
        {
            get { return _complementData; }
        }
        
        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(17, 324, 5)]
        public void HammingDistance_ValidInputs(int x, int y, int expectedResult)
        {
            int actualResult = Maths.FindHammingDistance(x, y);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(PartitionData))]
        public void LargestSumValues_ValidInputs(int[] intArray, int expectedResult)
        {
            int actualResult = Maths.FindLargestSumOfMinValues(intArray);
            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<object[]> _partitionData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 2, 3, 4}, 4 },
                new object[] { new int[] { 1, 4, 2, 3}, 4 },
                new object[] { new int[] { 1, 1, 1, 1}, 2 },
                new object[] { new int[] { 1, 6, 15, 93}, 16 }
            };
        public static IEnumerable<object[]> PartitionData
        {
            get { return _partitionData; }
        }

        [Theory]
        [MemberData(nameof(CandyData))]
        public void DistributeCandies_ValidInputs(int[] candies, int expectedResult)
        {
            int actualResult = Maths.DistributeCandies(candies);
            Assert.Equal(expectedResult, actualResult);
        }
        private static readonly List<object[]> _candyData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 2, 3, 4 }, 2 },
                new object[] { new int[] { 1, 1, 1, 1 }, 1 },
                new object[] { new int[] { 1, 2, 1, 1 }, 2 }
            };
        public static IEnumerable<object[]> CandyData
        {
            get { return _candyData; }
        }

        [Theory]
        [MemberData(nameof(MatrixData))]
        public void MatrixReshape(int[,] inputMatrix, int outputRows, int outputColumns, int[,] expectedResult)
        {
            int[,] actualResult = Maths.MatrixReshape(inputMatrix, outputRows, outputColumns);
            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<object[]> _matrixData
            = new List<object[]>
            {
                new object[]
                {
                    new int[,] { { 1, 2 }, { 3, 4 } }, 1, 4, new int[,] { { 1, 2, 3, 4 } }
                },
                new object[]
                {
                    new int[,] { { 1, 2, 3, 4 }, { 4, 5, 6, 7 } }, 1, 4, new int[,] { { 1, 2, 3, 4 }, { 4, 5, 6, 7 } }
                },
                new object[]
                {
                    new int[,] { { 1, 2, 3, 4 }, { 4, 5, 6, 7 } }, 8, 1, new int[,] { { 1 }, { 2 }, { 3 }, { 4 }, { 4 }, { 5 }, { 6 }, { 7 } }
                }
            };
        public static IEnumerable<object[]> MatrixData
        {
            get { return _matrixData; }
        }

        [Theory]
        [MemberData(nameof(GreaterNumberData))]
        public void NextGreaterNumber(int[] findNums, int[] nums, int[] expectedResult)
        {
            int[] actualResult = Maths.NextGreaterElement(findNums, nums);
            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<object[]> _greaterNumberData
            = new List<object[]>
            {
                new object[] { new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 }, new int[] { -1, 3, -1 } }
            };
        public static IEnumerable<object[]> GreaterNumberData
        {
            get { return _greaterNumberData; }
        }

        [Theory]
        [InlineData(new int[] { 1, 1 }, 2)]
        [InlineData(new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
        public void ConsecutiveOnes_ValidInputs(int[] nums, int expectedResult)
        {
            int actualResult = Maths.MaxConsecutiveOnes(nums);
            Assert.Equal(expectedResult, actualResult);
        }
        
        [Theory]
        [InlineData("aaa", "bbb", 3)]
        [InlineData("aaa", "aaa", -1)]
        [InlineData("aa", "baab", 4)]
        [InlineData("baab", "aa", 4)]
        [InlineData("aa", "baaccccccaab", 12)]
        public void UncommonSequence_ValidInputs(string x, string y, int expectedResult)
        {
            int actualResult = Maths.LongestUncommonSequence(x, y);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("UD", true)]
        [InlineData("UU", false)]
        public void JudgeCircuit_ValidInputs(string moves, bool expectedResult)
        {
            var actualResult = Maths.JudgeCircle(moves);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(SelfDividingData))]
        public void SeflDividing_ValidInputs(int left, int right, List<int> expectedResult)
        {
            var actualResult = Maths.SelfDividingNumbers(left, right);
            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<object[]> _selfDividingData
            = new List<object[]>
            {
                        new object[] { 1, 22, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22 } }
            };
        public static IEnumerable<object[]> SelfDividingData
        {
            get { return _selfDividingData; }
        }


        public class ComplexNumberMultiplyTests
        {
            [Theory]
            [InlineData("1+2i", "3+4i", "-5+10i")]
            public void TestInputs(string input1, string input2, string expectedResult)
            {
                string actualResult = Maths.ComplexNumberMultiply(input1, input2);
                Assert.Equal(expectedResult, actualResult);
            }
        }
        public class AddListNodes
        {
            [Theory]
            [MemberData(nameof(ListNodeData))]
            public void ValidInputs(ListNode input1, ListNode input2, ListNode expectedResult)
            {
                ListNode actualResult = Maths.AddTwoNumbers(input1, input2);
                Assert.Equal(expectedResult, actualResult);
            }

            private static readonly List<object[]> _listNodeData
                = new List<object[]>
                {
                        new object[] { new ListNode(1), new ListNode(7), new ListNode(8) },
                        new object[] { new ListNode(5), new ListNode(5), new ListNode(0, 1) },
                        new object[] { new ListNode(1), new ListNode(9,9), new ListNode( 0, 0, 1) },
                        new object[] { new ListNode(0,0,1), new ListNode(0,0,2), new ListNode( 0, 0, 3) }
                };
            public static IEnumerable<object[]> ListNodeData
            {
                get { return _listNodeData; }
            }
        }

        [Theory]
        [MemberData(nameof(CityData))]
        public void CitySkyline_ValidInputs(int[][] grid, int expectedResult)
        {
            var actualResult = Maths.MaxIncreaseKeepingSkyline(grid);
            Assert.Equal(expectedResult, actualResult);
        }

        private static readonly List<object[]> _cityData = new List<object[]>
        {
            new object[]
            {
                new int [][]
                {
                    new int[] { 3, 0, 8, 4 },
                    new int[] { 2, 4, 5, 7 },
                    new int[] { 9, 2, 6, 3 },
                    new int[] { 0, 3, 1, 0 }
                },
                35
            }
        };

        public static IEnumerable<object[]> CityData { get => _cityData; }
    }
}
