using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day12
    {
        private enum TURN
        {
            LEFT,
            RIGHT
        };

        private static (ulong Area, ulong Perimeter) AreaAndPerimeter(List<List<char>> grid, List<List<bool>> visited, int x, int y)
        {
            ulong area = 0;
            ulong perimeter = 0;

            var scanChar = grid[x][y];

            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            queue.Enqueue((x, y));

            List<(int x, int y)> directions = [(-1, 0), (1, 0), (0, 1), (0, -1)];

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();

                area++;

                foreach (var direction in directions)
                {
                    int dx = point.x + direction.x;
                    int dy = point.y + direction.y;

                    if (dx >= 0 && dy >= 0 && dx < grid.Count && dy < grid[0].Count)
                    {
                        if (grid[dx][dy] == scanChar)
                        {
                            if (!visited[dx][dy])
                            {
                                visited[dx][dy] = true;
                                queue.Enqueue((dx, dy));
                            }
                        }
                        else
                        {
                            perimeter++;
                        }
                    }
                    else
                    {
                        perimeter++;
                    }
                }
            }

            Console.WriteLine($"{scanChar}: {perimeter} * {area} = {perimeter * area}");

            return (area, perimeter);
        }

        private static int index = 0;

        private static ulong Area(List<List<string>> grid, List<List<bool>> visited, int x, int y)
        {
            ulong area = 0;

            var scanChar = grid[x][y];

            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            queue.Enqueue((x, y));

            List<(int x, int y)> directions = [(-1, 0), (1, 0), (0, 1), (0, -1)];
            List<(int x, int y)> corners = [(-1, -1), (1, 1), (-1, 1), (1, -1)];

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                grid[point.x][point.y] = index.ToString();

                area++;

                foreach (var direction in directions)
                {
                    int dx = point.x + direction.x;
                    int dy = point.y + direction.y;

                    if (dx >= 0 && dy >= 0 && dx < grid.Count && dy < grid[0].Count)
                    {
                        if (grid[dx][dy] == scanChar)
                        {
                            if (!visited[dx][dy])
                            {
                                visited[dx][dy] = true;
                                queue.Enqueue((dx, dy));
                            }
                        }
                    }
                }
            }

            return area;
        }

        private static ulong Sides(List<List<string>> grid, string s)
        {
            ulong sides = 0;
            List<List<string>> copy = grid.Select(x => x.Select(y => y).ToList()).ToList();

            copy.Add(new List<string>());

            for (int i = 0; i < copy[0].Count; i++)
            {
                copy.Last().Add("a");
            }

            for (int i = 0; i < copy.Count; i++)
            {
                copy[i].Add("a");
            }

            List<List<bool>> isMatchingChar = copy.Select(x => x.Select(y => false).ToList()).ToList();
            List<List<bool>> previousIsOpposite = copy.Select(x => x.Select(y => false).ToList()).ToList();
            List<List<bool>> isEdgeTracked = copy.Select(x => x.Select(y => false).ToList()).ToList();
            List<List<bool>> isOverall = copy.Select(x => x.Select(y => false).ToList()).ToList();

            for (int j = 0; j < copy[0].Count; j++)
            {
                for (int i = 0; i < copy.Count; i++)
                {
                    isMatchingChar[i][j] = copy[i][j] == s;

                    if (i == 0)
                    {
                        previousIsOpposite[i][j] = copy[i][j] == s;
                    }
                    else
                    {
                        previousIsOpposite[i][j] = isMatchingChar[i][j] != isMatchingChar[i - 1][j];
                    }

                    if (previousIsOpposite[i][j])
                    {
                        if (j == 0)
                        {
                            isEdgeTracked[i][j] = false;
                        }
                        else
                        {
                            isEdgeTracked[i][j] = (isMatchingChar[i][j - 1] == isMatchingChar[i][j]) && (isOverall[i][j - 1] || isEdgeTracked[i][j - 1]);
                        }

                        if (!isEdgeTracked[i][j])
                        {
                            isOverall[i][j] = true;
                        }
                    }
                }
            }

            for (int i = 0; i < copy.Count; i++)
            {
                for (int j = 0; j < copy[i].Count; j++)
                {
                    if (isOverall[i][j])
                        sides++;
                }
            }

            isMatchingChar = copy.Select(x => x.Select(y => false).ToList()).ToList();
            previousIsOpposite = copy.Select(x => x.Select(y => false).ToList()).ToList();
            isEdgeTracked = copy.Select(x => x.Select(y => false).ToList()).ToList();
            isOverall = copy.Select(x => x.Select(y => false).ToList()).ToList();

            for (int i = 0; i < copy.Count; i++)
            {
                for (int j = 0; j < copy[0].Count; j++)
                {
                    isMatchingChar[i][j] = copy[i][j] == s;

                    if (j == 0)
                    {
                        previousIsOpposite[i][j] = copy[i][j] == s;
                    }
                    else
                    {
                        previousIsOpposite[i][j] = isMatchingChar[i][j] != isMatchingChar[i][j - 1];
                    }

                    if (previousIsOpposite[i][j])
                    {
                        if (i == 0)
                        {
                            isEdgeTracked[i][j] = false;
                        }
                        else
                        {
                            isEdgeTracked[i][j] = (isMatchingChar[i - 1][j] == isMatchingChar[i][j]) && (isOverall[i - 1][j] || isEdgeTracked[i - 1][j]);
                        }

                        if (!isEdgeTracked[i][j])
                        {
                            isOverall[i][j] = true;
                        }
                    }
                }
            }

            for (int i = 0; i < copy.Count; i++)
            {
                for (int j = 0; j < copy[i].Count; j++)
                {
                    if (isOverall[i][j])
                        sides++;
                }
            }

            return sides;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().ToList()).ToList();

                var visited = grid.Select(x => x.Select(y => false).ToList()).ToList();

                ulong total = 0;

                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[i].Count; j++)
                    {
                        if (!visited[i][j])
                        {
                            visited[i][j] = true;
                            var region = AreaAndPerimeter(grid, visited, i, j);
                            total += region.Perimeter * region.Area;
                        }
                    }
                }

                Console.WriteLine(total);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().Select(x => x.ToString()).ToList()).ToList();

                var visitedArea = grid.Select(x => x.Select(y => false).ToList()).ToList();
                var visitedSides = grid.Select(x => x.Select(y => false).ToList()).ToList();

                Dictionary<string, ulong> areas = [];
                Dictionary<string, ulong> sides = [];

                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[i].Count; j++)
                    {
                        if (!visitedArea[i][j])
                        {
                            visitedArea[i][j] = true;
                            var area = Area(grid, visitedArea, i, j);
                            areas.Add(grid[i][j], area);
                            index++;
                        }
                    }
                }

                var elements = grid.SelectMany(x => x.Select(y => y)).Distinct().ToList();

                foreach (var element in elements)
                {
                    CollectionUtil.InsertOrIncrement(sides, element, Sides(grid, element));
                }

                Console.WriteLine(string.Join("\r\n", grid.Select(x => string.Join("", x))));

                ulong total = 0;
                foreach (var key in areas.Keys)
                {
                    Console.WriteLine($"{key}, {areas[key]}, {sides[key]}");
                    total += areas[key] * sides[key];
                }

                Console.WriteLine(total);
            }
        }
    }
}
