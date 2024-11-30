using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day1
    {
        public static int desired = 2020;

        public static void Part1()
        {
            List<int> numbers = new List<int>();

            // Get the information from the file
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input1.txt")))
            {
                while (!reader.EndOfStream)
                {
                    int val = Convert.ToInt32(reader.ReadLine());
                    numbers.Add(val);
                }
            }

            // Sort the array
            numbers.Sort();

            // Create a boolean array of all acceptable values
            bool[] arr = new bool[numbers[numbers.Count - 1] + 1];
            foreach (int i in numbers)
            {
                arr[i] = true;
            }

            foreach (int i in numbers)
            {
                if (arr[desired - i])
                {
                    // Look-up table
                    Console.WriteLine(i * (desired - i));
                    return;
                }
            }
        }

        public static void Part2()
        {
            List<int> numbers = new List<int>();

            // Get the information from the file
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input1.txt")))
            {
                while (!reader.EndOfStream)
                {
                    int val = Convert.ToInt32(reader.ReadLine());
                    numbers.Add(val);
                }
            }

            // Sort in increasing order
            numbers.Sort();

            // Create a boolean array of all acceptable values
            bool[] arr = new bool[numbers[numbers.Count - 1] + 1];
            foreach (int i in numbers)
            {
                arr[i] = true;
            }

            foreach (int i in numbers)
            {
                foreach (int j in numbers)
                {
                    if (i + j >= desired)
                    {
                        // Skip all remainder values of j
                        break;
                    }

                    if (arr[desired - i - j])
                    {
                        // Look-up table
                        Console.WriteLine(i * j * (desired - i - j));
                        return;
                    }
                }
            }
        }
    }
}
