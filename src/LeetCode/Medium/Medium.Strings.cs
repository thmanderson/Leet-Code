using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Track the chars used to make a substring
            HashSet<char> usedChars = new HashSet<char>();
            int result = 0, temp = 0;

            foreach (char c in s)
            {
                if (usedChars.Contains(c))
                {
                    if (temp > result) result = temp;
                    usedChars.Clear();
                    usedChars.Add(c);
                    temp = 1;
                }
                else
                {
                    temp++;
                    usedChars.Add(c);
                }

                if (temp > result) result = temp;
            }            

            return result;
        }
    }
}
