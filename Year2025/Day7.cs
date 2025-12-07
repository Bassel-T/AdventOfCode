using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day7
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var tree = reader.ReadToEnd().Split("\r\n").Select(x => x.ToCharArray().ToList()).ToList();

                var starting = CollectionUtil.FindCoordsInGrid<char>(tree, 'S');

                HashSet<(int x, int y)> tachyons = new HashSet<(int x, int y)>() { starting };
                var answer = 0;

                for (int i = 0; i < tree.Count - 1; i++)
                {
                    HashSet<(int x, int y)> newTachyons = new HashSet<(int x, int y)>();

                    foreach (var tachyon in tachyons)
                    {
                        if (tree[tachyon.x + 1][tachyon.y] == '^')
                        {
                            answer++;
                            newTachyons.Add((tachyon.x + 1, tachyon.y - 1));

                            newTachyons.Add((tachyon.x + 1, tachyon.y + 1));
                        }
                        else
                        {
                            newTachyons.Add((tachyon.x + 1, tachyon.y));
                        }
                    }

                    tachyons = newTachyons;
                }

                Console.WriteLine(answer);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var tree = reader.ReadToEnd().Split("\r\n").Select(x => x.ToCharArray().ToList()).ToList();

                var starting = CollectionUtil.FindCoordsInGrid<char>(tree, 'S');

                HashSet<(int x, int y)> tachyons = new HashSet<(int x, int y)>() { starting };
                Dictionary<(int x, int y), long> beamCount = new Dictionary<(int x, int y), long>();
                beamCount[starting] = 1;

                for (int i = 0; i < tree.Count - 1; i++)
                {
                    HashSet<(int x, int y)> newTachyons = new HashSet<(int x, int y)>();

                    foreach (var tachyon in tachyons)
                    {

                        if (tree[tachyon.x + 1][tachyon.y] == '^')
                        {
                            newTachyons.Add((tachyon.x + 1, tachyon.y - 1));
                            newTachyons.Add((tachyon.x + 1, tachyon.y + 1));

                            CollectionUtil.InsertOrIncrement(beamCount, (tachyon.x + 1, tachyon.y - 1), beamCount[(tachyon.x, tachyon.y)]);
                            CollectionUtil.InsertOrIncrement(beamCount, (tachyon.x + 1, tachyon.y + 1), beamCount[(tachyon.x, tachyon.y)]);
                        }
                        else
                        {
                            newTachyons.Add((tachyon.x + 1, tachyon.y));
                            CollectionUtil.InsertOrIncrement(beamCount, (tachyon.x + 1, tachyon.y), beamCount[tachyon]);
                        }
                    }

                    tachyons = newTachyons;
                }

                Console.WriteLine(tachyons.Sum(x => beamCount[x]));
            }
        }

        public static void Part2Orig()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var tree = reader.ReadToEnd().Split("\r\n").Select(x => x.ToCharArray().ToList()).ToList();

                var starting = CollectionUtil.FindCoordsInGrid<char>(tree, 'S');
                var answer = 0;

                Stack<(int x, int y)> trace = new Stack<(int x, int y)>();
                trace.Push(starting);

                while (trace.Any())
                {
                    var tachyon = trace.Pop();

                    if (tachyon.x == tree.Count - 1)
                    {
                        answer++;
                        continue;
                    }

                    if (tree[tachyon.x + 1][tachyon.y] == '^')
                    {
                        trace.Push((tachyon.x + 1, tachyon.y + 1));
                        trace.Push((tachyon.x + 1, tachyon.y - 1));
                        continue;
                    }

                    trace.Push((tachyon.x + 1, tachyon.y));
                }

                Console.WriteLine(answer);
            }
        }
    }
}
