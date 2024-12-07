using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day2
    {

        enum FIRST
        {
            A,
            B,
            C
        };

        enum SECOND
        {
            X,
            Y,
            Z
        }

        static Dictionary<FIRST, Dictionary<SECOND, int>> Part1Scores = new Dictionary<FIRST, Dictionary<SECOND, int>>() {
            { FIRST.A, new Dictionary<SECOND, int>() {
                { SECOND.X, 4 },
                { SECOND.Y, 8 },
                { SECOND.Z, 3 }
            } },
            { FIRST.B, new Dictionary<SECOND, int>() {
                { SECOND.X, 1 },
                { SECOND.Y, 5 },
                { SECOND.Z, 9 },
            } },
            { FIRST.C, new Dictionary<SECOND, int>() {
                { SECOND.X, 7 },
                { SECOND.Y, 2 },
                { SECOND.Z, 6 },
            } }
        };

        static Dictionary<FIRST, Dictionary<SECOND, int>> Part2Scores = new Dictionary<FIRST, Dictionary<SECOND, int>>() {
            { FIRST.A, new Dictionary<SECOND, int>() {
                { SECOND.X, 3 },
                { SECOND.Y, 4 },
                { SECOND.Z, 8 }
            } },
            { FIRST.B, new Dictionary<SECOND, int>() {
                { SECOND.X, 1 },
                { SECOND.Y, 5 },
                { SECOND.Z, 9 },
            } },
            { FIRST.C, new Dictionary<SECOND, int>() {
                { SECOND.X, 2 },
                { SECOND.Y, 6 },
                { SECOND.Z, 7 },
            } }
        };

        public static void Part1()
        { // 11449
            var text = File.ReadAllLines("input.txt").Select(x => x.Split(' ').ToList()).ToList();

            var score = 0;

            foreach (var line in text)
            {
                var f = Enum.Parse<FIRST>(line[0]);
                var s = Enum.Parse<SECOND>(line[1]);
                score += Part1Scores[f][s];
            }

            Console.WriteLine(score);

        }

        public static void Part2()
        { //13187
            Console.WriteLine("------------------");

            var text = File.ReadAllLines("input.txt").Select(x => x.Split(' ').ToList()).ToList();
            var score = 0;

            foreach (var line in text)
            {
                var f = Enum.Parse<FIRST>(line[0]);
                var s = Enum.Parse<SECOND>(line[1]);
                score += Part2Scores[f][s];
            }

            Console.WriteLine(score);

        }
    }
}
