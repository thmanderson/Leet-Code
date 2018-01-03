using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayThirteen
    {
        public static int ShortestDelay(List<Tuple<int, int>> firewall)
        {
            int time = -1, severity = 0;
            bool caught = true;

            do
            {
                time++;
                severity = FirewallSeverity(firewall, time, out caught);
            } while (caught);

            return time;
        }

        public static int FirewallSeverity(List<Tuple<int,int>> firewall, int time, out bool caught)
        {
            int severity = 0, step = 0;
            caught = false;

            // Step through the layers
            foreach (var layer in firewall)
            {
                // Increment time until we are at the next layer
                while (step != layer.Item1)
                {
                    step++;
                    time++;
                }

                // Figure out where the scanner is
                int timeToScan = layer.Item2 - 1;
                int scanCount = time / timeToScan;
                int currentScanDistance = time % timeToScan;

                // If caught, what is the severity?
                if (scanCount % 2 == 0 && currentScanDistance == 0)
                {
                    caught = true;
                    severity += (layer.Item1 * layer.Item2);
                }
            }

            return severity;
        }
    }
}
