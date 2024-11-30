using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day17
    {
        private static int CountNeighbors1(bool[,,] grid, int x, int y, int z)
        {
            int neighbors = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    for (int k = z - 1; k <= z + 1; k++)
                    {
                        if (i == x && j == y && k == z)
                        {
                            continue;
                        }
                        if (grid[i, j, k])
                        {
                            neighbors++;
                        }
                    }
                }
            }

            return neighbors;
        }

        public static void Part1()
        {
            bool[,,] grid = new bool[100, 100, 100];
            int smallZ = 49;
            int bigZ = 51;
            int smallDim = 46;
            int bigDim = 54;

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input17.txt")))
            {
                for (int i = 47; i < 54; i++)
                {
                    string input = reader.ReadLine();
                    for (int j = 47; j < 54; j++)
                    {
                        if (input.Substring(j - 47, 1) == "#")
                        {
                            grid[i, j, 50] = true;
                        }
                    }
                }
            }

            for (int v = 0; v < 6; v++)
            {
                bool[,,] newGrid = new bool[100, 100, 100];
                for (int i = smallDim - v; i < bigDim + v; i++)
                {
                    for (int j = smallDim - v; j < bigDim + v; j++)
                    {
                        for (int k = smallZ - v; k < bigZ + v; k++)
                        {
                            int neighbors = CountNeighbors1(grid, i, j, k);
                            if (!grid[i, j, k] && neighbors == 3)
                            {
                                newGrid[i, j, k] = true;
                            }
                            else if (grid[i, j, k] && (neighbors == 2 || neighbors == 3))
                            {
                                newGrid[i, j, k] = true;
                            }
                            else
                            {
                                newGrid[i, j, k] = false;
                            }
                        }
                    }
                }
                grid = newGrid;
            }

            int count = 0;
            for (int i = smallDim - 7; i < bigDim + 7; i++)
            {
                for (int j = smallDim - 7; j < bigDim + 7; j++)
                {
                    for (int k = smallZ - 7; k < bigZ + 7; k++)
                    {
                        if (grid[i, j, k])
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            // Where did this go??? I have the star???
        }
    }
}
