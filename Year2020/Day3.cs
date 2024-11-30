using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day3
    {
        public static void Part1()
        {
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input3.txt")))
            {
                int row = 0;
                int trees = 0;

                do
                {
                    string line = reader.ReadLine();

                    if (line.Substring((row * 3) % line.Length, 1) == "#")
                    {
                        trees++;
                    }
                    row++;
                } while (!reader.EndOfStream);

                Console.WriteLine(trees);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input3.txt")))
            {
                int[] trees = new int[5] { 0, 0, 0, 0, 0 };

                // Row variable
                int i = 0;

                do
                {
                    string line = reader.ReadLine();

                    // Right 1, Down 1
                    if (line.Substring(i % line.Length, 1) == "#")
                    {
                        trees[0]++;
                    }

                    // Right 3, Down 1
                    if (line.Substring((i * 3) % line.Length, 1) == "#")
                    {
                        trees[1]++;
                    }

                    // Right 5, Down 1
                    if (line.Substring((i * 5) % line.Length, 1) == "#")
                    {
                        trees[2]++;
                    }

                    // Right 7, Down 1
                    if (line.Substring((i * 7) % line.Length, 1) == "#")
                    {
                        trees[3]++;
                    }

                    // Right 1, Down 2
                    if (i % 2 == 0)
                    {
                        if (line.Substring((i / 2) % line.Length, 1) == "#")
                        {
                            trees[4]++;
                        }
                    }

                    i++;
                } while (!reader.EndOfStream);

                // Calculate the product
                ulong prod = (ulong)trees[0];
                for (i = 1; i < trees.Length; i++)
                {
                    prod *= (ulong)trees[i];
                }

                Console.WriteLine(prod);
            }
        }
    }
}
