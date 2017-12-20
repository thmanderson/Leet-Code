using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day18
    {
        public static int Problem1(string[] instructions)
        {
            throw new NotImplementedException(nameof(Problem1));
            var Registers = new Dictionary<char, int>();

            for(int i = 0; i < instructions.Length; i++)
            {
                string[] parts = instructions[i].Split(' ');
                char register = parts[1][0];
                if (!Registers.ContainsKey(register)) Registers.Add(register, 0);

                switch (parts[0])
                {

                }
            }

        }
    }
}
