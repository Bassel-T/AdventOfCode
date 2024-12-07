using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
    public static class Day2
    {
        public static void Part1()
        {
            // Read user input
            int[] data = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input2.txt"))
                .Split(',')
                .Select(x => int.Parse(x))
                .ToArray();
            data[1] = 12;
            data[2] = 2;

            for (int i = 0; i < data.Length && data[i] != 99; i += 4)
            {
                // Read int-code until 99 or out of range
                if (data[i] == 1)
                {
                    // Add values at positions
                    data[data[i + 3]] = data[data[i + 2]] + data[data[i + 1]];
                }
                else if (data[i] == 2)
                {
                    // Multiply values at positions
                    data[data[i + 3]] = data[data[i + 2]] * data[data[i + 1]];
                }
            }

            Console.WriteLine(data[0]);
        }

        public static void Part2()
        {
            // Read user input
            int[] input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input2.txt"))
                .Split(',')
                .Select(x => int.Parse(x))
                .ToArray();

            for (int x = 0; x < 99; x++)
            {
                for (int y = 0; y < 99; y++)
                {
                    // Brute-force all values
                    int[] data = (int[])input.Clone();
                    data[1] = x;
                    data[2] = y;

                    for (int i = 0; i < data.Length && data[i] != 99; i += 4)
                    {
                        // Read int-code until 99 or out of range
                        if (data[i] == 1)
                        {
                            // Add values at positions
                            data[data[i + 3]] = data[data[i + 2]] + data[data[i + 1]];
                        }
                        else if (data[i] == 2)
                        {
                            // Multiply values at positions
                            data[data[i + 3]] = data[data[i + 2]] * data[data[i + 1]];
                        }
                    }

                    if (data[0] == 19690720)
                    {
                        Console.WriteLine(100 * x + y);
                        return;
                    }
                }
            }

        }
    }
}
