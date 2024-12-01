using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day7
    {
        public static void Part1()
        {
            List<int> positions = File.ReadAllText("Input7.txt").Split(',').Select(x => { return Convert.ToInt32(x); }).ToList();
            int mincost = int.MaxValue;
            for (int i = positions.Min(), c = positions.Max(); i <= c; ++i)
            {
                int cost = positions.Select(x => { return Math.Abs(x - i); }).Sum();
                if (cost < mincost)
                {
                    mincost = cost;
                }
            }

            Console.WriteLine(mincost);
        }

        public static int SumN(int n)
        {
            return n * (n + 1) / 2;
        }

        public static void Part2()
        {
            List<int> positions = File.ReadAllText("Input7.txt").Split(',').Select(x => { return Convert.ToInt32(x); }).ToList();
            int mincost = int.MaxValue;
            for (int i = positions.Min(), c = positions.Max(); i <= c; ++i)
            {
                int cost = positions.Select(x => { return SumN(Math.Abs(x - i)); }).Sum();
                if (cost <= mincost)
                {
                    mincost = cost;
                }
            }

            Console.WriteLine(mincost);
        }
    }
}
