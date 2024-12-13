using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day13
    {
        private static (long x, long y) ParseButton(string line)
        {
            //Button A: X+46, Y+68
            var data = Regex.Match(line, @"Button (\w): X\+(\d+), Y\+(\d+)");
            return (long.Parse(data.Groups[2].Value), long.Parse(data.Groups[3].Value));
        }


        private static(long x, long y) ParsePrize(string line)
        {
            // Prize: X=18641, Y=10279
            var data = Regex.Match(line, @"Prize: X=(\d+), Y=(\d+)");
            return (long.Parse(data.Groups[1].Value), long.Parse(data.Groups[2].Value));
        }

        private static long GreedySearch((long x, long y) A, (long x, long y) B, (long x, long y) P)
        {
            long fewestTokens = long.MaxValue;

            for (long a = 0; a <= 100; a++)
            {
                for (long b = 0; b <= 100; b++)
                {
                    long totalX = a * A.x + b * B.x;
                    long totalY = a * A.y + b * B.y;

                    if (totalX == P.x && totalY == P.y)
                    {
                        long tokens = a * 3 + b;
                        if (tokens < fewestTokens)
                        {
                            fewestTokens = tokens;
                        }
                    }
                }
            }

            return fewestTokens;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var lines = reader.ReadToEnd().Split("\r\n", StringSplitOptions.None);

                long totalTokens = 0;

                for (int i = 0; i < lines.Length; i += 4)
                {
                    var buttonA = ParseButton(lines[i]);
                    var buttonB = ParseButton(lines[i + 1]);
                    var prize = ParsePrize(lines[i + 2]);

                    var result = GreedySearch(buttonA, buttonB, prize);

                    if (result < long.MaxValue);
                    {
                        totalTokens += result;
                    }
                }

                Console.WriteLine(totalTokens);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var lines = reader.ReadToEnd().Split("\r\n", StringSplitOptions.None);

                long totalTokens = 0;

                for (int i = 0; i < lines.Length; i += 4)
                {
                    var A = ParseButton(lines[i]);
                    var B = ParseButton(lines[i + 1]);
                    var P = ParsePrize(lines[i + 2]);

                    P.x += 10000000000000;
                    P.y += 10000000000000;

                    long b = (A.y * P.x - A.x * P.y) / (A.y * B.x - A.x * B.y);
                    long a = (P.x - B.x * b) / A.x;

                    if (P.x == A.x * a + B.x * b && P.y == A.y * a + B.y * b)
                    {
                        long cost = 3 * a + b;
                        Console.WriteLine(cost);
                        if (cost > 0)
                            totalTokens += 3 * a + b;
                    }
                }

                Console.WriteLine(totalTokens);
            }
        }
    }
}
