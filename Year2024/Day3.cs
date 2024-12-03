using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day3
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var text = reader.ReadToEnd();

                var sum = 0;

                var matches = Regex.Matches(text, @"mul\((\d+),(\d+)\)");
                foreach (Match match in matches)
                {
                    sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }

                Console.WriteLine(sum);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var text = reader.ReadToEnd();

                var sum = 0;
                var enabled = true;

                var matches = Regex.Matches(text, @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)");
                foreach (Match match in matches)
                {
                    if (match.Groups[0].Value == "do()") enabled = true;
                    else if (match.Groups[0].Value == "don't()") enabled = false;
                    else if (enabled) sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }

                Console.WriteLine(sum);
            }
        }
    }
}
