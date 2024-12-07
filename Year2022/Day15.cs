using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day15
    {

        public static Regex number = new Regex(@"[0-9]+");

        public static void Part1()
        {
            // Sonar at x=? y=? found nearest beacon at x=? y=?
            var input = File.ReadAllLines("Inputs.txt").Select(x => number.Matches(x).Select(y => int.Parse(y.Value)).ToList()).ToList();

            var manhattanDistances = input.Select(x => Math.Abs(x[0] - x[2]) + Math.Abs(x[1] - x[3])).ToList();
            var spacesAt2M = manhattanDistances.Select(x => Math.Abs(2000000 - x)).ToList();
        }

        public static void Part2()
        {

        }

    }
}
