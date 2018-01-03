using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{

    public static class DaySeven
    {
        public static string GetBase(IEnumerable<Tuple<string, List<string>>> tower)
        {
            string result = "";

            foreach (Tuple<string, List<string>> subtower in tower)
            {
                bool isRoot = true;
                // Check if other subtowers contain it
                foreach (Tuple<string, List<string>> subtower2 in tower)
                {
                    if (subtower2.Item2.Contains(subtower.Item1))
                    {
                        isRoot = false;
                        break;
                    }
                }

                if (isRoot)
                {
                    result = subtower.Item1;
                    break;
                }
            }

            return result;
        }
        
        public static int FindProblemWeight(List<Tuple<string, List<string>>> tower, string basename, int imbalance = 0)
        {
            var root = tower.Find(x => x.Item1.Equals(basename));
            var rootweight = Convert.ToInt32(root.Item2[0]);
            var weights = new List<Tuple<string, int>>();
            var baseweights = new List<Tuple<string, int>>();


            // Find the weight of each sub tower            var baseweights = new List<Tuple<string, int>>();
            foreach (var sub in root.Item2.Skip(1))
            {
                weights.Add(new Tuple<string, int>(sub, FindWeight(tower, sub)));
                baseweights.Add(new Tuple<string, int>(sub, Convert.ToInt32(tower.Find(x => x.Item1.Equals(sub)).Item2[0])));
            }

            // if imbalance hasn't been provided, that means we need to calculate it.
            if (imbalance == 0)
            {
                var lowest = weights.Min(x => x.Item2);
                var highest = weights.Max(x => x.Item2);

                imbalance = highest - lowest;
            }

            foreach (var weight in weights)
            {
                if (IsImbalanced(tower, weight.Item1)) return FindProblemWeight(tower, weight.Item1, imbalance);
            }

            // If none are imbalanced - then either this node is unbalanced or one of the base weights above is unbalanced
            if (weights.All(x => x.Item2 == weights[0].Item2))
            {
                return rootweight + imbalance;
            }
            else // identify the odd one out
            {
                // EDIT THIS: Currently is removes the imbalance from the highest baseweight, it should remove from the baseweight of the one with highest TOTAL weight.
                var lowest = weights.Min(x => x.Item2);
                var highest = weights.Max(x => x.Item2);

                if (imbalance > 0)
                {
                    int i = weights.FindIndex(x => x.Item2 == highest);
                    return baseweights[i].Item2 - imbalance;
                }
                else
                {
                    int i = weights.FindIndex(x => x.Item2 == lowest);
                    return baseweights[i].Item2 - imbalance;
                }
            }
        }

        public static bool IsImbalanced(List<Tuple<string, List<string>>> tower, string basename)
        {
            var root = tower.Find(x => x.Item1.Equals(basename));
            var weights = new List<Tuple<string, int>>();


            // If it does, find the weight of each sub tower
            foreach (var sub in root.Item2.Skip(1))
            {
                weights.Add(new Tuple<string, int>(sub, FindWeight(tower, sub)));
            }

            // If it has no or just one balanced sub-towers, can't be imbalanced.
            if (weights.Count == 0 || weights.Count == 1) return false;
            else if (weights.Count == 2)
            {
                if (weights[0].Item2 == weights[1].Item2) return false;
                else return true;
            }
            else
            {
                foreach (var weight in weights)
                {
                    if (weight.Item2 != weights[0].Item2) return true;
                }
            }

            return false;
        }

        // Find total weight of a subtower within a given tower, including the starting point weight.
        public static int FindWeight(List<Tuple<string, List<string>>> tower, string startingPoint)
        {
            int totalWeight = 0;

            var start = tower.Find(x => x.Item1.Equals(startingPoint));
            if (start == null) return totalWeight;

            totalWeight += Convert.ToInt32(start.Item2[0]);

            if (start.Item2.Count == 1) return totalWeight;
            for (int i = 1; i < start.Item2.Count; i++)
            {
                totalWeight += FindWeight(tower, start.Item2[i]);
            }

            return totalWeight;
        }
    }
}
