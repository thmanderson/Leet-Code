using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Medium
{
    /// <summary>
    /// Methods used to solve the string based 'Medium' algorithm problems on LeetCode: https://leetcode.com/problemset/algorithms/?difficulty=Medium 
    /// </summary>
    public class Strings
    {
        /// <summary>
        /// LeetCode problem 3 - Longest Substring Without Repeating Characters: https://leetcode.com/problems/longest-substring-without-repeating-characters/#/description
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>Length of longest possible substring of s with no repeating characters.</returns>
        public static int LengthOfLongestSubstring(string s)
        {
            // Track the chars used to make a substring in the HashSet.
            HashSet<char> usedChars = new HashSet<char>();
            int result = 0, n = s.Length, i = 0, j = 0;

            // Create a "sliding window", substring (i,j). Extend as much as possible to the right, if it fails, shrink from the left.
            while (i < n && j < n)
            {
                // First, check s[j]
                if (!usedChars.Contains(s[j]))
                {
                    // If this isn't a duplicate, extend the window to the right, and add to the HashSet.
                    usedChars.Add(s[j]);
                    j++;
                    result = Math.Max(result, j - i); // Keeps track of the largest sub-string we've seen so far.
                }

                else
                {
                    // If s[j] is a duplicate, reduce the window from the left, and try again.
                    usedChars.Remove(s[i]);
                    i++;
                }
            }

            return result;
        }

        /// <summary>
        /// LeetCode problem 5 - Longest Palindromic Substring: https://leetcode.com/problems/longest-palindromic-substring/#/description
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>The longest palindromic substring of input s.</returns>
        public static string LongestPalindrome(string s)
        {
            /******************************************************
            // Attempt 1: Seems to work but too slow for Leetcode:
            ******************************************************/

            // Check if whole input string is a palindrome
            if (s == Easy.ReverseString(s)) return s;
            string result = "";

            // Iterate through the string, where i is the starting point of the substring.
            for (int i = 0; i < s.Length; i++)
            {
                // Start with the largest possible substring that starts from s[i]:
                for (int j = s.Length - 1; j >= i; j--)
                {
                    // If the substring is a palindrome, and longer than current best - return it.
                    string temp = s.Substring(i, j + 1 - i);
                    if (Easy.ReverseString(temp) == temp && temp.Length > result.Length) result = temp;
                }
                if (result.Length > s.Length - i) return result;
            }
            return result;
        }
    }
}
