using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2017
{
    public static class Day2
    {
        public static void Part1()
        {
            int sum = 0;
            File.ReadAllLines("Input.txt")
                .Select(x => x.Split('\t')
                            .Select(x => int.Parse(x))
                        )
                .ToList()
                .ForEach(x => {
                    sum += x.Max() - x.Min();
                });

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            int sum = 0;
            var lines = File.ReadAllLines("Input.txt")
                .Select(x => x.Split('\t')
                            .Select(x => int.Parse(x))
                            .ToList()
                        )
                .ToList();

            foreach (var line in lines)
            {
                var found = false;
                for (int i = 0, c = line.Count; i < c - 1; i++)
                {
                    for (int j = i + 1; j < c; j++)
                    {
                        if (line[i] % line[j] == 0)
                        {
                            sum += line[i] / line[j];
                            found = true;
                        }

                        if (line[j] % line[i] == 0)
                        {
                            sum += line[j] / line[i];
                            found = true;
                        }

                        if (found)
                        {
                            break;
                        }
                    }

                    if (found)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
