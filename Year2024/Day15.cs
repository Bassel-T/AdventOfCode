using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day15
    {
        public static void Part1()
        {

        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var input = reader.ReadToEnd().Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

                var mapping = new Dictionary<char, string>()
                {
                    { '#', "##" },
                    { '.', ".." },
                    { 'O', "[]" },
                    { '@', "@." },
                    { '\r', "\r" },
                    { '\n', "\n" }
                };

                var grid = input[0].Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => string.Join("", x.Select(y => mapping[y])).ToCharArray().ToList())
                                    .ToList();

                var directions = new Dictionary<char, (int X, int Y)>
                {
                    { '^', (-1, 0) },
                    { 'v', (1, 0) },
                    { '<', (0, -1) },
                    { '>', (0, 1) }
                };

                var moves = string.Join("", input[1].Split("\r\n", StringSplitOptions.RemoveEmptyEntries));

                (int robotX, int robotY) = CollectionUtil.FindCoordsInGrid(grid, '@');

                foreach (var move in moves)
                {
                    var dir = directions[move];

                    int newX = robotX + dir.X;
                    int newY = robotY + dir.Y;

                    List<(int x, int y)> movePositions = new List<(int x, int y)>();

                    if (CanMove(grid, newX, newY, dir.X, dir.Y, movePositions))
                    {
                        //List<List<bool>> visited = grid.Select(x => x.Select(y => false).ToList()).ToList();

                        //Move(grid, newX, newY, dir.X, dir.Y, visited);

                        movePositions = movePositions.OrderByDescending(item => Math.Abs(item.y - robotY) + Math.Abs(item.x - robotX)).ToList();

                        foreach (var item in movePositions)
                        {
                            grid[item.x + dir.X][item.y + dir.Y] = grid[item.x][item.y];
                            grid[item.x][item.y] = '.';
                        }

                        grid[newX][newY] = '@';
                        grid[robotX][robotY] = '.';
                        robotX = newX;
                        robotY = newY;
                    }
                }

                ulong score = 0;
                for (int i =0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[0].Count; j++)
                    {
                        if (grid[i][j] == '[')
                            score += (ulong)(100 * i + j);
                    }
                }

                Console.WriteLine(score);
            }
        }

        private static void Move(List<List<char>> grid, int x, int y, int dx, int dy, List<List<bool>> visited)
        {
            if (grid[x][y] == '#') return;
            if (grid[x][y] == '.') return;

            int nextX = x + dx;
            int nextY = y + dy;

            visited[x][y] = true;

            if (dx == 0 & !visited[nextX][nextY])
            {
                Move(grid, x, nextY, dx, dy, visited);
            }
            else if (grid[x][y] == '[')
            {
                if (!visited[nextX][nextY])
                    Move(grid, nextX, nextY, dx, dy, visited);

                if (!visited[nextX][nextY + 1])
                    Move(grid, nextX, nextY + 1, dx, dy, visited);
            }
            else if (grid[x][y] == ']')
            {
                if (!visited[nextX][nextY])
                    Move(grid, nextX, nextY, dx, dy, visited);
                
                if (!visited[nextX][nextY - 1])
                    Move(grid, nextX, nextY - 1, dx, dy, visited);
            }

            if (grid[nextX][nextY] == '.')
            {
                grid[nextX][nextY] = grid[x][y];
                grid[x][y] = '.';
            }
        }

        private static bool CanMove(List<List<char>> grid, int x, int y, int dx, int dy, List<(int x, int y)> movePositions)
        {
            if (grid[x][y] == '#') return false;
            if (grid[x][y] == '.') return true;

            int nextX = x + dx;
            int nextY = y + dy;

            if (!movePositions.Contains((x, y)))
                movePositions.Add((x, y));

            if (dx == 0){ return CanMove(grid, x, nextY, dx, dy, movePositions); }
            
            if (grid[x][y] == '[')
            {
                if (!movePositions.Contains((x, y + 1)))
                    movePositions.Add((x, y + 1));
                return CanMove(grid, nextX, nextY, dx, dy, movePositions) && CanMove(grid, nextX, nextY + 1, dx, dy, movePositions);
            }

            if (!movePositions.Contains((x, y - 1)))
                movePositions.Add((x, y - 1));
            return CanMove(grid, nextX, nextY, dx, dy, movePositions) && CanMove(grid, nextX, nextY - 1, dx, dy, movePositions);
        }

        private static string PrintGrid(List<List<char>> grid) => string.Join("\r\n", grid.Select(x => string.Join("", x)));
    }
}
