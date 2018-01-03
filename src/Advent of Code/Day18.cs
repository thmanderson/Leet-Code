using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day18
    {
        public static int Problem1(string[] instructions)
        {
            // Colllection of values for different registers.
            var Registers = new Dictionary<char, long>();
            long lastPlayedSound = 0;

            for(long i = 0; i < instructions.Length; i++)
            {
                // Split instruction into parts: 1 - command, 2 - register to modify, 3 - value to modify by (int or refers to another register, to use its value)
                string[] parts = instructions[i].Split(' ');
                char register = parts[1][0];
                if (!Registers.ContainsKey(register)) Registers.Add(register, 0);
                long modifier = 0;

                // Figure out if the third string exists, and if it's a number of a register
                if (parts.Length == 3)
                {
                    if (parts[2][0] == '-' || System.Char.IsDigit(parts[2][0])) modifier = Convert.ToInt32(parts[2]);
                    else
                    {
                        modifier = Registers[parts[2][0]];
                        if (!Registers.ContainsKey(parts[2][0])) Registers.Add(parts[2][0], 0);
                    }
                }

                switch (parts[0])
                {
                    case "set":
                        Registers[register] = modifier;
                        break;
                    case "snd":
                        lastPlayedSound = Registers[register];
                        break;
                    case "add":
                        Registers[register] += modifier;
                        break;
                    case "mod":
                        Registers[register] = Registers[register] % modifier;
                        break;
                    case "mul":
                        Registers[register] *= modifier;
                        break;
                    case "rcv":
                        if (Registers[register] != 0) return (int)lastPlayedSound;
                        break;
                    case "jgz":
                        if (Registers[register] > 0) i += (modifier - 1);
                        break;
                }
            }

            return (int)lastPlayedSound;
        }
        public static int Problem2(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
