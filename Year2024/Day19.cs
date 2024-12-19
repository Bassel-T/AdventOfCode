using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day19
    {
        private static bool BuildString(string value, List<string> dataset)
        {
            int arraySize = value.Length;
            var canBuildSubstring = new bool[arraySize + 1];
            canBuildSubstring[0] = true;

            for (int i = 0; i < arraySize + 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (canBuildSubstring[j] && dataset.Contains(value.Substring(j, i - j)))
                    {
                        canBuildSubstring[i] = true;
                        break;
                    }
                }
            }

            return canBuildSubstring[arraySize];
        }

        private static long BuildString2(string value, List<string> dataset)
        {
            int arraySize = value.Length;
            var canBuildSubstring = new long[arraySize + 1];
            canBuildSubstring[0] = 1;

            for (int i = 0; i < arraySize + 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dataset.Contains(value.Substring(j, i - j)))
                    {
                        canBuildSubstring[i] += canBuildSubstring[j];
                    }
                }
            }

            return canBuildSubstring[arraySize];
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<string> dataset = reader.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                reader.ReadLine();

                var score = 0;

                while (!reader.EndOfStream)
                    score += BuildString(reader.ReadLine(), dataset) ? 1 : 0;

                Console.WriteLine(score);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<string> dataset = reader.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                reader.ReadLine();

                long score = 0;

                while (!reader.EndOfStream)
                    score += BuildString2(reader.ReadLine(), dataset);

                Console.WriteLine(score);
            }
        }
    }
}
