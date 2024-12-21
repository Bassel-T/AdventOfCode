using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day20
    {
        private static int THRESHOLD = 100;

        private static bool IsCheatAvailable((int x, int y, int score) p1, (int x, int y, int score) p2)
        {
            var manhattan = Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y);
            var improvement = p2.score - (p1.score + manhattan);
            return manhattan <= 20 && improvement >= 100;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.TrimEntries).Select(x => x.ToCharArray().ToList()).ToList();
                int score = 0;

                (int x, int y) start = CollectionUtil.FindCoordsInGrid(grid, 'S');
                (int x, int y) end = CollectionUtil.FindCoordsInGrid(grid, 'E');

                List<(int dx, int dy)> directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];

                var originalPathLength = grid.Sum(x => x.Count(y => y == '.'));

                for (int i = 1; i < grid.Count - 1; i++)
                {
                    for (int j = 1; j < grid[0].Count - 1; j++)
                    {
                        if (grid[i][j] == '#')
                        {
                            grid[i][j] = '.';

                            List<List<int>> costs = grid.Select(x => x.Select(y => int.MaxValue).ToList()).ToList();
                            costs[start.x][start.y] = 0;

                            var queue = new Queue<(int x, int y, int cost)>();
                            queue.Enqueue((start.x, start.y, 0));

                            while (queue.Count > 0)
                            {
                                var current = queue.Dequeue();

                                if (current.cost > costs[current.x][current.y]) { continue; }

                                for (int newDir = 0; newDir < 4; newDir++)
                                {
                                    int newX = current.x + directions[newDir].dx;
                                    int newY = current.y + directions[newDir].dy;

                                    if (grid[newX][newY] == '#') continue;

                                    int newCost = current.cost + 1;

                                    if (newCost < costs[newX][newY])
                                    {
                                        costs[newX][newY] = newCost;
                                        queue.Enqueue((newX, newY, newCost));
                                    }
                                }
                            }

                            if (costs[end.x][end.y] <= originalPathLength - THRESHOLD + 1)
                            {
                                score++;
                            }

                            grid[i][j] = '#';
                        }
                    }
                }

                Console.WriteLine(score);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.TrimEntries).Select(x => x.ToCharArray().ToList()).ToList();
                int score = 0;

                (int x, int y) start = CollectionUtil.FindCoordsInGrid(grid, 'S');
                (int x, int y) end = CollectionUtil.FindCoordsInGrid(grid, 'E');

                List<(int dx, int dy)> directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];
                List<(int x, int y, int cost)> path = new List<(int x, int y, int cost)>();

                var originalPathLength = grid.Sum(x => x.Count(y => y == '.'));

                List<List<int>> costs = grid.Select(x => x.Select(y => int.MaxValue).ToList()).ToList();
                costs[start.x][start.y] = 0;

                var queue = new Queue<(int x, int y, int cost)>();
                queue.Enqueue((start.x, start.y, 0));

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    path.Add(current);

                    if (current.cost > costs[current.x][current.y]) { continue; }

                    for (int newDir = 0; newDir < 4; newDir++)
                    {
                        int newX = current.x + directions[newDir].dx;
                        int newY = current.y + directions[newDir].dy;

                        if (grid[newX][newY] == '#') continue;

                        int newCost = current.cost + 1;

                        if (newCost < costs[newX][newY])
                        {
                            costs[newX][newY] = newCost;
                            queue.Enqueue((newX, newY, newCost));
                        }
                    }
                }

                for (int i = 0; i < path.Count; i++)
                {
                    for (int j = i + 1; j < path.Count; j++)
                    {
                        if (IsCheatAvailable(path[i], path[j]))
                        {
                            score++;
                        }
                    }
                }

                Console.WriteLine(score);
            }
        }
    }
}
