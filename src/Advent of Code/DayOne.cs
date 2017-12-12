using System;

namespace AdventOfCode
{
    public static class DayOne
    {
        public static int InverseCaptcha(string inputCode)
        {
            char c, n;
            int current, next, total = 0;
            for (int i = 0; i < inputCode.Length; i++)
            {
                c = inputCode[i];
                current = int.Parse(c.ToString());

                if (i == inputCode.Length - 1) n = inputCode[0];
                else n = inputCode[i + 1];
                next = int.Parse(n.ToString());

                if (current == next) total += current;
            }

            return total;
        }

        public static int HalfwayCaptcha(string inputCode)
        {
            int halfLength = inputCode.Length / 2;
            char c, n;
            int current, next, total = 0;

            for (int i = 0; i < inputCode.Length; i++)
            {
                // Get the current int.
                c = inputCode[i];
                current = int.Parse(c.ToString());

                // Figure out the index of the int we want to compare to.
                int x = i + halfLength;
                if (x >= inputCode.Length) x -= inputCode.Length;

                // Get the int we want to compare to.
                n = inputCode[x];
                next = int.Parse(n.ToString());

                if (current == next) total += current;
            }

            return total;
        }

    }
}
