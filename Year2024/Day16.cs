using AdventOfCode.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day16
    {   
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.TrimEntries).Select(x => x.ToCharArray().ToList()).ToList();

                (int x, int y) start = CollectionUtil.FindCoordsInGrid(grid, 'S');
                (int x, int y) end = CollectionUtil.FindCoordsInGrid(grid, 'E');

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

                        if (grid[newX][newY] == '#') continue;

                        int turn = (newDir == current.dir) ? 0 : 1000;
                        int newCost = current.cost + 1 + turn;

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

        // There is a BUG in my logic. I will come back to it.
        // I took the output of this and found the wrong pieces manually in Notepad++
        // It took all of three minutes
        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.TrimEntries).Select(x => x.ToCharArray().ToList()).ToList();

                (int x, int y) start = CollectionUtil.FindCoordsInGrid(grid, 'S');
                (int x, int y) end = CollectionUtil.FindCoordsInGrid(grid, 'E');

                List<(int dx, int dy)> directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];

                List<List<int>> costs = grid.Select(x => x.Select(y => int.MaxValue).ToList()).ToList();
                List<List<int>> depths = grid.Select(x => x.Select(y => -1).ToList()).ToList();

                Dictionary<(int x, int y), List<(int x, int y)>> parents = new Dictionary<(int x, int y), List<(int x, int y)>>();

                var queue = new Stack<(int x, int y, int cost, int dir)>();
                queue.Push((start.x, start.y, 0, 1));
                costs[start.x][start.y] = 0;
                depths[start.x][start.y] = 0;

                while (queue.Count > 0)
                {
                    var current = queue.Pop();

                    if (current.cost > costs[current.x][current.y]) { continue; }

                    for (int newDir = 0; newDir < 4; newDir++)
                    {
                        int newX = current.x + directions[newDir].dx;
                        int newY = current.y + directions[newDir].dy;

                        if (grid[newX][newY] == '#') continue;

                        int turn = (newDir == current.dir) ? 0 : 1000;
                        int newCost = current.cost + 1 + turn;

                        if (newCost < costs[newX][newY])
                        {
                            costs[newX][newY] = newCost;
                            queue.Push((newX, newY, newCost, newDir));
                            depths[newX][newY] = depths[current.x][current.y] + 1;
                            CollectionUtil.InsertOrAppend(parents, (newX, newY), (current.x, current.y));
                        }
                        else if (newCost == costs[newX][newY])
                        {
                            depths[newX][newY] = depths[current.x][current.y] + 1;
                            CollectionUtil.InsertOrAppend(parents, (newX, newY), (current.x, current.y));
                        }
                    }
                }

                var parentQueue = new Queue<(int x, int y)>();
                var visited = new List<(int x, int y)>();

                parentQueue.Enqueue(end);

                var paths = 0;

                while (parentQueue.Count > 0)
                {
                    var current = parentQueue.Dequeue();

                    var currCost = depths[current.x][current.y];
                    paths++;
                    visited.Add((current.x, current.y));

                    if (current == start) continue;

                    foreach (var dir in directions)
                    {
                        var newX = current.x + dir.dx;
                        var newY = current.y + dir.dy;

                        if (depths[current.x][current.y] == depths[newX][newY] + 1
                            && (costs[current.x][current.y] == costs[newX][newY] + 1
                                || costs[current.x][current.y] == costs[newX][newY] + 1001
                                || costs[current.x][current.y] == costs[newX][newY] - 999))
                        {
                            parentQueue.Enqueue((newX, newY));
                        } 
                    }
                }

                var newGrid = grid.Select((row, i) => row.Select((col, j) =>
                {
                    if (grid[i][j] == '#') return "#";

                    if (visited.Contains((i, j))) return "O";

                    return ".";//return (depths[i][j] % 10).ToString();
                }));

                Console.WriteLine(string.Join("\r\n", newGrid.Select(x => string.Join("", x))));

                Console.WriteLine(visited.Distinct().Count());
            }
        }
    }
}
