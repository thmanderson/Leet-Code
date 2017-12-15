using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayFifteen
    {
        public static int GeneratorCount(int inputA, int inputB, int loops)
        {
            int output = 0;

            int genA = 16807, genB = 48271, divisor = 2147483647;
            long valA = inputA, valB = inputB;

            for (int i = 0; i < loops; i++)
            {
                valA = (valA* genA) % divisor;
                valB = (valB * genB) % divisor;

                var binstrA = Convert.ToString(valA, 2).PadLeft(32, '0');
                var binstrB = Convert.ToString(valB, 2).PadLeft(32, '0');

                if (binstrA.Substring(binstrA.Length - 16) == binstrB.Substring(binstrB.Length - 16)) output++;
            }

            return output;
        }

        public static int SecondGeneratorCount(int inputA, int inputB, int loops)
        {
            int output = 0;
            long valA = inputA, valB = inputB;

            for (int i = 0; i < loops; i++)
            {
                valA = GeneratorA(valA);
                valB = GeneratorB(valB);

                var binstrA = Convert.ToString(valA, 2).PadLeft(32, '0');
                var binstrB = Convert.ToString(valB, 2).PadLeft(32, '0');

                if (binstrA.Substring(binstrA.Length - 16) == binstrB.Substring(binstrB.Length - 16)) output++;
            }

            return output;
        }

        static long GeneratorA(long input)
        {
            long output = input;
            int generator = 16807, divisor = 2147483647;
            do
            {
                output = (output * generator) % divisor;
            } while (output % 4 != 0);
            return output;
        }

        static long GeneratorB(long input)
        {
            long output = input;
            int generator = 48271, divisor = 2147483647;
            do
            {
                output = (output * generator) % divisor;
            } while (output % 8 != 0);
            return output;
        }
    }
}
