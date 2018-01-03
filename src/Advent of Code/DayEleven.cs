using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayEleven
    {
        public static int HexStepsTaken(IEnumerable<string> input, out int furthestDist)
        {
            int x = 0, y = 0, z = 0;
            int currentDist = 0;
            furthestDist = 0;

            foreach (string s in input)
            {
                switch (s)
                {
                    case "n":
                        y++; z--; break;
                    case "s":
                        y--; z++; break;
                    case "ne":
                        x++; z--; break;
                    case "sw":
                        x--; z++; break;
                    case "nw":
                        y++; x--; break;
                    default:
                        y--; x++; break;
                }
                currentDist = Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs(z));
                furthestDist = Math.Max(currentDist, furthestDist);
            }

            return currentDist;
        }
    }
}
