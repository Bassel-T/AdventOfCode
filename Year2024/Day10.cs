using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day10
    {
        private static List<(int x, int y)> GetNeighbors(int x, int y, List<List<char>> grid)
        {
            List<(int x, int y)> neighbors = new List<(int x, int y)>();

            if (x > 0)
            {
                neighbors.Add((x - 1, y));
            }

            if (y > 0)
            {
                neighbors.Add((x, y - 1));
            }

            if (x < grid.Count - 1)
            {
                neighbors.Add((x + 1, y));
            }

            if (y < grid[0].Count - 1)
            {
                neighbors.Add((x, y + 1));
            }

            return neighbors;
        }

        private static int Traverse(int x, int y, List<List<char>> grid)
        {
            List<List<bool>> visited = grid.Select(x => x.Select(y => false).ToList()).ToList();

            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            queue.Enqueue((x, y));

            int score = 0;

            while (queue.Any())
            {
                var curr = queue.Dequeue();

                var neighbors = GetNeighbors(curr.x, curr.y, grid);
                foreach (var neighbor in neighbors)
                {
                    if (!visited[neighbor.x][neighbor.y] && grid[neighbor.x][neighbor.y] == grid[curr.x][curr.y] + 1)
                    {
                        visited[neighbor.x][neighbor.y] = true;
                        queue.Enqueue((neighbor.x, neighbor.y));

                        if (grid[neighbor.x][neighbor.y] == '9')
                        {
                            score++;
                        }
                    }
                }
            }

            return score;
        }

        private static int TraversePart2(int x, int y, List<List<char>> grid)
        {
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            queue.Enqueue((x, y));

            int score = 0;

            while (queue.Any())
            {
                var curr = queue.Dequeue();

                var neighbors = GetNeighbors(curr.x, curr.y, grid);
                foreach (var neighbor in neighbors)
                {
                    if (grid[neighbor.x][neighbor.y] == grid[curr.x][curr.y] + 1)
                    {
                        queue.Enqueue((neighbor.x, neighbor.y));

                        if (grid[neighbor.x][neighbor.y] == '9')
                        {
                            score++;
                        }
                    }
                }
            }

            return score;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var score = 0;

                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().ToList()).ToList();

                List<(int x, int y)> trailheadCandidates = grid
                    .SelectMany((row, x) => row
                        .Select((val, y) => new { Value = val, X = x, Y = y })
                        .Where(item => item.Value == '0'))
                    .Select(item => (item.X, item.Y))
                    .ToList();

                foreach (var candidate in trailheadCandidates)
                {
                    score += Traverse(candidate.x, candidate.y, grid);
                }

                Console.WriteLine(score);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var score = 0;

                var grid = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().ToList()).ToList();

                List<(int x, int y)> trailheadCandidates = grid
                    .SelectMany((row, x) => row
                        .Select((val, y) => new { Value = val, X = x, Y = y })
                        .Where(item => item.Value == '0'))
                    .Select(item => (item.X, item.Y))
                    .ToList();

                foreach (var candidate in trailheadCandidates)
                {
                    score += TraversePart2(candidate.x, candidate.y, grid);
                }

                Console.WriteLine(score);
            }
        }
    }
}
