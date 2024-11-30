using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day24
    {
        private static bool[,] NextIteration(bool[,] data)
        {
            bool[,] toReturn = new bool[data.GetLength(0), data.GetLength(1)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    int neighbors = GetNeighbors(data, i, j);

                    if (data[i, j] && (neighbors == 0 || neighbors > 2))
                    {
                        toReturn[i, j] = false;
                    }
                    else if (!data[i, j] && neighbors == 2)
                    {
                        toReturn[i, j] = true;
                    }
                }
            }

            return toReturn;
        }

        private static int GetNeighbors(bool[,] data, int x, int y)
        {
            int toReturn = 0;

            try
            {
                if (data[x + 1, y])
                {
                    toReturn++;
                }
            }
            catch (Exception e)
            {

            }

            try
            {
                if (data[x - 1, y])
                {
                    toReturn++;
                }
            }
            catch (Exception e)
            {

            }

            if (y % 2 == 0)
            {
                try
                {
                    if (data[x - 1, y + 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (data[x, y + 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (data[x - 1, y - 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e) { }

                try
                {
                    if (data[x, y - 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e) { }
            }
            else
            {
                try
                {
                    if (data[x, y + 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e) { }

                try
                {
                    if (data[x + 1, y + 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e) { }

                try
                {
                    if (data[x, y - 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e) { }

                try
                {
                    if (data[x + 1, y - 1])
                    {
                        toReturn++;
                    }
                }
                catch (Exception e) { }
            }

            return toReturn;
        }

        public static bool[,] Part1()
        {
            bool[,] tiles = new bool[300, 300];
            int count = 0;

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input24.txt")))
            {
                while (!reader.EndOfStream)
                {
                    int x = 100;
                    int y = 100;

                    string line = reader.ReadLine();

                    for (int i = 0; i < line.Length; i++)
                    {
                        string tile = line[i].ToString();

                        if (tile == "s" || tile == "n")
                        {
                            i++;
                            tile += line[i].ToString();
                        }

                        if (tile == "e")
                        {
                            x++;
                        }

                        if (tile == "w")
                        {
                            x--;
                        }

                        if (y % 2 == 0)
                        {
                            if (tile == "nw")
                            {
                                y++;
                                x--;
                            }
                            else if (tile == "ne")
                            {
                                y++;
                            }
                            else if (tile == "sw")
                            {
                                x--;
                                y--;
                            }
                            else if (tile == "se")
                            {
                                y--;
                            }
                        }
                        else
                        {
                            if (tile == "nw")
                            {
                                y++;
                            }
                            else if (tile == "ne")
                            {
                                y++;
                                x++;
                            }
                            else if (tile == "sw")
                            {
                                y--;
                            }
                            else if (tile == "se")
                            {
                                y--;
                                x++;
                            }
                        }

                    }

                    tiles[x, y] = !tiles[x, y];

                    if (tiles[x, y])
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                    }
                }

            }

            Console.WriteLine($"Part 1 {count}");
            return tiles;
        }

        public static void Part2()
        {
            bool[,] tiles = Part1();
            int ITERATIONS = 100;

            for (int i = 0; i < ITERATIONS; i++)
            {
                tiles = NextIteration(tiles);
            }

            int count = 0;

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"Part 2: {count}");
        }
    }
}
