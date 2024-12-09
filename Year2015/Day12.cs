using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day12
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var data = reader.ReadToEnd();
                var sum = Regex.Matches(data, "(-?[0-9]+)").Select(x => int.Parse(x.Value)).Sum();
                Console.WriteLine(sum);
            }
        }

        public static void Part2()
        {

        }
    }
}
