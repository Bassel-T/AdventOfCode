using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day6
    {
        public static void Part1()
        {
            List<int> fish = File.ReadAllText("Input6.txt").Split(',').Select(x => { return Convert.ToInt32(x); }).ToList();
            for (int i = 0; i < 80; ++i)
            {
                for (int j = 0, c = fish.Count; j < c; ++j)
                {
                    --fish[j];
                    if (fish[j] == -1)
                    {
                        fish[j] = 6;
                        fish.Add(9);
                        ++c;
                    }
                }
            }

            Console.WriteLine(fish.Count);
        }

        public static void Part2()
        {
            List<int> fish = File.ReadAllText("Input6.txt").Split(',').Select(x => { return Convert.ToInt32(x); }).ToList();
            ulong[] counts = new ulong[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            ulong total = (ulong)fish.Count;

            foreach (int i in fish)
            {
                ++counts[i];
            }

            for (int i = 0; i < 256; ++i)
            {
                ulong[] count2 = new ulong[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                count2[6] = counts[0];
                count2[8] = counts[0];
                total += counts[0];
                for (int j = 1; j < counts.Length; ++j)
                {
                    count2[j - 1] += counts[j];
                }

                counts = count2;
            }

            Console.WriteLine(total);
        }
    }
}
