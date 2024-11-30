using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day5
    {
        public static void Part1()
        {
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input5.txt")))
            {

                int max = 0;

                do
                {
                    // Convert the line to binary
                    string line = reader.ReadLine();
                    line = line.Replace('F', '0').Replace('B', '1').Replace('R', '1').Replace('L', '0');

                    // Find the highest value
                    max = Math.Max(max, Convert.ToInt32(line, 2));

                } while (!reader.EndOfStream);

                Console.WriteLine(max);

            }
        }

        public static void Part2()
        {
            // Initialize false array
            bool[] seats = new bool[1024];

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input5.txt")))
            {
                do
                {
                    string line = reader.ReadLine();
                    line = line.Replace('F', '0').Replace('B', '1').Replace('R', '1').Replace('L', '0');

                    // Set that seat to "true"
                    seats[Convert.ToInt32(line, 2)] = true;

                } while (!reader.EndOfStream);

            }

            // Find first empty seat surrounded by full
            // "1023" is the maximum seat allowed by the user.
            for (int i = 2; i < 1023; i++)
            {
                if (seats[i - 1] && !seats[i] && seats[i + 1])
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}
