using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayTwo
    {
        public static int CheckSum(int[] input)
        {
            int lowest = input[0];
            int highest = input[0];
            foreach (int i in input)
            {
                if (i > highest) highest = i;
                if (i < lowest) lowest = i;
            }
            return highest - lowest;
        }

        public static int WholeDivisor(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                int x = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    int y = input[j];
                    if (x % y == 0) return x / y;
                    if (y % x == 0) return y / x;
                }
            }
            return 0;
        }
    }
}
