using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day5
    {
        private static bool NoSequence(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                switch (input.Substring(i, 2))
                {
                    case "ab":
                    case "cd":
                    case "pq":
                    case "xy":
                        return false;
                }
            }

            return true;
        }

        public static void Part1()
        {
            int count = 0;
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input5.txt"));

            foreach (string l in lines)
            {
                if (l.Where(x => new char[] { 'a', 'e', 'i', 'o', 'u' }.Contains(x)).Count() > 2
                    && Regex.IsMatch(l, @"(\w)\1+")
                    && NoSequence(l))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            int count = 0;
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input5.txt"));

            foreach (string l in lines)
            {
                if (Regex.IsMatch(l, @"(\w\w)(.?)*(\1+)")
                    && Regex.IsMatch(l, @"(\w).\1+"))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
