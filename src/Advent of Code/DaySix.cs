using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DaySix
    {
        public static int Redistribute(int[] input, out int loopSize)
        {
            int counter = 0;
            loopSize = 0;
            List<string> arrangements = new List<string>();
            bool unrepeated = true;

            while (unrepeated)
            {

                // store the existing arrangement
                string arrangement = "";
                foreach (int i in input) arrangement += (i + " ");
                unrepeated = !arrangements.Contains(arrangement);
                if (!unrepeated)
                {
                    loopSize = counter - arrangements.FindIndex(s => s.Equals(arrangement));
                    break;
                }
                else arrangements.Add(arrangement);
                counter++;

                // find biggest
                int biggest = 0, biggestIndex = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] > biggest)
                    {
                        biggestIndex = i;
                        biggest = input[i];
                    }
                }

                // re-dist biggest
                input[biggestIndex] = 0; int x = biggestIndex + 1;
                while (biggest > 0)
                {
                    if (x >= input.Length) x = 0;
                    input[x]++;
                    biggest--;
                    x++;
                }
            }

            return counter;
        }
    }
}
