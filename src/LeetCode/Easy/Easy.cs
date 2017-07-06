using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode
{
    /// <summary>
    /// Methods used to solve the 'Easy' algorithm problems on LeetCode: https://leetcode.com/problemset/algorithms/?difficulty=Easy 
    /// TO DO: Split into files by category, e.g. strings, maths, etc.
    /// </summary>
    public class Easy
    {
        /// <summary>
        /// LeetCode problem 104 - Maximum Depth of Binary Tree: https://leetcode.com/problems/maximum-depth-of-binary-tree/#/description
        /// </summary>
        /// <param name="root">Root TreeNode</param>
        /// <returns>Maximum depth of the Tree</returns>
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0; // If null tree, 0 depth.
            if (root.left==null && root.right==null) return 1; // If both connected nodes are null, depth of 1.

            // If non-null connected nodes, depth = deepest connected node + this node
            else if (root.left == null) return MaxDepth(root.right) + 1; 
            else if (root.right == null) return MaxDepth(root.left) + 1;
            else return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        /// <summary>
        /// LeetCode problem 344 - Reverse String: https://leetcode.com/submissions/detail/76241460/
        /// Take a string, and reverse it, without changing cases.
        /// </summary>
        /// <param name="input">String to be reversed.</param>
        /// <returns>Reversed string.</returns>
        public static string ReverseString(string input)
        {
            // Holder string.
            string output = "";
            // Start from the final letter in the string and put into new string.
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        /// <summary>
        /// LeetCode problem 412 - FizzBuzz: https://leetcode.com/problems/fizz-buzz/
        /// Output a list of strings from 1 to N, where any number divisible by 3 is Fizz, by 5 is Buzz, by both is FizzBuzz.
        /// All other numbers should be unchanged. Uses <see cref="SingleFizzBuzz(int)"/>
        /// </summary>
        /// <param name="input">N - number of strings in the returned list.</param>
        /// <returns>List of N strings, representing each number from 1 to N.</returns>
        public static List<string> FizzBuzz(int input)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= input; i++) result.Add(SingleFizzBuzz(i));
            return result;
        }

        /// <summary>
        /// LeetCode problem 412 - FizzBuzz <see cref="FizzBuzz(int)"/>
        /// </summary>
        /// <param name="input">Integer to be FizzBuzzed.</param>
        /// <returns>String of FizzBuzzed int.</returns>
        public static string SingleFizzBuzz(int input)
        {
            string temp = "";
            if (input % 3 == 0) temp += "Fizz";
            if (input % 5 == 0) temp += "Buzz";
            else if (input % 3 != 0) return input.ToString();
            return temp;            
        }

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
        /// LeetCode problem 500 - Keyboard Row: https://leetcode.com/problems/keyboard-row/#/description
        /// Given a list of words, determine which can be typed using a single row of characters on a standard keyboard.
        /// </summary>
        /// <param name="words">Words to be tested.</param>
        /// <returns>Words which can be typed using a single keyboard row.</returns>
        public static string[] FindWordsInKeyboardLines(string[] words)
        {
            List<string> result = new List<string>();

            // Set up each row of the keyboard (lower case), and put into list.
            HashSet<char> FirstLine = new HashSet<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            HashSet<char> SecondLine = new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            HashSet<char> ThirdLine = new HashSet<char> { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            List<HashSet<char>> KeyboardLines = new List<HashSet<char>> { FirstLine, SecondLine, ThirdLine };

            // Go through each word given, and compare against each Keyboard Row.
            foreach (string word in words)
            {
                foreach (HashSet<char> line in KeyboardLines)
                {
                    if (CanMakeWordFromChars(word.ToLower(), line)) // Make sure to submit words in lower case.
                    {
                        result.Add(word);
                        break;
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Check is a word consists of characters only from a given collection (case sensitive).
        /// </summary>
        /// <param name="word">Word to be checked.</param>
        /// <param name="charSet">Collection of letters to be checked against.</param>
        /// <returns></returns>
        public static bool CanMakeWordFromChars(string word, ICollection<char> charSet)
        {
            foreach (char c in word)
            {
                if (!charSet.Contains(c)) return false;
            }
            return true;
        }

        /// <summary>
        /// LeetCode problem 520 - Detect Capital
        /// Given an input word, determine if it uses capitalisation correctly. i.e all lower, all upper, or first letter upper only.
        /// </summary>
        /// <param name="word">Word to be tested.</param>
        /// <returns>True if word uses capitals correctly.</returns>
        public static bool DetectCapitalUse(string word)
        {
            if (word.ToLower() == word || word.ToUpper() == word) return true;
            if (char.IsUpper(word[0]) && word.Substring(1) == word.Substring(1).ToLower()) return true;
            return false;
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
        /// LeetCode problem 557 - Reverse Words in a String III: https://leetcode.com/problems/reverse-words-in-a-string-iii/#/description
        /// Reverse each word from an input string, preserving whitespace, order of words, and casing.
        /// </summary>
        /// <param name="input">String of words</param>
        /// <returns>String of reversed words</returns>
        public static string ReverseWordsInString(string input)
        {
            // Create char array of same size as the input string.
            char[] outputArray = new char[input.Length];

            // Starting index for the first word.
            int startOfWordIndex = 0;

            // Loop along the entire string.
            for (int endOfWordIndex = 0; endOfWordIndex < input.Length; endOfWordIndex++)
            {
                // If J is a spacewe want to put the previous word into the array, in reverse.
                if (input[endOfWordIndex] == ' ')
                {
                    outputArray[endOfWordIndex] = ' ';
                    // Iterate from the start of the word, to the end of the word (space / end of line).
                    for (int i = startOfWordIndex; i < endOfWordIndex; i++)
                    {
                        // first letter at the start is assigned as the last letter of the word
                        outputArray[i] = input[endOfWordIndex + startOfWordIndex - i - 1];
                    }
                    startOfWordIndex = endOfWordIndex + 1;
                }

                // If we're at the end of the string
                if (endOfWordIndex == input.Length - 1)
                {
                    // Iterate from the start of the word, to the end of the word (space / end of line).
                    for (int i = startOfWordIndex; i <= endOfWordIndex; i++)
                    {
                        // first letter at the start is assigned as the last letter of the word
                        outputArray[i] = input[endOfWordIndex + startOfWordIndex - i];
                    }
                    startOfWordIndex = endOfWordIndex + 1;
                }
            }

            return new string(outputArray);
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

        /// <summary>
        /// LeetCode problem 606 - Construct string from binary tree: https://leetcode.com/problems/construct-string-from-binary-tree/#/description
        /// </summary>
        /// <param name="t">Binary tree.</param>
        /// <returns>String representation of the tree.</returns>
        public string Tree2str(TreeNode t)
        {
            if (t == null) return "";

            // Add node value to string to start with.
            string output = t.val.ToString(), left = "", right = "";

            // Right hand node, include blank parens if left is null.
            if (t.right != null)
            {
                right = "(" + Tree2str(t.right) + ")";
                if (t.left == null) left = "()";
            }

            // Left hand node.
            if (t.left != null) left = "(" + Tree2str(t.left) + ")";

            // Combine!
            return output + left + right;
        }

        /// <summary>
        /// LeetCode problem 617 - Merge Two Binary Trees: https://leetcode.com/problems/merge-two-binary-trees/#/description
        /// Merge 2 binary trees - i.e. if values overlap, add them together, if one is null, take the other value, if both null, null.
        /// </summary>
        /// <param name="t1">First binary tree</param>
        /// <param name="t2">Second binary tree</param>
        /// <returns>Merged result of 2 input trees</returns>
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            // If both are null, end of the tree for this node.
            if (t1 == null && t2 == null) return null;

            // If not, create new node, combining the 2 input values (either could be null).
            TreeNode Final = new TreeNode((t1 != null ? t1.val : 0) + (t2 != null ? t2.val : 0));

            // Create the 2 subsequent nodes from the new tree Final with recursion. Will end when both null.
            Final.left = MergeTrees(t1 != null ? t1.left : null, t2 != null ? t2.left : null);
            Final.right = MergeTrees(t1 != null ? t1.right : null, t2 != null ? t2.right : null);

            return Final;
        }
    }

}