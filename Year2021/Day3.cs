using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day3
    {
        public static void Part1()
        {
            string[] binary = File.ReadAllLines("Input3.txt");
            int numLength = binary[0].Length;
            int fileLength = binary.Length;

            int gamma = 0; // Most common occurrence
            int epsilon = 0; // Least common occurrence

            for (int bit = 0; bit < numLength; ++bit, gamma <<= 1, epsilon <<= 1)
            {
                int[] occurrences = new int[2] { 0, 0 };
                for (int line = 0; line < fileLength; ++line)
                {
                    ++occurrences[binary[line][bit] - 48];
                }

                gamma |= Convert.ToInt32(occurrences[0] < occurrences[1]);
                epsilon |= Convert.ToInt32(occurrences[0] > occurrences[1]);
            }

            gamma >>= 1;
            epsilon >>= 1;

            Console.WriteLine("{0}, {1}, {2}", gamma, epsilon, gamma * epsilon);
        }

        public static void Part2()
        {
            string[] binary = File.ReadAllLines("Input3.txt");
            int numLength = binary[0].Length;

            int oxygen = 0;
            // Find gamma
            List<string> bins = binary.ToList();
            for (int bit = 0; bit < numLength; ++bit)
            {
                int[] occurrences = new int[2] { 0, 0 };
                for (int line = 0; line < bins.Count; ++line)
                {
                    ++occurrences[bins[line][bit] - 48];
                }

                if (occurrences[0] <= occurrences[1])
                {
                    bins = bins.Where(x => x[bit] == '1').ToList();
                }
                else
                {
                    bins = bins.Where(x => x[bit] == '0').ToList();
                }

                if (bins.Count == 1)
                {
                    oxygen = Convert.ToInt32(bins[0], 2);
                    break;
                }
            }

            int co2 = 0;
            // Find epsilon
            bins = binary.ToList();
            for (int bit = 0; bit < numLength; ++bit)
            {
                int[] occurrences = new int[2] { 0, 0 };
                for (int line = 0; line < bins.Count; ++line)
                {
                    ++occurrences[bins[line][bit] - 48];
                }

                if (occurrences[0] <= occurrences[1])
                {
                    bins = bins.Where(x => x[bit] == '0').ToList();
                }
                else
                {
                    bins = bins.Where(x => x[bit] == '1').ToList();
                }

                if (bins.Count == 1)
                {
                    co2 = Convert.ToInt32(bins[0], 2);
                    break;
                }
            }

            Console.WriteLine("{0}, {1}, {2}", oxygen, co2, oxygen * co2);
        }
    }
}
