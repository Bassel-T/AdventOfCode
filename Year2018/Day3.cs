using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2018
{
    public static class Day3
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var answer = 0;
                var squares = new HashSet<(int, int)>();
                var countedOverlap = new HashSet<(int, int)>();
                Regex numbers = new Regex(@"(\d+)");

                while (!reader.EndOfStream)
                {
                    // #1 @ 49,222: 19x20
                    var line = reader.ReadLine();
                    var matches = numbers.Matches(line).Select(x => int.Parse(x.Value)).ToList();

                    for (int i = matches[1]; i < matches[1] + matches[3]; i++)
                    {
                        for (int j = matches[2]; j < matches[2] + matches[4]; j++)
                        {
                            // Avoid double counting with this ↓
                            if (!squares.Add(new(i, j)) && countedOverlap.Add(new(i, j)))
                            {
                                answer++;
                            }
                        }
                    }
                }

                Console.WriteLine(answer);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var answer = 0;
                var squares = new HashSet<(int, int)>();
                var countedOverlap = new HashSet<(int, int)>();
                Regex numbers = new Regex(@"(\d+)");

                var lines = reader.ReadToEnd().Split("\r\n");

                // #1 @ 49,222: 19x20
                foreach (var line in lines)
                {
                    var matches = numbers.Matches(line).Select(x => int.Parse(x.Value)).ToList();

                    for (int i = matches[1]; i < matches[1] + matches[3]; i++)
                    {
                        for (int j = matches[2]; j < matches[2] + matches[4]; j++)
                        {
                            // Avoid double counting with this ↓
                            if (!squares.Add(new(i, j)) && countedOverlap.Add(new(i, j)))
                            {
                                answer++;
                            }
                        }
                    }
                }
                
                foreach (var line in lines)
                {
                    var matches = numbers.Matches(line).Select(x => int.Parse(x.Value)).ToList();
                    var hasOverlap = false;

                    for (int i = matches[1]; i < matches[1] + matches[3]; i++)
                    {
                        for (int j = matches[2]; j < matches[2] + matches[4]; j++)
                        {
                            // Avoid double counting with this ↓
                            if (countedOverlap.Contains(new(i, j)))
                            {
                                hasOverlap = true;
                                break;
                            }
                        }

                        if (hasOverlap)
                            break;
                    }

                    if (!hasOverlap)
                    {
                        Console.WriteLine(matches[0]);
                    }
                }
            }
        }
    }
}
