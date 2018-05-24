using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.Model;

namespace LeetCode
{
    public static class Maths
    {

        /// <summary>
        /// Given 2 <see cref="ListNode"/>s representing 2 integers in reverse, return the two numbers added together as another ListNode.
        /// e.g. 2 -> 4 -> 3 == 342.
        /// LeetCode problem 2 - Add Two Numbers: https://leetcode.com/problems/add-two-numbers/#/description
        /// </summary>
        /// <param name="l1">First number starting with smallest value e.g. 2 -> 4 -> 3 == 342.</param>
        /// <param name="l2">Second number starting with smallest value e.g. 2 -> 4 -> 3 == 342.</param>
        /// <returns>Sum of <paramref name="l1"/> and <paramref name="l2"/> starting with smallest value e.g. 2 -> 4 -> 3 == 342.</returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result;

            if (l1 == null)
            {
                if (l2 == null) return null;
                else return l2;
            }
            else if (l2 == null) return l1;

            // L1 and L2 are the smallest numbers in a sequence.
            // e.g if L1 == 2, and links to another ListNode 1, which doesn't link to anything else, this represents the number 12.

            // Add up this node:
            int value = l1.val + l2.val;

            // If an extra 1 needs to be carried to the next sum:
            int carry = 0;
            if (value > 9) { carry = 1; value -= 10; }

            result = new ListNode(value);
            result.next = AddTwoNumbers(l1.next, l2.next);
            if (result.next == null && carry != 0) result.next = new ListNode(carry);
            else if (result.next != null) result.next = AddTwoNumbers(result.next, new ListNode(carry));
            return result;
        }

        /// <summary>
        /// Reverses an integer, e.g. 123 => 321, -321 => -123, 120 => 21.
        /// LeetCode problem 7 - Reverse Integer: https://leetcode.com/problems/reverse-integer/
        /// </summary>
        /// <param name="x">Integer to be reversed</param>
        /// <returns>Reversed integer. 0 for overflow.</returns>
        public static int Reverse(int x)
        {
            if (x == Int32.MinValue || x == Int32.MaxValue) return 0;

            int result;
            int xAbs = Math.Abs(x);

            var xReversed = String.ReverseString(Convert.ToString(xAbs));
            try
            {
                result = Convert.ToInt32(xReversed);
            }
            catch
            {
                result = 0;
            }
            result = x >= 0 ? result : -result;
            return result;
        }

        /// <summary>
        /// Finds out if an integer is a palindrome.
        /// LeetCode problem 9 - https://leetcode.com/problems/palindrome-number/description/
        /// </summary>
        /// <param name="input">Input integer.</param>
        /// <returns>True if number is a palindrome.</returns>
        public static bool IsPalindrome(int input)
        {
            if (input < 0) return false;
            if (input == 0) return true;
            if (input == Reverse(input)) return true;
            else return false;
        }

        /// <summary>
        /// Converts a roman numeral string into an integer.
        /// LeetCode problem 13 - https://leetcode.com/problems/roman-to-integer/description/
        /// </summary>
        /// <param name="s">Roman numeral</param>
        /// <returns>Integer value of input</returns>
        public static int RomanToInt(string s)
        {
            var RomanNumeralValues = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
            int result = 0;
            
            for (int i = 0; i < s.Length - 1; i++)
            {
                int current = RomanNumeralValues[s[i]];
                int next = RomanNumeralValues[s[i + 1]];

                if (current < next) result -= current;
                else result += current;
            }

            result += RomanNumeralValues[s[s.Length - 1]];

            return result;
        }

        /// <summary>
        /// Merge 2 sorted lists into 1 sorted list. <seealso cref="ListNode"/>
        /// LeetCode problem 20 - Merge Two Sorted Lists: https://leetcode.com/problems/merge-two-sorted-lists/description/
        /// </summary>
        /// <param name="l1">First sorted list.</param>
        /// <param name="l2">Second sorted list.</param>
        /// <returns>Merged sorted list.</returns>
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);

            if (l1 == null)
            {
                if (l2 == null) return null;
                else
                {
                    result.val = l2.val;
                    result.next = MergeTwoLists(null, l2.next);
                }
            }
            else if (l2 == null)
            {
                result.val = l1.val;
                result.next = MergeTwoLists(l1.next, null);
            }
            else
            {
                if (l1.val > l2.val)
                {
                    result.val = l2.val;
                    result.next = MergeTwoLists(l1, l2.next);
                }
                else
                {
                    result.val = l1.val;
                    result.next = MergeTwoLists(l1.next, l2);
                }
            }
            return result;
        }

        /// <summary>
        /// Given an array of sorted integers, modify the existing array in place, and return the new length so there are no duplicates.
        /// LeetCode problem 26 - Remove Duplicates from Sorted Array: https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
        /// </summary>
        /// <param name="nums">Array of ints.</param>
        /// <returns>Length of de-duped sorted array.</returns>
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return nums.Length;

            int prev = nums[0];
            int toReplace = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == prev)
                {
                    if (toReplace == 0) toReplace = i;
                }
                else
                {
                    if (toReplace != 0) nums[toReplace] = nums[i];
                    toReplace++;
                }
                prev = nums[i];
            }
            return toReplace;
        }

        /// <summary>
        /// Move all zeroes in an array to the end of the array.
        /// </summary>
        /// <param name="nums">Input array.</param>
        public static void MoveZeroes(int[] nums)
        {
            bool firstZeroFound = false;
            int toReplace = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!firstZeroFound)
                {
                    if (nums[i] == 0)
                    {
                        toReplace = i;
                        firstZeroFound = true;
                    }
                }
                else
                {
                    if (nums[i] == 0) continue;
                    int tmp = nums[toReplace];
                    nums[toReplace] = nums[i];
                    nums[i] = tmp;
                    toReplace++;
                }
            }
        }

        /// <summary>
        /// Returns the maximum sum of a subarray of a given array of integers.
        /// LeetCode problem 53: https://leetcode.com/problems/maximum-subarray/description/
        /// </summary>
        /// <param name="nums">Array of integers.</param>
        /// <returns>The maximum sum of a sub-array within the input array.</returns>
        public static int MaxSubArray(int[] nums)
        {
            int runningTotal = 0, maximumTotal = Int32.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maximumTotal) maximumTotal = nums[i];
                runningTotal += nums[i];
                if (runningTotal > maximumTotal) maximumTotal = runningTotal;
                if (runningTotal < 0) runningTotal = 0;
            }

            return maximumTotal;
        }

        /// <summary>
        /// Given an array describing a queue of people [h,k] (not in the correct order), where h is the height of the person, and
        /// k is the number of people in front of them who are either taller, or of the same height, return the array in the correct order.
        /// LeetCode problem 406: https://leetcode.com/problems/queue-reconstruction-by-height/description/
        /// </summary>
        /// <param name="people">Multidimensional unordered array of people [h,k].</param>
        /// <returns>Re-ordered array, in the actual order of the queue, determined using h and k.</returns>
        public static int[,] ReconstructQueue(int[,] people)
        {
            // Convert to Jagged Array so I can use LINQ.
            var jaggedPeople = new int[people.Length / people.Rank][];
            var jaggedReconstructed = new int[people.Length / people.Rank][];
            
            for (int i = 0; i < people.Length / people.Rank; i++)
            {
                jaggedPeople[i] = new int[people.Rank];
                for (int j = 0; j < people.Rank; j++)
                {
                    jaggedPeople[i][j] = people[i, j];
                }
            }

            // Get an ordered list of all the people (by height).
            var orderedPeople = jaggedPeople.OrderBy(x => x[0]).ThenBy(x => x[1]);

            // For an ordered list of people, we know that any empty space, or space occupied by someone of the same height, there will be someone who counts towards their number K.
            // e.g. for someone [5,2], iterate through the new list, and empty space, or space occupied by someone of height 5 will count towards k (2), as they must be the same height
            // or taller if they haven't been added to the queue yet. Count the number of these spaces found, and when it equals k, put this person here in the list.
            // If this space isn't empty, it must be by someone shorter, so won't affect K - so just add to the next empty space.
            // This means we count how many spaces are occupied by people of the same height

            // For the next shortest person in the list
            foreach (var person in orderedPeople)
            {
                // Go through the reconstructed queue
                for (int i = 0, empty = 0; i < jaggedReconstructed.Length; i++)
                {
                    // If it's null, it's a possible space.
                    if (jaggedReconstructed[i] == null)
                    {
                        // If the number of spaces that were either empty, or occupied by someone of the same height, this is our spot
                        if (empty >= person[1])
                        {
                            jaggedReconstructed[i] = person;
                            break;
                        }
                        // If not, we keep going until the next empty spot
                        empty++;
                    }
                    // If a spot is occupied by someone of the same height
                    else if (jaggedReconstructed[i][0] == person[0]) empty++;
                }
            }
            
            // Convert back to multi-dimensional
            var reconstructed = new int[people.Length / people.Rank, 2];
            for (int i = 0; i < reconstructed.Length / reconstructed.Rank; i++)
            {
                for (int j = 0; j < reconstructed.Rank; j++)
                {
                    reconstructed[i, j] = jaggedReconstructed[i][j];
                }
            }
            return reconstructed;
        }

        /// <summary>
        /// LeetCode problem 442: https://leetcode.com/problems/find-all-duplicates-in-an-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++) // Mark the number with index nums[i] as negative, anything already marked negative is at a duplicate index.
            {
                if (nums[Math.Abs(nums[i]) - 1] < 0) result.Add(Math.Abs(nums[i]));
                nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
            }
            return result;
        }


        /// <summary>
        /// Returns the hamming distance (https://en.wikipedia.org/wiki/Hamming_distance) between 2 integers.
        /// LeetCode problem 461 - Hamming Distance: https://leetcode.com/problems/hamming-distance/#/description
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
        /// Given a 2D rectangular binary "map", where 1 == land and 0 == water, calculate the perimter of the island depicted.
        /// Assume no diagonal connections between land, and no 'lakes' in the island.
        /// LeetCode problem 463 - Island Perimeter: https://leetcode.com/problems/island-perimeter/#/description
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
        /// Given a positive integer, output it's complement number. e.g. input 5 (101) == output 2 (010).
        /// LeetCode problem 476 - Number Complement: https://leetcode.com/problems/number-complement/#/description
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
                // max = current > max ? current : max;
                max = Math.Max(current, max);
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
        /// Given 2 strings, return the length of the longest possible uncommon sub-sequence. i.e. the longest string that exists as a sub-string
        /// of one input, but not the other.
        /// LeetCode problem 521 - Longest Uncommon Subsequence I: https://leetcode.com/problems/longest-uncommon-subsequence-i/#/description
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
        /// Calculate the product of 2 complex numbers.
        /// LeetCode problem 537 - Complex Number Manipulation: https://leetcode.com/problems/complex-number-multiplication/#/description
        /// </summary>
        /// <param name="a">Complex number A in format of "x + yi" where x and y are both integers.</param>
        /// <param name="b">Complex number B in format of "x + yi" where x and y are both integers.</param>
        /// <returns>Complex number A*B in format of "x + yi" where x and y are both integers.</returns>
        public static string ComplexNumberMultiply(string a, string b)
        {
            // Split string into real and imaginary components.
            string[] leftStrings = a.Split('+');
            string[] rightStrings = b.Split('+');

            // Convert strings into integers:
            int leftReal = Convert.ToInt32(leftStrings[0]);
            int leftImaginary = Convert.ToInt32(leftStrings[1].TrimEnd('i'));
            int rightReal = Convert.ToInt32(rightStrings[0]);
            int rightImaginary = Convert.ToInt32(rightStrings[1].TrimEnd('i'));

            // Final real number:
            int finalReal = (leftReal * rightReal) - (leftImaginary * rightImaginary);
            // Final imaginary number:
            int finalImaginary = (leftReal * rightImaginary) + (leftImaginary * rightReal);

            return (finalReal.ToString() + "+" + finalImaginary.ToString() + "i");
        }

        /// <summary>
        /// Separates a given array of 2n integers into n pairs, such that it produces the largest possible value for the sum of all minimum values of each pair.
        /// e.g. given (1,2,3,4), grouped as (1,2) and (3,4) means the sum of the minimum values == 1 + 3 = 4.
        /// LeetCode problem 561 - Array Partition I: https://leetcode.com/problems/array-partition-i/#/description
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
        /// Given a matrix of ints, return the same values in a re-shaped matrix.
        /// LeetCode problem 566 - Reshape the Matrix: https://leetcode.com/problems/reshape-the-matrix/#/description
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
        /// Given an array of 'candies' represented by integers (each unique int represents a unique type of candy),
        /// and if the candies are to be distributed equally between brother and sister then return the maximum number
        /// of unique candies that either the brother or sister can get from the set of candies.
        /// LeetCode problem 575 - Distribute Candies: https://leetcode.com/problems/distribute-candies/#/description
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

        /// <summary>
        /// Determines if a number of flowers can be added to a flowerbed. A flower cannot be planted if there are any adjacent flowers.
        /// LeetCode problem 605: https://leetcode.com/problems/can-place-flowers/
        /// </summary>
        /// <param name="flowerbed">Binary array representing a flower bed, 1 = plant already there, 0 = empty space in the bed.</param>
        /// <param name="n">Number of flowers to determine if they can be planted.</param>
        /// <returns>True if the bed can accomodate n flowers, false if not.</returns>
        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (flowerbed.Length == 1)
            {
                if (flowerbed[0] == 0 && n <= 1) return true;
                if (flowerbed[0] == 1 && n == 0) return true;
                return false;
            }

            int spaces = 0;

            if (flowerbed[0] == 0 && flowerbed[1] == 0)
            {
                spaces++;
                flowerbed[0] = 1;
            }

            for (int i = 1; i < flowerbed.Length - 1; i++)
            {
                if (flowerbed[i - 1] == 0 && flowerbed[i] == 0 && flowerbed[i+1] == 0)
                {
                    spaces++;
                    flowerbed[i] = 1;
                }
            }

            if (flowerbed[flowerbed.Length - 1] == 0 && flowerbed[flowerbed.Length - 2] == 0) spaces++;

            if (n <= spaces) return true;
            else return false;
        }

        /// <summary>
        /// Find out of a given set of moves result in starting and finishing in the same place.
        /// LeetCode problem 657 - Judge Route Circuit: https://leetcode.com/problems/judge-route-circle/
        /// </summary>
        /// <param name="moves">String of characters, each representing a move, e.g. U == Up, L == Left, etc. Any characters other than U, D, L, or R are ignored.</param>
        /// <returns>True if all the moves add up to no net movement.</returns>
        public static bool JudgeCircle(string moves)
        {
            int up = 0, across = 0;
            foreach (char c in moves)
            {
                if (c == 'U') up++;
                if (c == 'D') up--;
                if (c == 'L') across++;
                if (c == 'R') across--;
            }
            return (up == 0 && across == 0);
        }

        /// <summary>
        /// Returns a list of Self Dividing numbers between the lower and upper limit provided. Self dividing
        /// here means is divisible by each of the digits in the integer.
        /// LeetCode problem 728 - Self Dividing Numbers: https://leetcode.com/problems/self-dividing-numbers
        /// </summary>
        /// <param name="lowerLimit">Lower limit.</param>
        /// <param name="upperLimit">Upper limit.</param>
        /// <returns>List of self-divisible integers.</returns>
        public static IList<int> SelfDividingNumbers(int lowerLimit, int upperLimit)
        {
            var result = new List<int>();
            for (int i = lowerLimit; i <= upperLimit; i++)
            {
                var intString = Convert.ToString(i);
                bool SelfDividing = true;
                foreach (char c in intString)
                {
                    var charInt = (int)Char.GetNumericValue(c);
                    if (charInt == 0) SelfDividing = false;
                    else if (i % charInt != 0) SelfDividing = false;
                }
                if (SelfDividing) result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// Count of numbers in range L to R (inclusive) that have a prime number of bits set.
        /// LeetCode problem 762: https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/description/            
        /// </summary>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        public static int CountPrimeSetBits(int L, int R)
        {
            var primes = new HashSet<int> { 2, 3, 5, 7, 11, 13, 17, 19 };
            int result = 0;
            
            for (int i = L; i <= R; i++)
            {
                var binary = Convert.ToString(i, 2);
                // Rather than use IsPrime, because we know R.Max is 10^6, maximum number of bits is 21, so we can use a specific subset of primes.
                var bits = binary.Count(x => x == '1');
                if (primes.Contains(bits)) result++;
            }
            
            return result;
        }

        /// <summary>
        /// Calculates if a given integer is a prime number.
        /// </summary>
        /// <param name="input">An integer</param>
        /// <returns>True if the integer is a prime number</returns>
        public static bool IsPrime(int input)
        {
            if (input == 0 || input == 1) return false;
            if (input == 2) return true;
            if (input % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(input));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (input % i == 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Find the maximum increase in height that can be made to a 'city', without altering the skyline.
        /// This means increasing all buildings without making them taller than the tallest in both their row and column.
        /// LeetCode problem 807 - https://leetcode.com/problems/max-increase-to-keep-city-skyline/
        /// </summary>
        /// <param name="grid">Rectangular grid representing buildings in a city, and their relative heights.</param>
        /// <returns>Total maximum increase that can be made across all buildings in the grid.</returns>
        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            var topView = new int[grid.Length];
            var sideView = new int[grid.Length];
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                sideView[i] = grid[i].Max();
                int largestVertical = 0;
                for (int j = 0; j < grid.Length; j++)
                {
                    largestVertical = Math.Max(grid[j][i], largestVertical);
                }
                topView[i] = largestVertical;
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    var currentHeight = grid[i][j];
                    var difference = Math.Min(sideView[i], topView[j]) - currentHeight;
                    if (difference > 0) result += difference;
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the distance from each position in a string to the nearest instance of a specific character.
        /// LeetCode problem 821 - https://leetcode.com/problems/shortest-distance-to-a-character/description/
        /// </summary>
        /// <param name="S">Input string</param>
        /// <param name="C">Character to find distance to</param>
        /// <returns>Array of distances to char C</returns>
        public static int[] ShortestToChar(string S, char C)
        {
            var result = new int[S.Length];

            for (int i = 0; i < S.Length; i++)
            {
                int toNextChar = Math.Abs(((S.IndexOf(C, i) != -1) ? S.IndexOf(C, i) : S.Length + i) - i);
                int toPrevChar = Math.Abs(((S.LastIndexOf(C, i) != -1) ? S.LastIndexOf(C, i) : S.Length + i) - i);
                result[i] = Math.Min(toNextChar, toPrevChar);
            }

            return result;
        }
        
        public static int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            // Attempt 1: Too slow for LeetCode
            int result = 0;

            var jobs = new List<Tuple<int, int>>();
            for (int i = 0; i < difficulty.Length; i++) jobs.Add(new Tuple<int, int>(difficulty[i], profit[i]));
            jobs = jobs.OrderByDescending(x => x.Item2).ToList();
            
            foreach (var w in worker)
            {
                result += jobs.FirstOrDefault(x => x.Item1 <= w) != null ? jobs.FirstOrDefault(x => x.Item1 <= w).Item2 : 0;
            }

            return result;
        }

        /// <summary>
        /// LeetCode problem 829: https://leetcode.com/problems/consecutive-numbers-sum/description/
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int ConsecutiveNumbersSum(int N)
        {
            int result = 1;

            int limit = N + 1 / 2;

            for (int i = 1; i < limit; i++)
            {
                int sum = 0;
                for (int j = i; j < limit; j++)
                {
                    sum += j;
                    if (sum == N) result++;
                    if (sum >= N) break;
                }
            }

            return result;
        }

        /// <summary>
        /// LeetCode problem 832: https://leetcode.com/problems/flipping-an-image/description/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[][] FlipAndInvertImage(int[][] A)
        {
            var result = new int[A.Length][];

            for (int i = 0; i < A.Length; i++)
            {
                result[i] = new int[A[i].Length];
                for (int j = 0; j < A[i].Length; j++)
                {
                    var opposite = A[i][A[j].Length - (j + 1)];
                    result[i][j] = opposite == 1 ? 0 : 1;
                }
            }

            return result;
        }

        /// <summary>
        /// LeetCode problem 836: https://leetcode.com/problems/rectangle-overlap/description/
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <returns></returns>
        public static bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            if (rec2[0] >= rec1[2] ||
                rec2[1] >= rec1[3] ||
                rec1[0] >= rec2[2] ||
                rec1[1] >= rec2[3]) return false;

            return true;
        }
    }
}
