using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day14
    {

        public static void Part1()
        {
            var rockEdges = File.ReadAllLines("Input.txt")
                .Select(x => x
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(y => {
                        var inputs = y.Split(',')
                            .Select(z => int.Parse(z))
                            .ToList();
                        return new Vector2(inputs[0], inputs[1]);
                    }).ToList()
                ).ToList();

            int grainsOfSand = 0;
            List<Vector2> existsAt = new List<Vector2>();

            // Build the initial state
            foreach (var path in rockEdges)
            {
                for (int i = 0, c = path.Count - 1; i < c; i++)
                {
                    var curr = path[i];
                    var next = path[i + 1];
                    var diff = next - curr;
                    diff /= diff.Length();
                    var count = 0;

                    while (!existsAt.Contains(next))
                    {
                        existsAt.Add(curr + diff * count);
                        count++;
                    }
                }
            }

            // Maximum possible starting value for y
            var maxHeight = existsAt.Max(z => z.Y);

            while (true)
            {
                // Drop a grain
                var drop = new Vector2(500, 0);

                while (true)
                {
                    if (drop.Y > maxHeight)
                    {
                        Console.WriteLine(grainsOfSand);
                        return;
                    }

                    if (!existsAt.Contains(new Vector2(drop.X, drop.Y + 1)))
                    {
                        drop.Y++;
                        continue;
                    }

                    if (!existsAt.Contains(new Vector2(drop.X - 1, drop.Y + 1)))
                    {
                        drop.X--;
                        drop.Y++;
                        continue;
                    }

                    if (!existsAt.Contains(new Vector2(drop.X + 1, drop.Y + 1)))
                    {
                        drop.X++;
                        drop.Y++;
                        continue;
                    }


                    existsAt.Add(drop);
                    grainsOfSand++;
                    break;
                }

            }
        }

        public static void Part2()
        {
            var rockEdges = File.ReadAllLines("Input.txt")
                .Select(x => x
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(y => {
                        var inputs = y.Split(',')
                            .Select(z => int.Parse(z))
                            .ToList();
                        return new Vector2(inputs[0], inputs[1]);
                    }).ToList()
                ).ToList();

            int grainsOfSand = 0;
            List<Vector2> existsAt = new List<Vector2>();

            // Build the initial state
            foreach (var path in rockEdges)
            {
                for (int i = 0, c = path.Count - 1; i < c; i++)
                {
                    var curr = path[i];
                    var next = path[i + 1];
                    var diff = next - curr;
                    diff /= diff.Length();
                    var count = 0;

                    while (!existsAt.Contains(next))
                    {
                        existsAt.Add(curr + diff * count);
                        count++;
                    }
                }
            }

            // Maximum possible starting value for y
            var maxHeight = existsAt.Max(z => z.Y);

            while (!existsAt.Contains(new Vector2(500, 0)))
            {
                // Drop a grain
                var drop = new Vector2(500, 0);

                while (true)
                {
                    if (drop.Y == maxHeight + 1)
                    {
                        existsAt.Add(drop);
                        grainsOfSand++;
                        break;
                    }

                    if (!existsAt.Contains(new Vector2(drop.X, drop.Y + 1)))
                    {
                        drop.Y++;
                        continue;
                    }

                    if (!existsAt.Contains(new Vector2(drop.X - 1, drop.Y + 1)))
                    {
                        drop.X--;
                        drop.Y++;
                        continue;
                    }

                    if (!existsAt.Contains(new Vector2(drop.X + 1, drop.Y + 1)))
                    {
                        drop.X++;
                        drop.Y++;
                        continue;
                    }


                    existsAt.Add(drop);
                    grainsOfSand++;
                    break;
                }

            }

            Console.WriteLine(grainsOfSand);
        }

    }
}
