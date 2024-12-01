using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day9
    {
        // char - 48 = num

        public static void Part1()
        {
            char[][] input = File.ReadAllLines("Input9.txt").Select(x => x.ToCharArray()).ToArray();
            int total = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                for (int j = 0; j < input[0].Length; ++j)
                {
                    bool min = true;
                    if (i > 0)
                    {
                        min = input[i][j] < input[i - 1][j];
                    }

                    if (i < input.Length - 1)
                    {
                        min = min && input[i][j] < input[i + 1][j];
                    }

                    if (j > 0)
                    {
                        min = min && input[i][j] < input[i][j - 1];
                    }

                    if (j < input[0].Length - 1)
                    {
                        min = min && input[i][j] < input[i][j + 1];
                    }

                    if (min)
                    {
                        total += Convert.ToInt32(input[i][j]) - 47;
                    }
                }
            }

            Console.WriteLine(total);
        }

        public struct Day9Data
        {
            public int size { get; set; }
            public bool[][] check { get; set; }

            public Day9Data(int s, bool[][] c)
            {
                size = s;
                check = c;
            }

            public static Day9Data operator +(Day9Data lhs, Day9Data rhs)
            {
                Day9Data toReturn = new Day9Data(lhs.size + rhs.size, lhs.check);
                for (int i = 0; i < lhs.check.Length; ++i)
                {
                    for (int j = 0; j < lhs.check[0].Length; ++j)
                    {
                        toReturn.check[i][j] = lhs.check[i][j] | rhs.check[i][j];
                    }
                }
                return toReturn;
            }
        }

        public static Day9Data SizeRecursive(int x, int y, char[][] tileWeights, bool[][] tileChecked)
        {
            Day9Data toReturn = new Day9Data(1, tileChecked);

            tileChecked[x][y] = true;
            if (x > 0)
            {
                if (tileWeights[x - 1][y] < '9' && !tileChecked[x - 1][y])
                {
                    toReturn += SizeRecursive(x - 1, y, tileWeights, tileChecked);
                }
            }

            if (y > 0)
            {
                if (tileWeights[x][y - 1] < '9' && !tileChecked[x][y - 1])
                {
                    toReturn += SizeRecursive(x, y - 1, tileWeights, tileChecked);
                }
            }

            if (x < tileChecked.Length - 1)
            {
                if (tileWeights[x + 1][y] < '9' && !tileChecked[x + 1][y])
                {
                    toReturn += SizeRecursive(x + 1, y, tileWeights, tileChecked);
                }
            }

            if (y < tileChecked[0].Length - 1)
            {
                if (tileWeights[x][y + 1] < '9' && !tileChecked[x][y + 1])
                {
                    toReturn += SizeRecursive(x, y + 1, tileWeights, tileChecked);
                }
            }

            return toReturn;
        }

        public static void Part2()
        {
            char[][] input = File.ReadAllLines("Input9.txt").Select(x => x.ToCharArray()).ToArray();
            bool[][] tilesChecked = new bool[input.Length][];
            for (int i = 0, c = input.Length; i < c; ++i)
            {
                tilesChecked[i] = new bool[input[0].Length];
            }

            List<int> sizes = new List<int>();

            for (int i = 0, c = tilesChecked.Length; i < c; ++i)
            {
                for (int j = 0, d = tilesChecked[0].Length; j < d; ++j)
                {
                    if (tilesChecked[i][j] || input[i][j] == '9')
                    {
                        continue;
                    }

                    Day9Data calculated = SizeRecursive(i, j, input, tilesChecked);
                    sizes.Add(calculated.size);
                    tilesChecked = calculated.check;
                    Console.WriteLine($"Found a room of size {calculated.size}!");
                }
            }

            sizes = sizes.OrderByDescending(x => x).ToList();
            Console.WriteLine(sizes[0] * sizes[1] * sizes[2]);
        }
    }
}
