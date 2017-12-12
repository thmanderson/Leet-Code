using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayTwelve
    {
        public static int LinkedPipes(Dictionary<int, List<int>> input)
        {
            int counter = 0, target = 0;
            var connectToTarget = new HashSet<int>();
            connectToTarget.Add(target);

            foreach (var value in input)
            {

            }

            return counter;
        }

        public static bool IsLinkedTo(int programToLink, int program, Dictionary<int, List<int>> input)
        {
            // Get list of programs the program in question links to
            var listOfLinks = input[program];

            // If it can link directly great
            if (listOfLinks.Contains(programToLink)) return true;

            else
            {
                foreach (int i in listOfLinks)
                {
                    if (i == program) break;
                    if (IsLinkedTo(programToLink, i, input)) return true;
                }
            }

            return false;
        }
    }
}
