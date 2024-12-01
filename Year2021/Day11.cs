using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day11
    {
        public static void Part1()
        {
            int[][] nums = File.ReadAllLines("Input11.txt")
                      .Select(x => x.ToCharArray()
                            .Select(y => Convert.ToInt32(y.ToString()))
                            .ToArray())
                      .ToArray();
            int flashes = 0;

            for (int iters = 0; iters < 100; ++iters)
            {

                for (int x = 0; x < nums.Length; ++x)
                {
                    for (int y = 0; y < nums[0].Length; ++y)
                    {
                        // Increment each number
                        ++nums[x][y];

                        // TODO : Finish
                    }
                }
            }
        }

        public static void Part2()
        {

        }
    }
}
