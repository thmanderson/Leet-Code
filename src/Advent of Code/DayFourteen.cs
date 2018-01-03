using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class DayFourteen
    {
        public static int Defrag(string input, int rows)
        {
            int output = 0;

            for (int i = 0; i < rows; i++)
            {
                // For 0 up to the number of rows, get the knothash of the input.
                string row = input + "-" + i;
                string hash = DayTen.KnotHashPartTwo(row);

                // Convert this row from 32 character hex to 128 digit binary
                string binaryhash = String.Join(String.Empty, hash.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

                // Count the number of spaces in use ( == 1), and add to the total
                foreach (char c in binaryhash) if (c == '1') output++;
            }

            // Return the total
            return output;
        }

        public static int DefragGroups(string input, int rows)
        {
            int[,] grid = new int[rows,128];
            int output = 0;

            // Get grid
            for (int i = 0; i < rows; i++)
            {
                // For 0 up to the number of rows, get the knothash of the input.
                string row = input + "-" + i;
                string hash = DayTen.KnotHashPartTwo(row);

                // Convert this row from 32 character hex to 128 digit binary
                string binaryhash = String.Join(String.Empty, hash.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

                // Count the number of spaces in use ( == 1), and add to the total
                for (int j = 0; j < 128; j++)
                {
                    grid[i, j] = (int)Char.GetNumericValue(binaryhash[j]);
                }
            }

            // Iterate through grid, blank out each group, add 1 to total
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        BlankGroupFrom(i, j, ref grid);
                        output++;
                    }
                }
            }

            return output;
        }

        public static void BlankGroupFrom(int x, int y, ref int[,] grid)
        {
            grid[x, y] = 0;
            if (x != 0) if (grid[x - 1, y] == 1) BlankGroupFrom(x - 1, y, ref grid);
            if (x != 127) if (grid[x + 1, y] == 1) BlankGroupFrom(x + 1, y, ref grid);
            if (y != 0) if (grid[x, y - 1] == 1) BlankGroupFrom(x, y - 1, ref grid);
            if (y != 127) if (grid[x, y + 1] == 1) BlankGroupFrom(x, y + 1, ref grid);
        }
    }
}
