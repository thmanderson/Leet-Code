using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayFour
    {
        public static bool IsPassphraseValid(string passphrase)
        {
            string[] words = passphrase.Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                var x = words[i];
                for (int j = i + 1; j < words.Length; j++)
                {
                    var y = words[j];
                    if (x == y) return false;
                }
            }
            return true;
        }

        public static bool IsPassphraseValidComplex(string passphrase)
        {
            string[] words = passphrase.Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                var x = words[i];
                for (int j = i + 1; j < words.Length; j++)
                {
                    var y = words[j];
                    if (AreAnagrams(x, y)) return false;
                }
            }
            return true;
        }

        private static bool AreAnagrams(string input1, string input2)
        {
            string sorted1 = String.Concat(input1.OrderBy(c => c));
            string sorted2 = String.Concat(input2.OrderBy(c => c));
            return (sorted1 == sorted2);
        }
    }
}
