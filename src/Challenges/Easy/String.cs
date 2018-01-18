using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    public class String
    {
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
    }
}
