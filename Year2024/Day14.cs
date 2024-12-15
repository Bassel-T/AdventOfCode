using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day14
    {
        class Bot
        {
            public int Px { get; set; }
            public int Py { get; set; }
            public int Vx { get; set; }
            public int Vy { get; set; }
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var bots = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x =>
                {
                    //p=0,4 v=3,-3
                    var match = Regex.Match(x, @"p=(\d+),(\d+) v=(-?\d+),(-?\d+)");

                    (int p_x, int p_y) = (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                    (int v_x, int v_y) = (int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));

                    return new Bot() { Px = p_x, Py = p_y, Vx = v_x, Vy = v_y };
                }).ToList();

                int xBound = 101;
                int yBound = 103;

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < bots.Count(); j++)
                    {
                        bots[j].Px = ((bots[j].Px + bots[j].Vx) + xBound) % xBound;
                        bots[j].Py = ((bots[j].Py + bots[j].Vy) + yBound) % yBound;
                    }
                }

                ulong[] quadrants = new ulong[4] { 0, 0, 0, 0 };
                foreach (var bot in bots)
                {
                    if (bot.Px < xBound / 2)
                    {
                        if (bot.Py < yBound / 2)
                        {
                            quadrants[0]++;
                        }
                        else if (bot.Py > yBound / 2)
                        {
                            quadrants[1]++;
                        }
                    } else if (bot.Px > xBound / 2)
                    {
                        if (bot.Py < yBound / 2)
                        {
                            quadrants[2]++;
                        }
                        else if (bot.Py > yBound / 2)
                        {
                            quadrants[3]++;
                        }
                    }
                }

                Console.WriteLine(quadrants[0] * quadrants[1] * quadrants[2] * quadrants[3]);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var bots = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x =>
                {
                    //p=0,4 v=3,-3
                    var match = Regex.Match(x, @"p=(\d+),(\d+) v=(-?\d+),(-?\d+)");

                    (int p_x, int p_y) = (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                    (int v_x, int v_y) = (int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));

                    return new Bot() { Px = p_x, Py = p_y, Vx = v_x, Vy = v_y };
                }).ToList();

                int xBound = 101;
                int yBound = 103;

                var tracking = true;
                var seconds = 1;
                var neighbors = 0;

                while (true)
                {
                    for (int j = 0; j < bots.Count(); j++)
                    {
                        bots[j].Px = ((bots[j].Px + bots[j].Vx) + xBound) % xBound;
                        bots[j].Py = ((bots[j].Py + bots[j].Vy) + yBound) % yBound;
                    }

                    neighbors = 0;
                    foreach (var bot in bots)
                    {
                        if (bots.Any(b => b.Px == bot.Px && b.Py == bot.Py - 1))
                            neighbors++;

                        if (bots.Any(b => b.Px == bot.Px && b.Py == bot.Py + 1))
                            neighbors++;

                        if (bots.Any(b => b.Px == bot.Px - 1 && b.Py == bot.Py))
                            neighbors++;

                        if (bots.Any(b => b.Px == bot.Px + 1 && b.Py == bot.Py))
                            neighbors++;
                    }

                    if (neighbors > 200)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine($"Seconds: {seconds}");

                        if (seconds == 6620)
                            Console.WriteLine($"Neighbors: {neighbors}");

                        var grid = Enumerable.Range(0, yBound).Select(y =>
                            Enumerable.Range(0, xBound).Select(x => bots.Any(b => b.Px == x && b.Py == y) ? '█' : '.'));
                        Console.WriteLine(string.Join("\r\n", grid.Select(x => string.Join("", x))));
                    }

                    seconds++;

                }
            }
        }
    }
}
