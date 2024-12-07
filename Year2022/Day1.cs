using System;
using System.Linq;

namespace AdventOfCode.Year2022
{
    public static class Day1
    {
        public static void Part1()
        {
            var text = File.ReadAllLines("input.txt");
            var max = 0;
            var curr = 0;
            foreach (var line in text)
            {
                if (string.Empty == line)
                {
                    if (max < curr)
                    {
                        max = curr;
                    }
                    curr = 0;
                }
                else
                {
                    curr += int.Parse(line);
                }
            }

            Console.WriteLine(max);
        }

        public static void Part2()
        {
            var text = File.ReadAllLines("input.txt");
            List<int> carries = new List<int>();
            var curr = 0;
            foreach (var line in text)
            {
                if (string.Empty == line)
                {
                    carries.Add(curr);
                    curr = 0;
                }
                else
                {
                    curr += int.Parse(line);
                }
            }

            var max = carries.OrderByDescending(x => x).Take(3).Sum();
            Console.WriteLine(max);
        }
    }
}