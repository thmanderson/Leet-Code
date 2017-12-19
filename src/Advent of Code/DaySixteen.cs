using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class DaySixteen
    {
        public static char[] Dance(char[] startingArray, string input)
        {
            List<string> moves = input.Split(',').ToList<string>();

            foreach (var move in moves)
            {
                char moveType = move[0];
                switch (moveType)
                {
                    case 's':
                        int length = Convert.ToInt32(move.Substring(1));
                        char[] fromEnd = new char[length];
                        Array.Copy(startingArray, startingArray.Length - length, fromEnd, 0, length);                        
                        char[] fromStart = new char[startingArray.Length - length];
                        Array.Copy(startingArray, 0, fromStart, 0, startingArray.Length - length);
                        startingArray = fromEnd.Concat(fromStart).ToArray();
                        break;

                    case 'x':
                        string[] positions = move.Substring(1).Split('/');
                        var tmp = startingArray[Convert.ToInt32(positions[0])];
                        startingArray[Convert.ToInt32(positions[0])] = startingArray[Convert.ToInt32(positions[1])];
                        startingArray[Convert.ToInt32(positions[1])] = tmp;
                        break;

                    case 'p':
                        char prg1 = move[1], prg2 = move[3];
                        int ind1 = Array.FindIndex(startingArray, x => x == prg1);
                        int ind2 = Array.FindIndex(startingArray, x => x == prg2);
                        var holder = startingArray[ind1];
                        startingArray[ind1] = startingArray[ind2];
                        startingArray[ind2] = holder;
                        break;
                }
            }

            return startingArray;
        }

        public static char[] DanceLoop(char[] startingArray, string input, int loops)
        {
            string result;
            int PatternCount = 0;
            bool NewPattern;
            char[] output = (char[])startingArray.Clone();
            HashSet<string> results = new HashSet<string>();

            // Calculate how many often the pattern loops
            do
            {
                result = "";
                foreach (char c in startingArray) result += c;
                NewPattern = results.Add(result);
                startingArray = Dance(startingArray, input);
                PatternCount++;
            } while (NewPattern == true);

            int PatternIndex = loops % results.Count;

            for (int i = 0; i < PatternIndex; i++)
            {
                output = Dance(output, input);
            }

            return output;
            
        }
    }
}
