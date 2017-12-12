using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayNine
    {
        public static int GroupScore(string input, out int totalgarbage)
        {
            int totalscore = 0;
            int currentlevel = 0;
            totalgarbage = 0;
            bool garbage = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (garbage)
                {
                    if (input[i] == '!') i++;
                    else if (input[i] == '>') garbage = false;
                    else { totalgarbage++; }
                }
                else
                {
                    switch (input[i])
                    {
                        case '{':
                            currentlevel += 1;
                            totalscore += currentlevel;
                            break;
                        case '}':
                            currentlevel -= 1;
                            break;
                        case '<':
                            garbage = true;
                            break;
                    }
                }
            }
            return totalscore;
        }
    }
}
