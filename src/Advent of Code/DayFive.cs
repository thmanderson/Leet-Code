using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayFive
    {
        public static int JumpsToEscapeMaze(int[] maze)
        {
            int i = 0, counter = 0;
            while (i >= 0 && i < maze.Length)
            {
                int current = maze[i];
                maze[i]++;
                i += current;
                counter++;
            }
            return counter;
        }
        public static int JumpsToEscapeComplexMaze(int[] maze)
        {
            int i = 0, counter = 0;
            while (i >= 0 && i < maze.Length)
            {
                int current = maze[i];

                if (current >= 3) maze[i]--;
                else maze[i]++;

                i += current;
                counter++;
            }
            return counter;
        }
    }
}
