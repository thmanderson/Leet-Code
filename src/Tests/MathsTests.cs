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

        [Theory]
        [MemberData(nameof(MountainData))]
        public void MountainArray(int[] range, int expected)
        {
            var actual = Maths.LongestMountain(range);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(MaxAreaData))]
        public void MaxArea(int[] height, int expected)
        {
            var actual = Maths.MaxArea(height);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(LemonadeData))]
        public void LemonadeChange(int[] bills, bool expected)
        {
            var actual = Maths.LemonadeChange(bills);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(PermuteData))]
        public void Permute(int[] nums, IList<IList<int>> expected)
        {
            var actual = Maths.Permute(nums);

            Assert.Equal(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], actual[i]));
            }
        }

        [Theory]
        [MemberData(nameof(SingleNonDuplicateData))]
        public void SingleNonDuplicate(int[] nums, int expected)
        {
            var actual = Maths.SingleNonDuplicate(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(NumComponentsData))]
        public void NumComponents(int[] nums, int[] numsSubset, int expected)
        {
            ListNode input = ListNode.ConvertToListNode(nums);
            var actual = Maths.NumComponents(input, numsSubset);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(679213508, true)]
        public void ReorderedPowerOf2(int input, bool expected)
        {
            var actual = Maths.ReorderedPowerOf2(input);
            Assert.Equal(actual, expected);
        }

        [MemberData(nameof(TransposeData))]
        public void Transpose(int[][] input, int[][] expected)
        {
            var actual = Maths.Transpose(input);

            Assert.Equal(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.True(Enumerable.SequenceEqual(expected[i], actual[i]));
        }

        #region Test Data

        public static readonly List<object[]> TransposeData
            = new List<object[]>
            {
                new object[]
                {
                    new int[][]
                    {
                        new int[]{ 1,2,3 },
                        new int[]{ 4,5,6 },
                        new int[]{ 7,8,9 }
                    },
                    new int[][]
                    {
                        new int[]{ 1,4,7 },
                        new int[]{ 2,5,8 },
                        new int[]{ 3,6,9 },
                    }
                },
                new object[]
                {
                    new int[][]
                    {
                        new int[]{ 1,2 },
                        new int[]{ 3,4 },
                        new int[]{ 5,6 },
                        new int[]{ 7,8 },
                    },
                    new int[][]
                    {
                        new int[]{ 1,3,5,7 },
                        new int[]{ 2,4,6,8 },
                    },
                },
            };

        public static readonly List<object[]> NumComponentsData
            = new List<object[]>
            {
                new object[] { new int[] { 0, 1, 2, 3 }, new int[] { 0, 1, 3}, 2 },
                new object[] { new int[] { 0, 1, 2, 3, 4 }, new int[] { 0, 3, 1, 4 }, 2 },
                new object[] { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 0, 2, 4, 6, 8, 10 }, 6 },
            };

        public static readonly List<object[]> SingleNonDuplicateData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }, 2 },
                new object[] { new int[] { 3, 3, 7, 7, 10, 11, 11 }, 10 },
                new object[] { new int[] { 1, 1, 2 }, 2 },
                new object[] { new int[] { 1, 1, 2, 2, 3 }, 3 },
                new object[] { new int[] { 1, 2, 2, 3, 3 }, 1 },
            };

        public static readonly List<object[]> PermuteData
            = new List<object[]>
            {
                new object[] {
                    new int[] { 1, 2, 3 },
                    new List<IList<int>>
                    {
                        new List<int>{ 1, 2, 3 },
                        new List<int>{ 1, 3, 2 },
                        new List<int>{ 2, 1, 3 },
                        new List<int>{ 2, 3, 1 },
                        new List<int>{ 3, 1, 2 },
                        new List<int>{ 3, 2, 1 },
                    }
                },
                new object[] {
                    new int[] { 1 },
                    new List<IList<int>>
                    {
                        new List<int>{ 1 },
                    }
                },
            };

        public static readonly List<object[]> LemonadeData
            = new List<object[]>
            {
                new object[] { new int[] { }, true },
                new object[] { new int[] { 5, 5, 5, 10, 20 }, true },
                new object[] { new int[] { 5, 5, 10 }, true },
                new object[] { new int[] { 10, 10 }, false },
                new object[] { new int[] { 5, 5, 10, 10, 20 }, false },
            };

        public static readonly List<object[]> MaxAreaData
            = new List<object[]>
            {
                new object[] { new int[] { 1, 1 }, 1 },
                new object[] { new int[] { 2, 1 }, 1 },
                new object[] { new int[] { 1, 1, 1, 10, 10, 1, 1 }, 10 },
                new object[] { new int[] { 1, 1, 1, 10, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 15 },
                new object[] { new int[] { 1, 1, 1, 10, 10, 1, 1, 1, 1, 1, 5, 1, 1, 1, 5, 1 }, 55 },
                new object[] { new int[] { 1, 1, 6, 7, 1, 8, 3, 1, 1, 1, 1, 8, 12, 36, 1, 12, 4, 1, 1, 1, 9 }, 120 },
            };

        public static readonly List<object[]> MountainData
            = new List<object[]>
            {
                new object[] { new int[] { 2, 1, 4, 7, 3, 2, 5 }, 5 },
                new object[] { new int[] { 875, 884, 239, 731, 723, 685 }, 4 },
                new object[] { new int[] { 2, 2, 2 }, 0 },
                new object[] { new int[] { 2, 1, 4, 7, 3, 2, 5, 1, 2, 3, 4, 3, 2, 1 }, 7 },
                new object[] { new int[] { }, 0 },
                new object[] { new int[] { 0 }, 0 },
                new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, 21 },
                new object[] {
                    new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255,256,257,258,259,260,261,262,263,264,265,266,267,268,269,270,271,272,273,274,275,276,277,278,279,280,281,282,283,284,285,286,287,288,289,290,291,292,293,294,295,296,297,298,299,300,301,302,303,304,305,306,307,308,309,310,311,312,313,314,315,316,317,318,319,320,321,322,323,324,325,326,327,328,329,330,331,332,333,334,335,336,337,338,339,340,341,342,343,344,345,346,347,348,349,350,351,352,353,354,355,356,357,358,359,360,361,362,363,364,365,366,367,368,369,370,371,372,373,374,375,376,377,378,379,380,381,382,383,384,385,386,387,388,389,390,391,392,393,394,395,396,397,398,399,400,401,402,403,404,405,406,407,408,409,410,411,412,413,414,415,416,417,418,419,420,421,422,423,424,425,426,427,428,429,430,431,432,433,434,435,436,437,438,439,440,441,442,443,444,445,446,447,448,449,450,451,452,453,454,455,456,457,458,459,460,461,462,463,464,465,466,467,468,469,470,471,472,473,474,475,476,477,478,479,480,481,482,483,484,485,486,487,488,489,490,491,492,493,494,495,496,497,498,499,500,498,497,496,495,494,493,492,491,490,489,488,487,486,485,484,483,482,481,480,479,478,477,476,475,474,473,472,471,470,469,468,467,466,465,464,463,462,461,460,459,458,457,456,455,454,453,452,451,450,449,448,447,446,445,444,443,442,441,440,439,438,437,436,435,434,433,432,431,430,429,428,427,426,425,424,423,422,421,420,419,418,417,416,415,414,413,412,411,410,409,408,407,406,405,404,403,402,401,400,399,398,397,396,395,394,393,392,391,390,389,388,387,386,385,384,383,382,381,380,379,378,377,376,375,374,373,372,371,370,369,368,367,366,365,364,363,362,361,360,359,358,357,356,355,354,353,352,351,350,349,348,347,346,345,344,343,342,341,340,339,338,337,336,335,334,333,332,331,330,329,328,327,326,325,324,323,322,321,320,319,318,317,316,315,314,313,312,311,310,309,308,307,306,305,304,303,302,301,300,299,298,297,296,295,294,293,292,291,290,289,288,287,286,285,284,283,282,281,280,279,278,277,276,275,274,273,272,271,270,269,268,267,266,265,264,263,262,261,260,259,258,257,256,255,254,253,252,251,250,249,248,247,246,245,244,243,242,241,240,239,238,237,236,235,234,233,232,231,230,229,228,227,226,225,224,223,222,221,220,219,218,217,216,215,214,213,212,211,210,209,208,207,206,205,204,203,202,201,200,199,198,197,196,195,194,193,192,191,190,189,188,187,186,185,184,183,182,181,180,179,178,177,176,175,174,173,172,171,170,169,168,167,166,165,164,163,162,161,160,159,158,157,156,155,154,153,152,151,150,149,148,147,146,145,144,143,142,141,140,139,138,137,136,135,134,133,132,131,130,129,128,127,126,125,124,123,122,121,120,119,118,117,116,115,114,113,112,111,110,109,108,107,106,105,104,103,102,101,100,99,98,97,96,95,94,93,92,91,90,89,88,87,86,85,84,83,82,81,80,79,78,77,76,75,74,73,72,71,70,69,68,67,66,65,64,63,62,61,60,59,58,57,56,55,54,53,52,51,50,49,48,47,46,45,44,43,42,41,40,39,38,37,36,35,34,33,32,31,30,29,28,27,26,25,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0 },
                    1000
                },
            };

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
