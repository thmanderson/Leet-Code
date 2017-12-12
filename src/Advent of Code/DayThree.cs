using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayThree
    {
        public static int SpiralDistance(int input)
        {
            if (input == 1) return 0;

            // Find square root of the input, and round down.
            // e.g. input = 17, sqrt = 4.1..., rounds down to 4.
            var sqrt = Convert.ToInt32(Math.Floor(Math.Sqrt(input)));

            // If odd, fine, if not, -1.
            // e.g. input = 17, sqrt = 4, lower odd sqrt = 3.
            var lowerOddSqrt = sqrt;
            if (lowerOddSqrt % 2 == 0) lowerOddSqrt -= 1;

            // Find the layer number, based on the lower odd sqrt above.
            // e.g. input = 17, lower odd = 3, layer = 3.
            var layer = (lowerOddSqrt + 3) / 2;

            // Find length of sides for this layer
            // e.g. layer 3, length = 4.
            var sideLength = (layer * 2) - 2;

            // Find the distance of the input from the previous layer.
            // End of the previous layer = lower odd sqrt ^ 2.
            // e.g. input = 17, end of previous layer = 9, distance = 8.
            int layerDistance = input - Convert.ToInt32((Math.Pow(lowerOddSqrt, 2)));

            // Find how far into it's side this number is.
            // e.g. 17 is 8 from the previous layer, and is the 4th number of that side of the layer.
            int sideDistance = layerDistance % sideLength;
            if (sideDistance == 0) sideDistance = sideLength;

            // Find distance to closest centre of side.
            // e.g. 17 is 2 away from centre of both layers.
            // e.g. 16 is 1 away from previous centre, and 3 away from next centre.
            int distanceToClosest = Math.Abs(sideDistance - Convert.ToInt32((sideLength / 2)));

            return distanceToClosest + (layer - 1);
        }

        public static List<int> SpiralOutput(int input)
        {
            int[,] grid = new int[11, 11];
            grid[5, 5] = 1;


            var spiral = new List<int>();
            spiral.Add(1);

            for (int i = 2; i < input; i++)
            {
                // i = number to be added index
                // i - 1 = previous number index
                // i - (number of numbers in this layer - 1) = index of number above
                // Find square root of the input, and round down.
                // e.g. input = 17, sqrt = 4.1..., rounds down to 4.
                var sqrt = Convert.ToInt32(Math.Floor(Math.Sqrt(i)));

                // If odd, fine, if not, -1.
                // e.g. input = 17, sqrt = 4, lower odd sqrt = 3.
                var lowerOddSqrt = sqrt;
                if (lowerOddSqrt % 2 == 0) lowerOddSqrt -= 1;

                // Find the layer number, based on the lower odd sqrt above.
                // e.g. input = 17, lower odd = 3, layer = 3.
                var layer = (lowerOddSqrt + 3) / 2;

                // Find length of sides for this layer
                // e.g. layer 3, length = 4.
                var sideLength = (layer * 2) - 2;

                // Find the distance of the input from the previous layer.
                // End of the previous layer = lower odd sqrt ^ 2.
                // e.g. input = 17, end of previous layer = 9, distance = 8.
                int layerDistance = input - Convert.ToInt32((Math.Pow(lowerOddSqrt, 2)));

                // Find how far into it's side this number is.
                // e.g. 17 is 8 from the previous layer, and is the 4th number of that side of the layer.
                int sideDistance = layerDistance % sideLength;
                if (sideDistance == 0) sideDistance = sideLength;
            }

            return spiral;
        }
    }
}
