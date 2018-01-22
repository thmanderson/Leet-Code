using System;
using System.Collections.Generic;

namespace LeetCode.Easy
{
    public class Maths
    {
        /// <summary>
        /// LeetCode problem 461 - Hamming Distance: https://leetcode.com/problems/hamming-distance/#/description
        /// Returns the hamming distance (https://en.wikipedia.org/wiki/Hamming_distance) between 2 integers.
        /// </summary>
        /// <param name="x">First input integer</param>
        /// <param name="y">Second input integer</param>
        /// <returns>Hamming distance between the 2 input integers</returns>
        public static int FindHammingDistance(int x, int y)
        {
            // XOR of the input numbers. Once we have this, we need to count the number of bits in the result.
            int product = x ^ y, bitCount = 0;

            // Now we have our product; product = bitwise AND against product - 1.
            // e.g. if product = 10101, this operation is 10101 & 10100, giving 10100, in effect counting, then removing, the furthest bit to the right.
            for (bitCount = 0; product > 0; bitCount++) product = product & (product - 1);

            return bitCount;
        }

        /// <summary>
        /// LeetCode problem 463 - Island Perimeter: https://leetcode.com/problems/island-perimeter/#/description
        /// Given a 2D rectangular binary "map", where 1 == land and 0 == water, calculate the perimter of the island depicted.
        /// Assume no diagonal connections between land, and no 'lakes' in the island.
        /// </summary>
        /// <param name="grid">Grid "map" of and island, each int value is either 1 or 0.</param>
        /// <returns></returns>
        public static int CalculateIslandPerimeter(int[,] grid)
        {
            // The method here is to count the number of squares of land, which adds length of 4 to the total perimeter.
            // Then, count the number of neighbours directly 'West' or 'South' of each square of land, and deduct length of 2 from the total perimeter.
            // This is a faster alternative than counting all neighbours each side, and deducting 1 total length, but amounts to the same.

            // Determine size of the grid.
            int gridWidth = grid.GetLength(0);
            int gridHeight = grid.GetLength(1);

            // Count the number of squares of land, and count the total neighbours to the 'West' and 'South'.
            int landCount = 0, neighbourCount = 0;

            // Iterate through the given 'map' array, one row at a time.
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    // If the current square is water, move on.
                    if (grid[i, j] == 0) continue;

                    // If the current square is land, count it, and neighbours to the 'West' and 'South'.
                    else
                    {
                        landCount++;
                        // If we're not at the edge of the map, and the next square is land (check both directions).
                        if (j != gridHeight - 1) if (grid[i, j + 1] == 1) neighbourCount++;
                        if (i != gridWidth - 1) if (grid[i + 1, j] == 1) neighbourCount++;
                    }

                }
            }

            // Calculate the total perimeter based on counts.
            return 4 * landCount - 2 * neighbourCount;

        }

        /// <summary>
        /// LeetCode problem 476 - Number Complement: https://leetcode.com/problems/number-complement/#/description
        /// Given a positive integer, output it's complement number. e.g. input 5 (101) == output 2 (010).
        /// </summary>
        /// <param name="inputNumber">Number to be flipped.</param>
        /// <returns>Complement number - integer equivalent of flipped bits.</returns>
        public static int FindComplementNumber(int inputNumber)
        {
            // Create mask which has N bits of '1', where N is leftmost bit of inputNumber
            // e.g. inputNumber = 5 == 101, therefore N = 3, and mask == 111
            int mask = 1;
            while (mask < inputNumber) mask = (mask << 1) | 1;
            // AND flipped input & mask:
            // e.g inputNumber = 5 == 101, mask = 7 == 111, therefore, return 11(lots of ones)010 & 111 = 010 == 2
            // i.e. the mask removes the leading 1's from the flipped input.
            return ~inputNumber & mask;
        }

        /// <summary>
        /// LeetCode problem 485 - Maximum Consecutive Ones: https://leetcode.com/problems/max-consecutive-ones/
        /// Given a binary array, return the largest number of consecutive '1' values in the array.
        /// e.g. { 1, 1, 0, 1, 1, 1 } => 3
        /// </summary>
        /// <param name="nums">Binary array.</param>
        /// <returns>Largest number of consecutive ones.</returns>
        public static int MaxConsecutiveOnes(int[] nums)
        {
            int max = 0, current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) current++;
                else current = 0;
                max = current > max ? current : max;
            }
            return max;
        }

        /// <summary>
        /// LeetCode problem 496 - Next Greater Element: https://leetcode.com/problems/next-greater-element-i/#/description
        /// </summary>
        /// <param name="findNums">Subset of unique numbers.</param>
        /// <param name="nums">Array of unique numbers.</param>
        /// <returns></returns>
        public static int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            int[] output = new int[findNums.Length];

            // For each integer in the subset:
            for (int i = 0; i < findNums.Length; i++)
            {
                // Set all values to -1 to start, will be changed later if needed.
                output[i] = -1;

                // Compare to every int in the set.
                for (int j = 0; j < nums.Length; j++)
                {
                    // Once we find the subset integer in the set:
                    if (nums[j] == findNums[i])
                    {
                        // Compare to every integer after this point:
                        for (int k = j; k < nums.Length; k++)
                        {
                            // Once we find a greater one, this is the output. Assign, and break back to the start.
                            if (nums[k] > findNums[i])
                            {
                                output[i] = nums[k];
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// LeetCode problem 521 - Longest Uncommon Subsequence I: https://leetcode.com/problems/longest-uncommon-subsequence-i/#/description
        /// Given 2 strings, return the length of the longest possible uncommon sub-sequence. i.e. the longest string that exists as a sub-string
        /// of one input, but not the other.
        /// </summary>
        /// <param name="x">Input String 1</param>
        /// <param name="y">Input String 2</param>
        /// <returns>Length of longest possible sub-sequence from the 2 input strings.</returns>
        public static int LongestUncommonSequence(string x, string y)
        {
            if (x == y) return -1;
            return Math.Max(x.Length, y.Length);
        }

        /// <summary>
        /// LeetCode problem 561 - Array Partition I: https://leetcode.com/problems/array-partition-i/#/description
        /// Separates a given array of 2n integers into n pairs, such that it produces the largest possible value for the sum of all minimum values of each pair.
        /// e.g. given (1,2,3,4), grouped as (1,2) and (3,4) means the sum of the minimum values == 1 + 3 = 4.
        /// </summary>
        /// <param name="nums">Array of 2n integers.</param>
        /// <returns>Largest possible value for the sum of minimum values for n pairs.</returns>
        public static int FindLargestSumOfMinValues(int[] nums)
        {
            // Method to be used is to sort all integers into ascending order, and group each number with the next largest.
            // e.g. (1,2,4,6,8,10) - 10 can never be a minimum value, so should be grouped with the next largest possible number (8).
            // This is so that the largest possible values are used in the sum. Use the same method on the remaining values.

            // Step 1 - Sort the input array
            int[] sortedNums = nums;
            Array.Sort(sortedNums);

            // Step 2 - Iterate through sorted array, summing every other value - i.e. taking the first of each 'pair'
            int sumOfMins = 0;
            for (int i = 0; i < sortedNums.Length; i += 2) sumOfMins += sortedNums[i];

            // Step 3 - Return the sum
            return sumOfMins;
        }

        /// <summary>
        /// LeetCode problem 566 - Reshape the Matrix: https://leetcode.com/problems/reshape-the-matrix/#/description
        /// Given a matrix of ints, return the same values in a re-shaped matrix.
        /// </summary>
        /// <param name="inputMatrix">Input multi-dimensional array of ints.</param>
        /// <param name="outputRows">Number of rows for the output array.</param>
        /// <param name="outputColumns">Number of columns for the output array.</param>
        /// <returns></returns>
        public static int[,] MatrixReshape(int[,] inputMatrix, int outputRows, int outputColumns)
        {
            // If it cannot be re-shaped as requested, return the original matrix.
            if (inputMatrix.Length != outputRows * outputColumns) return inputMatrix;

            // Create new matrix in the desired shape.
            int[,] outputMatrix = new int[outputRows, outputColumns];

            // Put original matrix into a new 1D array for ease of use.
            int[] inputArray = new int[inputMatrix.Length];

            for (int x = 0, i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++, x++) inputArray[x] = inputMatrix[i, j];
            }

            // Use new 1D array, and put values into the re-shaped matrix.
            for (int x = 0, i = 0; i < outputRows; i++)
            {
                for (int j = 0; j < outputColumns; j++, x++) outputMatrix[i, j] = inputArray[x];
            }

            return outputMatrix;
        }

        /// <summary>
        /// LeetCode problem 575 - Distribute Candies: https://leetcode.com/problems/distribute-candies/#/description
        /// Given an array of 'candies' represented by integers (each unique int represents a unique type of candy),
        /// and if the candies are to be distributed equally between brother and sister then return the maximum number
        /// of unique candies that either the brother or sister can get from the set of candies.
        /// </summary>
        /// <param name="candies">Array of 'candies', where different int values represent unique types of candy.</param>
        /// <returns>Maximum number of unique candies that be contained in an array half the size of the input.</returns>
        public static int DistributeCandies(int[] candies)
        {
            HashSet<int> uniqueCandies = new HashSet<int>();

            // Add every unique type of candy into the set.
            foreach (int i in candies) if (!uniqueCandies.Contains(i)) uniqueCandies.Add(i);

            // Sister gets half of all candies - if less than half are unique, then the max unique to be gained is the total unique.
            if (uniqueCandies.Count < candies.Length / 2) return uniqueCandies.Count;
            else { return candies.Length / 2; } // If more than half are unique, max unique to be gained is half the total.
        }
    }
}
