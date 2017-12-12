using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayTen
    {
        public static int KnotHash(int[] lengths, int[] input)
        {
            // Starting values for index and skip.
            int index = 0, skip = -1;

            foreach (int length in lengths)
            {
                int start, end, middle;
                skip++;

                // Grab index before updating it.
                start = index;
                index += (length + skip);
                if (index >= input.Length) index -= input.Length;

                if (length == 1) continue;

                end = start + length - 1;
                if (end >= input.Length) end -= (input.Length - 1);

                middle = start + (length / 2);
                if (middle >= input.Length) middle -= input.Length;
                
                // if (start > middle) middle--;
                // if (middle < 0) middle += input.Length;

                for (int i = start; i != middle; i++, end--)
                {
                    if (i >= input.Length) i = 0;
                    if (end < 0) end = input.Length - 1;
                    if (i == middle) break;

                    var tmp = input[i];
                    input[i] = input[end];
                    input[end] = tmp;
                }
            }

            return input[0] * input[1];

        }
    }
}
