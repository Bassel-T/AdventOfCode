using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day18
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<List<char>> grid = Enumerable.Range(0, 71).Select(x => Enumerable.Range(0, 71).Select(y => '.').ToList()).ToList();

                var corruptions = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(item =>
                {
                    var split = item.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    return (int.Parse(split[0]), int.Parse(split[1]));
                }).ToList();

                for (int i = 0; i < 1024; i++)
                {
                    var corruption = corruptions[i];
                    grid[corruption.Item1][corruption.Item2] = '#';
                }

                (int x, int y) start = (0, 0);
                (int x, int y) end = (70, 70);

                List<(int dx, int dy)> directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];

                List<List<int>> costs = grid.Select(x => x.Select(y => int.MaxValue).ToList()).ToList();
                costs[start.x][start.y] = 0;

                var queue = new Queue<(int x, int y, int cost, int dir)>();
                queue.Enqueue((start.x, start.y, 0, 1));

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    if (current.cost > costs[current.x][current.y]) { continue; }

                    for (int newDir = 0; newDir < 4; newDir++)
                    {
                        int newX = current.x + directions[newDir].dx;
                        int newY = current.y + directions[newDir].dy;

                        if (newX < 0 || newX > 70 || newY < 0 || newY > 70) continue;

                        if (grid[newX][newY] == '#') continue;

                        int newCost = current.cost + 1;

                        if (newCost < costs[newX][newY])
                        {
                            costs[newX][newY] = newCost;
                            queue.Enqueue((newX, newY, newCost, newDir));
                        }
                    }
                }

                Console.WriteLine(costs[end.x][end.y]);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<List<char>> grid = Enumerable.Range(0, 71).Select(x => Enumerable.Range(0, 71).Select(y => '.').ToList()).ToList();

                var corruptions = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(item =>
                {
                    var split = item.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    return (int.Parse(split[0]), int.Parse(split[1]));
                }).ToList();

                for (int i = 0; i < 1024; i++)
                {
                    var corruption = corruptions[i];
                    grid[corruption.Item1][corruption.Item2] = '#';
                }

                (int x, int y) start = (0, 0);
                (int x, int y) end = (70, 70);

                List<(int dx, int dy)> directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];

                for (int nextCorruption = 1024; nextCorruption < corruptions.Count; nextCorruption++)
                {
                    var next = corruptions[nextCorruption];
                    grid[next.Item1][next.Item2] = '#';

                    List<List<int>> costs = grid.Select(x => x.Select(y => int.MaxValue).ToList()).ToList();
                    costs[start.x][start.y] = 0;

                    var queue = new Queue<(int x, int y, int cost, int dir)>();
                    queue.Enqueue((start.x, start.y, 0, 1));

                    while (queue.Count > 0)
                    {
                        var current = queue.Dequeue();

                        if (current.cost > costs[current.x][current.y]) { continue; }

                        for (int newDir = 0; newDir < 4; newDir++)
                        {
                            int newX = current.x + directions[newDir].dx;
                            int newY = current.y + directions[newDir].dy;

                            if (newX < 0 || newX > 70 || newY < 0 || newY > 70) continue;

                            if (grid[newX][newY] == '#') continue;

                            int newCost = current.cost + 1;

                            if (newCost < costs[newX][newY])
                            {
                                costs[newX][newY] = newCost;
                                queue.Enqueue((newX, newY, newCost, newDir));
                            }
                        }
                    }

                    if (costs[end.x][end.y] == int.MaxValue)
                    {
                        Console.WriteLine($"{next.Item1},{next.Item2}");
                        return;
                    }
                }
            }
        }
    }
}
