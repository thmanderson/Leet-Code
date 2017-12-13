using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayTwelve
    {
        public static int LinkedPipes(Dictionary<int, List<int>> input, out int totalGroups)
        {
            int target = 0;
            totalGroups = 1;
            var connectToTarget = new HashSet<int>();

            AddToSet(ref connectToTarget, input, target);

            var output = connectToTarget.Count;

            foreach (var x in input)
            {
                if (connectToTarget.Contains(x.Key)) continue;
                else
                {
                    AddToSet(ref connectToTarget, input, x.Key);
                    totalGroups++;
                }
            }

            return output;
        }

        private static void AddToSet(ref HashSet<int> set, Dictionary<int, List<int>> input, int toBeAdded)
        {
            set.Add(toBeAdded);

            foreach (int i in input[toBeAdded])
            {
                if (set.Contains(i)) continue;
                else AddToSet(ref set, input, i);
            }
        }

        public static int TotalGroups(Dictionary<int, List<int>> input)
        {
            List<int> sets = new List<int>();

            foreach (var x in input)
            {

            }

            return 0;
        }
    }
}
