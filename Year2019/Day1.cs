using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
    public static class Day1
    {
        public static void Part1()
        {
            // Initialize data
            int sum = 0;
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input1.txt")))
            {
                while (!reader.EndOfStream)
                {
                    // Apply math to every line
                    sum += Convert.ToInt32(reader.ReadLine()) / 3 - 2;
                }
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            // Initialize data
            int sum = 0;
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input1.txt")))
            {
                while (!reader.EndOfStream)
                {

                    // Recursively apply math until 0
                    int amount = Convert.ToInt32(reader.ReadLine()) / 3 - 2;
                    while (amount > 0)
                    {
                        sum += amount;
                        amount = amount / 3 - 2;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
