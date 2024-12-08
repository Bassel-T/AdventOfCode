using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day8
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().ToList()).ToList();

                Dictionary<char, List<Tuple<int, int>>> positions = new Dictionary<char, List<Tuple<int, int>>>();

                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[0].Count; j++)
                    {
                        if (grid[i][j] == '.') continue;

                        if (positions.ContainsKey(grid[i][j]))
                            positions[grid[i][j]].Add(new Tuple<int, int>(i, j));
                        else
                            positions.Add(grid[i][j], new List<Tuple<int, int>>() { new Tuple<int, int>(i, j) });
                    }
                }

                List<Tuple<int, int>> antinodes = new List<Tuple<int, int>>();

                foreach (var list in positions.Values)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            var p1 = list[i];
                            var p2 = list[j];

                            var diff = new Tuple<int, int>(p2.Item1 - p1.Item1, p2.Item2 - p1.Item2);

                            var p1Diff = new Tuple<int, int>(p1.Item1 - diff.Item1, p1.Item2 - diff.Item2);
                            if (p1Diff.Item1 >= 0 && p1Diff.Item2 >= 0 && p1Diff.Item1 < grid.Count && p1Diff.Item2 < grid[p1Diff.Item1].Count())
                                antinodes.Add(p1Diff);

                            var p2Diff = new Tuple<int, int>(p2.Item1 + diff.Item1, p2.Item2 + diff.Item2);
                            if (p2Diff.Item1 < grid.Count && p2Diff.Item2 < grid[p2Diff.Item1].Count() && p2Diff.Item1 >= 0 && p2Diff.Item2 >= 0)
                                antinodes.Add(p2Diff);

                        }
                    }
                }

                Console.WriteLine(antinodes.Distinct().Count());
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().ToList()).ToList();

                Dictionary<char, List<Tuple<int, int>>> positions = new Dictionary<char, List<Tuple<int, int>>>();

                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[0].Count; j++)
                    {
                        if (grid[i][j] == '.') continue;

                        if (positions.ContainsKey(grid[i][j]))
                            positions[grid[i][j]].Add(new Tuple<int, int>(i, j));
                        else
                            positions.Add(grid[i][j], new List<Tuple<int, int>>() { new Tuple<int, int>(i, j) });
                    }
                }

                HashSet<Tuple<int, int>> antinodes = new HashSet<Tuple<int, int>>();

                foreach (var list in positions.Values)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            var p1 = list[i];
                            var p2 = list[j];

                            for (int k = 0; k < grid.Count; k++)
                            {
                                var diff = new Tuple<int, int>(k * (p2.Item1 - p1.Item1), k * (p2.Item2 - p1.Item2));

                                var p1Diff = new Tuple<int, int>(p1.Item1 - diff.Item1, p1.Item2 - diff.Item2);
                                if (p1Diff.Item1 >= 0 && p1Diff.Item2 >= 0 && p1Diff.Item1 < grid.Count && p1Diff.Item2 < grid[p1Diff.Item1].Count())
                                    antinodes.Add(p1Diff);

                                var p2Diff = new Tuple<int, int>(p2.Item1 + diff.Item1, p2.Item2 + diff.Item2);
                                if (p2Diff.Item1 < grid.Count && p2Diff.Item2 < grid[p2Diff.Item1].Count() && p2Diff.Item1 >= 0 && p2Diff.Item2 >= 0)
                                    antinodes.Add(p2Diff);
                            }
                        }
                    }
                }

                Console.WriteLine(antinodes.Distinct().Count());
            }
        }
    }
}
