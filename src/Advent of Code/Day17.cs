using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class Day17
    {
        public static int Problem1(int maxValues, int valueAfter, int input)
        {
            // Set up the List to be used as the buffer
            var CircularBuffer = new List<int> { 0 };
            int index = 0;

            for (int value = 1; value <= maxValues; value++)
            {
                int nextIndex = index + input;
                nextIndex = nextIndex % CircularBuffer.Count;
                CircularBuffer.Insert(nextIndex + 1, value);
                index = nextIndex + 1;
            }
            
            return CircularBuffer[CircularBuffer.FindIndex(x => x == valueAfter) + 1];
        }

        public static int Problem2(int maxValues, int input)
        {
            int expectedLength = 1, index = 0, holder = 0;

            for (int value = 1; value <= maxValues; value++)
            {
                int nextIndex = (index + input) % expectedLength;
                if (nextIndex == 0) holder = value;
                index = nextIndex + 1;
                expectedLength++;
            }

            return holder;
        }
    }
}
