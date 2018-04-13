using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class String
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
            if (s == ReverseString(s)) return s;
            string result = "";

            // Iterate through the string, where i is the starting point of the substring.
            for (int i = 0; i < s.Length; i++)
            {
                // Start with the largest possible substring that starts from s[i]:
                for (int j = s.Length - 1; j >= i; j--)
                {
                    // If the substring is a palindrome, and longer than current best - return it.
                    string temp = s.Substring(i, j + 1 - i);
                    if (ReverseString(temp) == temp && temp.Length > result.Length) result = temp;
                }
                if (result.Length > s.Length - i) return result;
            }
            return result;
        }

        /// <summary>
        /// LeetCode problem 6 - ZigZag Conversion: https://leetcode.com/problems/zigzag-conversion/#/description
        /// </summary>
        /// <param name="s">String to be ZigZag-ified.</param>
        /// <param name="rows">Number of rows to be split into.</param>
        /// <returns>ZigZag-ified string read row by row.</returns>
        public static string ZigZagConvert(string s, int rows)
        {
            if (rows == 1 || s.Length < rows) return s;
            string result = "";
            int total = (rows - 1) * 2;

            for (int x = 0; x < rows; x++)
            {
                // Set initial gap
                int GapToNextChar = (rows - 1 - x) * 2;

                // Last number in the column
                if (GapToNextChar == 0) GapToNextChar = (rows - 1) * 2;

                //// Grab all letters in the row
                for (int i = x; i < s.Length; i += GapToNextChar)
                {
                    result += s[i];

                    // Gap alternates between two numbers as you go
                    bool zag = ((i / (rows - 1)) % 2 == 0);
                    // if (i % (2 * rows) > rows || i % (2 * rows) == 0) GapToNextChar = total - (rows - 1 - x) * 2;
                    if (zag) GapToNextChar = (rows - 1 - x) * 2;
                    else GapToNextChar = total - (rows - 1 - x) * 2;

                    if (GapToNextChar == 0) GapToNextChar = (rows - 1) * 2;
                }
            }

            return result;
        }

        /// <summary>
        /// Take a string, and reverse it, without changing cases.
        /// LeetCode problem 344 - Reverse String: https://leetcode.com/submissions/detail/76241460/
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
        /// Output a list of strings from 1 to N, where any number divisible by 3 is Fizz, by 5 is Buzz, by both is FizzBuzz.
        /// All other numbers should be unchanged. Uses <see cref="SingleFizzBuzz(int)"/>
        /// LeetCode problem 412 - FizzBuzz: https://leetcode.com/problems/fizz-buzz/
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
        /// Given a list of words, determine which can be typed using a single row of characters on a standard keyboard.
        /// LeetCode problem 500 - Keyboard Row: https://leetcode.com/problems/keyboard-row/#/description
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
        /// Reverse each word from an input string, preserving whitespace, order of words, and casing.
        /// LeetCode problem 557 - Reverse Words in a String III: https://leetcode.com/problems/reverse-words-in-a-string-iii/#/description
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
        /// LeetCode Problem 771 - Jewels and Stones: https://leetcode.com/problems/jewels-and-stones/description/
        /// Given a list of stones, and a list of which stones are jewels, count how many jewels you have (case sensitive).
        /// </summary>
        /// <param name="J">List of Jewels, each character is distinct, and represents a type of Jewel (case sensitive).</param>
        /// <param name="S">List of stones. Not necessarily distinct, not all jewels.</param>
        /// <returns></returns>
        public static int NumJewelsInStones(string J, string S)
        {
            var Jewels = new HashSet<char>();
            int result = 0;
            foreach (char jewel in J)
            {
                Jewels.Add(jewel);
            }
            foreach (char stone in S)
            {
                if (Jewels.Contains(stone)) result++;
            }
            return result;
        }

        /// <summary>
        /// In morse code some words can look identical. Finds the number of unique morse code representations for a set of words.
        /// LeetCode Problem 804 - https://leetcode.com/problems/unique-morse-code-words/description/
        /// </summary>
        /// <param name="words">Words to be analyzed.</param>
        /// <returns>Number of unique representations.</returns>
        public static int UniqueMorseRepresentations(string[] words)
        {
            string[] morseCodeLetters = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            var uniqueWords = new HashSet<string>();

            foreach (string word in words)
            {
                string morseCodeWord = "";
                foreach (char c in word)
                {
                    morseCodeWord += morseCodeLetters[char.ToUpper(c) - 65];
                }
                uniqueWords.Add(morseCodeWord);
            }

            return uniqueWords.Count;
        }

        /// <summary>
        /// LeetCode Problem 811 - https://leetcode.com/problems/subdomain-visit-count/description/
        /// </summary>
        public IList<string> SubdomainCount(string[] cpDomains)
        {
            var result = new List<string>();
            var totals = new Dictionary<string, int>();

            foreach (string cpDomain in cpDomains)
            {
                int count = Convert.ToInt32(cpDomain.Split(' ')[0]);
                string domain = cpDomain.Split(' ')[1];
                while (domain.Split('.')[0] != domain)
                {
                    if (totals.ContainsKey(domain)) totals[domain] += count;
                    else totals.Add(domain, count);
                    domain = domain.Substring(domain.IndexOf('.') + 1);
                }
                if (totals.ContainsKey(domain)) totals[domain] += count;
                else totals.Add(domain, count);
            }

            foreach (var d in totals)
            {
                result.Add(d.Value + " " + d.Key);
            }

            return result;
        }
    }
}
