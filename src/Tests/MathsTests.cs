using System;
using System.Collections.Generic;
using System.Linq;
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

        [Theory]
        [MemberData(nameof(ComplementData))]
        public void ComplementNumber_ValidInputs(int number, int expectedResult)
        {
            int actualResult = FindComplementNumber(number);
            Assert.Equal(expectedResult, actualResult);
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

        [Theory]
        [MemberData(nameof(CandyData))]
        public void DistributeCandies_ValidInputs(int[] candies, int expectedResult)
        {
            int actualResult = Maths.DistributeCandies(candies);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(MatrixData))]
        public void MatrixReshape(int[,] inputMatrix, int outputRows, int outputColumns, int[,] expectedResult)
        {
            int[,] actualResult = Maths.MatrixReshape(inputMatrix, outputRows, outputColumns);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(GreaterNumberData))]
        public void NextGreaterNumber(int[] findNums, int[] nums, int[] expectedResult)
        {
            int[] actualResult = Maths.NextGreaterElement(findNums, nums);
            Assert.Equal(expectedResult, actualResult);
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

        [Theory]
        [InlineData("1+2i", "3+4i", "-5+10i")]
        public void TestInputs(string input1, string input2, string expectedResult)
        {
            string actualResult = Maths.ComplexNumberMultiply(input1, input2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(ListNodeData))]
        public void ValidInputs(ListNode input1, ListNode input2, ListNode expectedResult)
        {
            ListNode actualResult = Maths.AddTwoNumbers(input1, input2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(CityData))]
        public void CitySkyline_ValidInputs(int[][] grid, int expectedResult)
        {
            var actualResult = Maths.MaxIncreaseKeepingSkyline(grid);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(1534236469, 0)]
        [InlineData(-2147483648, 0)]
        public void ReverseInteger(int input, int expectedResult)
        {
            var actualResult = Maths.Reverse(input);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("IX", 9)]
        [InlineData("XIV", 14)]
        public void RomanNumerals(string input, int expected)
        {
            var actual = RomanToInt(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(SortedDedupeData))]
        public void RemoveDuplicates(int[] input, int expected)
        {
            var actual = Maths.RemoveDuplicates(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(MoveZeroesData))]
        public void MoveZeroes(int[] input, int[] expected)
        {
            Maths.MoveZeroes(input);
            Assert.True(Enumerable.SequenceEqual(input, expected));
        }

        [Theory]
        [MemberData(nameof(ShortestToCharData))]
        public void ShortestToChar(string S, char C, int[] expected)
        {
            var actual = Maths.ShortestToChar(S, C);
            Assert.True(Enumerable.SequenceEqual(actual, expected));
        }

        [Theory]
        [InlineData(1, 2, 0)]
        [InlineData(6, 10, 4)]
        [InlineData(10, 15, 5)]
        public void PrimeBits(int L, int R, int expected)
        {
            var actual = Maths.CountPrimeSetBits(L, R);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(MaximumSubArrayData))]
        public void MaxSubArray(int[] nums, int expected)
        {
            var actual = Maths.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(QueueData))]
        public void ReconstructQueue(int[,] people, int[,] expected)
        {
            var actual = Maths.ReconstructQueue(people);

            for (int i = 0; i < people.Length / people.Rank; i++)
            {
                for (int j = 0; j < people.Rank; j++)
                {
                    Assert.Equal(expected[i, j], actual[i, j]);
                }
            }
        }

        [Theory]
        [MemberData(nameof(WorkerProfitData))]
        public void ProfitableWorkers(int[] difficulty, int[] profit, int[] worker, int expected)
        {
            var actual = Maths.MaxProfitAssignment(difficulty, profit, worker);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(FlowerBedData))]
        public void FlowerBeds(int[] flowerbed, int n, bool expected)
        {
            var actual = CanPlaceFlowers(flowerbed, n);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 2)]
        [InlineData(9, 3)]
        [InlineData(15, 4)]
        public void ConsecutiveNumbersSum(int N, int expected)
        {
            var actual = Maths.ConsecutiveNumbersSum(N);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(FlipImageData))]
        public void FlipAndInvertImage(int[][] A, int[][] expected)
        {
            var actual = Maths.FlipAndInvertImage(A);

            Assert.Equal(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++) Assert.True(Enumerable.SequenceEqual(expected[i], actual[i]));
        }

        [Theory]
        [MemberData(nameof(RectangleOverlapData))]
        public void RectangleOverlap(int[] rec1, int[] rec2, bool expected)
        {
            var actual = Maths.IsRectangleOverlap(rec1, rec2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(VisitRoomsData))]
        public void VisitRooms(IList<IList<int>> rooms, bool expected)
        {
            var actual = Maths.CanVisitAllRooms(rooms);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(RemoveElementData))]
        public void RemoveElement(int[] nums, int val, int[] expected, int expectedLength)
        {
            // Arrange & Act
            var actual = new int[nums.Length];
            nums.CopyTo(actual, 0);
            int actualLength = Maths.RemoveElement(actual, val);

            // Assert
            Assert.Equal(expectedLength, actualLength);
            Assert.True(Enumerable.SequenceEqual(expected, actual.Take(actualLength)));
        }

        [Theory]
        [MemberData(nameof(SwapNodeData))]
        public void SwapElements(int[] inputNums, int[] expectedNums)
        {
            // Arrange
            ListNode input = ListNode.ConvertToListNode(inputNums);
            ListNode expected = ListNode.ConvertToListNode(expectedNums);

            // Act
            var actual = Maths.SwapPairs(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        #region Test Data

        public static readonly List<object[]> SwapNodeData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 2, 3, 4 }, new int[] { 2, 1, 4, 3 } },
            };

        public static readonly List<object[]> RemoveElementData
            = new List<object[]>
            {
                new object[] { new int[] { 0,1,2,2,3,0,4,2 }, 2, new int[] { 0,1,3,0,4 }, 5 },
            };

        public static readonly List<object[]> VisitRoomsData
            = new List<object[]>
            {
                new object[]
                {
                    new List<IList<int>> { new List<int> { } },
                    true
                },
                new object[] 
                {
                    new List<IList<int>> { new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { }, },
                    true
                },
                new object[]
                {
                    new List<IList<int>> { new List<int> { 1, 3 }, new List<int> { 3, 0, 1 }, new List<int> { 2 }, new List<int> { 0 }, },
                    false
                },
            };

        public static readonly List<object[]> RectangleOverlapData
            = new List<object[]>
            {
                new object[] { new int[] { 0, 0, 2, 2 }, new int[] { 1, 1, 3, 3 }, true },
                new object[] { new int[] { 1, 1, 3, 3 }, new int[] { 0, 0, 2, 2 }, true },
                new object[] { new int[] { 0, 0, 1, 1 }, new int[] { 1, 0, 2, 1 }, false },
                new object[] { new int[] { 0, 0, 100, 100 }, new int[] { 100, 90, 200, 190 }, false },
                new object[] { new int[] { 2, 5, 7, 10 }, new int[] { 4, 3, 9, 8 }, true },
                new object[] { new int[] { 4, 3, 9, 8 }, new int[] { 2, 5, 7, 10 }, true },
                new object[] { new int[] { 4, 4, 14, 7 }, new int[] { 4, 3, 8, 8 }, true },
                new object[] { new int[] { -4, -9, -2, 3 }, new int[] { 1, -5, 9, -1 }, false },
            };

        public static readonly List<object[]> FlipImageData
            = new List<object[]>
            {
                new object[] 
                {
                    new int[][]
                    {
                        new int[]{ 1,1,0 },
                        new int[]{ 1,0,1 },
                        new int[]{ 0,0,0 }
                    },
                    new int[][]
                    {
                        new int[]{ 1,0,0 },
                        new int[]{ 0,1,0 },
                        new int[]{ 1,1,1 },
                    }
                },
                new object[]
                {
                    new int[][]
                    {
                        new int[]{ 1,1,0,0 },
                        new int[]{ 1,0,0,1 },
                        new int[]{ 0,1,1,1 },
                        new int[]{ 1,0,1,0 }
                    },
                    new int[][]
                    {
                        new int[]{ 1,1,0,0 },
                        new int[]{ 0,1,1,0 },
                        new int[]{ 0,0,0,1 },
                        new int[]{ 1,0,1,0 }
                    },
                }
            };

        public static readonly List<object[]> FlowerBedData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 0, 0, 0, 1 }, 1, true },
                new object[] { new int[] { 1, 0, 0, 0, 1 }, 2, false },
                new object[] { new int[] { 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0 }, 3, true },
                new object[] { new int[] { 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0 }, 7, false },
                new object[] { new int[] { 1, 0, 0, 0, 1, 0, 0 }, 2, true },
            };

        public static readonly List<object[]> WorkerProfitData
            = new List<object[]>
            {
                new object[] {
                    new int[] { 2, 4, 6, 8, 10 },
                    new int[] { 10, 20, 30, 40, 50 },
                    new int[] { 4, 5, 6, 7 },
                    100
                },
                new object[] {
                    new int[] { 85, 47, 57 },
                    new int[] { 24, 66, 99 },
                    new int[] { 40, 25, 25 },
                    0
                },
            };

        public static readonly List<object[]> QueueData
            = new List<object[]>
            {
                new object[] {
                    new int[,] { { 7, 0 }, { 4, 4 }, { 7, 1 }, { 5, 0 }, { 6, 1 }, { 5, 2 } },
                    new int[,] { { 5, 0 }, { 7, 0 }, { 5, 2 }, { 6, 1 }, { 4, 4 }, { 7, 1 } }
                },
                new object[] {
                    new int[,] { { 7, 0 }, { 4, 4 }, { 7, 1 }, { 5, 0 }, { 6, 1 }, { 5, 2 }, { 5, 1 } },
                    new int[,] { { 5, 0 }, { 5, 1 }, { 5, 2 }, { 7, 0 }, { 4, 4 }, { 6, 1 }, { 7, 1 } }
                },
                new object[] {
                    new int[,] { { 1, 5 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 1 }, { 5, 0 } },
                    new int[,] { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 5, 0 }, { 4, 1 }, { 1, 5 } }
                },
            };

        public static readonly List<object[]> MaximumSubArrayData
            = new List<object[]>
            {
                new object[] { new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6 },
                new object[] { new int[] { -2 }, -2 },
                new object[] { new int[] { }, Int32.MinValue },
                new object[] { new int[] { -1, -2, -3, -4, -5, -6 }, -1 },
            };

        public static readonly List<object[]> ShortestToCharData
            = new List<object[]>
            {
                new object[] { "e", 'e', new int[] { 0 } },
                new object[] { "loveleetcode", 'e', new int[] { 3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0 } },
                new object[] { "hellomynameisearl", 'e', new int[] { 1, 0, 1, 2, 3, 4, 4, 3, 2, 1, 0, 1, 1, 0, 1, 2, 3 } },
            };

        public static readonly List<object[]> MoveZeroesData
            = new List<object[]>
            {
                new object[] { new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12,0, 0} },
            };

        public static readonly List<object[]> CandyData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 2, 3, 4 }, 2 },
                new object[] { new int[] { 1, 1, 1, 1 }, 1 },
                new object[] { new int[] { 1, 2, 1, 1 }, 2 }
            };

        public static readonly List<object[]> ComplementData
            = new List<object[]>
            {
                new object[] { 3, 0 },
                new object[] { 5, 2 },
                new object[] { 7, 0 },
                new object[] { 8, 7 }
            };

        public static readonly List<object[]> MatrixData
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

        public static readonly List<object[]> PartitionData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 2, 3, 4}, 4 },
                new object[] { new int[] { 1, 4, 2, 3}, 4 },
                new object[] { new int[] { 1, 1, 1, 1}, 2 },
                new object[] { new int[] { 1, 6, 15, 93}, 16 }
            };

        public static readonly List<object[]> GreaterNumberData
            = new List<object[]>
            {
                new object[] { new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 }, new int[] { -1, 3, -1 } }
            };

        public static readonly List<object[]> SelfDividingData
            = new List<object[]>
            {
                new object[] { 1, 22, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22 } }
            };

        public static readonly List<object[]> CityData
            = new List<object[]>
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

        public static readonly List<object[]> PerimeterData
            = new List<object[]>
            {
                new object[] { new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }, 0 },
                new object[] { new int[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } }, 16 },
                new object[] { new int[,] { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 1, 1, 1, 0 } }, 18 },
                new object[] { new int[,] { { 0, 0 }, { 1, 1 } }, 6 }
            };

        public static readonly List<object[]> ListNodeData
            = new List<object[]>
            {
                new object[] { new ListNode(1), new ListNode(7), new ListNode(8) },
                new object[] { new ListNode(5), new ListNode(5), new ListNode(0, 1) },
                new object[] { new ListNode(1), new ListNode(9,9), new ListNode( 0, 0, 1) },
                new object[] { new ListNode(0,0,1), new ListNode(0,0,2), new ListNode( 0, 0, 3) }
            };

        public static readonly List<object[]> SortedDedupeData
            = new List<object[]>
            {
                new object[] { new int[] { },  0 },
                new object[] { new int[] { 1 },  1 },
                new object[] { new int[] { 1, 1 },  1 },
                new object[] { new int[] { 1, 2 },  2 },
                new object[] { new int[] { 1, 1, 2 },  2 },
                new object[] { new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 },  5 },
                new object[] { new int[] { 0, 1, 2, 2, 3, 4 },  5 }
            };

        #endregion
    }
}
