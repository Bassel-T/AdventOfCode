using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day22
    {
        private static long Mix(long value, long secret) => value ^ secret;
        private static long Prune(long secret) => secret % 16777216;

        public static void Part1()
        {
            var data = File.ReadLines("input.txt").Select(long.Parse).ToList();

            long score = 0;
            for (int i = 0; i < 2000; i++)
            {
                data = data.Select((item) =>
                {
                    var mult64 = item * 64;
                    var mixin = Mix(mult64, item);
                    var pruned = Prune(mixin);

                    var div32 = pruned / 32;
                    var mixin2 = Mix(div32, pruned);
                    var pruned2 = Prune(mixin2);

                    var mult2048 = pruned2 * 2048;
                    var mixin3 = Mix(pruned2, mult2048);
                    var pruned3 = Prune(mixin3);

                    return pruned3;

                }).ToList();
            }

            foreach (var item in data)
            {
                score += item;
            }

            Console.WriteLine(score);
        }

        public static void Part2()
        {
            var data = File.ReadLines("input.txt").Select(long.Parse).ToList();
            var prices = data.Select(x => new List<int>() { (int)(x % 10) }).ToList();

            long score = 0;
            for (int i = 0; i < 2000; i++)
            {
                data = data.Select((item, i) =>
                {
                    var mult64 = item * 64;
                    var mixin = Mix(mult64, item);
                    var pruned = Prune(mixin);

                    var div32 = pruned / 32;
                    var mixin2 = Mix(div32, pruned);
                    var pruned2 = Prune(mixin2);

                    var mult2048 = pruned2 * 2048;
                    var mixin3 = Mix(pruned2, mult2048);
                    var pruned3 = Prune(mixin3);

                    prices[i].Add((int)(pruned3 % 10));

                    return pruned3;

                }).ToList();
            }

            var diffs = prices.Select(x =>
            {
                return x.Select((price, i) =>
                {
                    if (i == 0) return 0;
                    return x[i] - x[i - 1];
                }).ToList();
            }).ToList();

            Dictionary<string, long> bananasSold = new Dictionary<string, long>();
            for (int j = 0; j < diffs.Count; j++)
            {
                HashSet<string> negotiations = new HashSet<string>();

                for (int i = 1; i < diffs[j].Count - 3; i++)
                {
                    var chunk = diffs[j].Skip(i).Take(4);
                    var key = string.Join(",", chunk);

                    if (!negotiations.Contains(key))
                    {
                        CollectionUtil.InsertOrIncrement(bananasSold, key, prices[j][i + 3]);
                        negotiations.Add(key);
                    }
                }
            }

            Console.WriteLine(bananasSold.Max(x => x.Value));
            Console.WriteLine(bananasSold.MaxBy(x => x.Value).Key);
        }
    }
}
