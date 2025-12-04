using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day4
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n").Select(x => x.ToCharArray()).ToArray();
                var answer = 0;

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        if (grid[i][j] != '@') continue;

                        var rolls = 0;

                        for (int m = -1; m < 2; m++)
                        {
                            for (int n = -1; n < 2; n++)
                            {
                                if (m == 0 && n == 0) continue;

                                try
                                {
                                    if (grid[i + m][j + n] == '@') rolls++;
                                }
                                catch (Exception ex)
                                {
                                    // Out of bounds
                                }
                            }
                        }

                        if (rolls < 4) answer++;
                    }
                }

                Console.WriteLine(answer);

            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n").Select(x => x.ToCharArray()).ToArray();
                var answer = 0;

                var removed = new List<(int x, int y)>();

                do
                {
                    removed.Clear();

                    for (int i = 0; i < grid.Length; i++)
                    {
                        for (int j = 0; j < grid[0].Length; j++)
                        {
                            if (grid[i][j] != '@') continue;

                            var rolls = 0;

                            for (int m = -1; m < 2; m++)
                            {
                                for (int n = -1; n < 2; n++)
                                {
                                    if (m == 0 && n == 0) continue;

                                    try
                                    {
                                        if (grid[i + m][j + n] == '@') rolls++;
                                    }
                                    catch (Exception ex)
                                    {
                                        // Out of bounds
                                    }
                                }
                            }

                            if (rolls < 4)
                            {
                                answer++;
                                removed.Add(new(i, j));
                            }
                        }
                    }

                    foreach (var point in removed)
                    {
                        grid[point.x][point.y] = '.';
                    }

                } while (removed.Any());
                Console.WriteLine(answer);

            }
        }
    }
}
