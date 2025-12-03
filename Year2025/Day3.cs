using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day3
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                int sum = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    int max = 0;

                    for (int i = 0; i < line.Length - 1; i++)
                    {
                        for (int j = i + 1; j < line.Length; j++)
                        {
                            int test = int.Parse($"{line[i]}{line[j]}");

                            if (test > max)
                            {
                                max = test;
                            }
                        }
                    }

                    sum += max;
                }

                Console.WriteLine(sum);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                ulong sum = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var largest = ulong.Parse(CollectionUtil.GetLargestWithSkips(line, 12));
                    sum += largest;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
