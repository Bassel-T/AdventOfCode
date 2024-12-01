using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day8
    {
        public static void Part1()
        {
            string[] input = File.ReadAllLines("Input8.txt");
            int[] valid = new int[] { 2, 4, 3, 7 };
            int count = 0;
            foreach (string line in input)
            {
                string[] code = line.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string digit in code)
                {
                    int segments = digit.Length;
                    if (valid.Contains(segments))
                    {
                        ++count;
                    }
                }
            }

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            string[] input = File.ReadAllLines("Input8.txt");
            string[] charToNum = new string[] {
                "abcefg",
                "cf",
                "acdeg",
                "acdfg",
                "bcdf",
                "abdfg",
                "abdefg",
                "acf",
                "abcdefg",
                "abcdfg"
            };
            int total = 0;
            foreach (string line in input)
            {
                string[] code = line.Split('|');

                /*  Decode it using rules:
					B is in 6 numbers.
					E is in 4.
					F is in 9.
		
					C is whatever remains in 1.
					A is whatever remains in 7.
					D is whatever remains in 4.
					G is the last one.
				*/

                Dictionary<char, int> counts = new Dictionary<char, int>() {
                    {'a', 0 },
                    {'b', 0 },
                    {'c', 0 },
                    {'d', 0 },
                    {'e', 0 },
                    {'f', 0 },
                    {'g', 0 }
                };

                Dictionary<char, char> shifts = new Dictionary<char, char>();

                for (int i = 0; i < counts.Count; ++i)
                {
                    char key = counts.ElementAt(i).Key;
                    counts[key] = code[0].Count(x => x == key);
                    if (counts[key] == 6)
                    {
                        shifts[key] = 'b';
                    }
                    else if (counts[key] == 4)
                    {
                        shifts[key] = 'e';
                    }
                    else if (counts[key] == 9)
                    {
                        shifts[key] = 'f';
                    }
                }

                string[] encrypted = code[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                shifts[(encrypted.Where(x => x.Count() == 2)).First().ToArray<char>().Except(shifts.Keys).First()] = 'c';
                shifts[(encrypted.Where(x => x.Count() == 3)).First().ToArray<char>().Except(shifts.Keys).First()] = 'a';
                shifts[(encrypted.Where(x => x.Count() == 4)).First().ToArray<char>().Except(shifts.Keys).First()] = 'd';
                shifts[counts.Keys.ToArray().Except((shifts.Keys).ToArray()).First()] = 'g';

                string digits = code[1];
                string shiftedDigit = "";

                for (int i = 0, c = digits.Length; i < c; ++i)
                {
                    if (digits[i] == ' ')
                    {
                        shiftedDigit += ' ';
                        continue;
                    }

                    shiftedDigit += shifts[digits[i]];
                }

                char[][] splitShift = shiftedDigit
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToCharArray())
                    .ToArray();

                int curr = 0;
                for (int i = 0, l = splitShift.Length; i < l; ++i)
                {
                    Array.Sort(splitShift[i]);
                }

                List<int> nums = splitShift.ToList().Select(x => Array.IndexOf(charToNum, string.Concat(x))).ToList();

                foreach (int i in nums)
                {
                    curr = curr * 10 + i;
                }

                total += curr;
            }

            Console.WriteLine(total);
        }
    }
}
