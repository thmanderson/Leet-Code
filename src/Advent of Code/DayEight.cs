using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class DayEight
    {
        public static int LargestAfterInstructions(IEnumerable<string> input, out int largestEver)
        {
            char[] delimiters = { ' ' };
            var values = new Dictionary<string, int>();

            largestEver = 0;

            foreach (var line in input)
            {
                // Split out the instruction
                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                // Make sure the 2 referenced registers are in the dictionary
                bool RegisterToModifyExists = values.ContainsKey(parts[0]);
                bool RegisterToCompareExists = values.ContainsKey(parts[4]);
                if (!RegisterToModifyExists) values.Add(parts[0], 0);
                if (!RegisterToCompareExists) values.Add(parts[4], 0);

                // Compare conditional register to the final value
                var actualValue = values[parts[4]];
                var conditionValue = Convert.ToInt32(parts[6]);
                bool conditionTrue = EvaluateCondition(parts[5], actualValue, conditionValue);

                if (conditionTrue)
                {
                    if (parts[1] == "inc") values[parts[0]] += Convert.ToInt32(parts[2]);
                    else values[parts[0]] -= Convert.ToInt32(parts[2]);
                }

                largestEver = Math.Max(largestEver, values.Max(x => x.Value));
            }

            return values.Max(x => x.Value);
        }

        public static bool EvaluateCondition(string logic, int x, int y)
        {
            switch (logic)
            {
                case ">": return x > y;
                case ">=": return x >= y;
                case "<": return x < y;
                case "<=": return x <= y;
                case "==": return x == y;
                default: return x != y;
            }
        }
    }
}
