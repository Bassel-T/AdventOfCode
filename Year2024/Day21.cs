using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode.Year2024
{
    public static class Day21
    {
        private static List<List<char>> keypad = new List<List<char>>()
        {
            new() { '7', '8', '9'},
            new() { '4', '5', '6'},
            new() { '1', '2', '3'},
            new() { '.', '0', 'A'}
        };

        private static List<List<char>> controller = new List<List<char>>()
        {
            new() { '.', '^', 'A' },
            new() { '<', 'v', '>'}
        };

        // "Given how few the robot direction buttons are, there aren't many total possible paths"
        private static Dictionary<(char start, char end), List<string>> allPaths = new()
        {
            {('0', '0'),[""]},
            {('0', '1'),["^<"]},
            {('1', '0'),[">v"]},
            {('0', '2'),["^"]},
            {('2', '0'),["v"]},
            {('0', '3'),[">^","^>"]},
            {('3', '0'),["v<","<v"]},
            {('0', '4'),["^^<","^<^"]},
            {('4', '0'),[">vv","v>v"]},
            {('0', '5'),["^^"]},
            {('5', '0'),["vv"]},
            {('0', '6'),["^^>",">^^","^>^"]},
            {('6', '0'),["<vv","vv<","v<v"]},
            {('0', '7'),["^^<^","^<^^","^^^<"]},
            {('7', '0'),["v>vv","vv>v",">vvv"]},
            {('0', '8'),["^^^"]},
            {('8', '0'),["vvv"]},
            {('0', '9'),["^^>^",">^^^","^>^^","^^^>"]},
            {('9', '0'),["v<vv","vvv<","vv<v","<vvv"]},
            {('0', 'A'),[">"]},
            {('A', '0'),["<"]},
            {('1', '1'),[""]},
            {('1', '2'),[">"]},
            {('2', '1'),["<"]},
            {('1', '3'),[">>"]},
            {('3', '1'),["<<"]},
            {('1', '4'),["^"]},
            {('4', '1'),["v"]},
            {('1', '5'),[">^","^>"]},
            {('5', '1'),["v<","<v"]},
            {('1', '6'),[">^>","^>>",">>^"]},
            {('6', '1'),["<v<","<<v","v<<"]},
            {('1', '7'),["^^"]},
            {('7', '1'),["vv"]},
            {('1', '8'),["^^>",">^^","^>^"]},
            {('8', '1'),["<vv","vv<","v<v"]},
            {('1', '9'),[">^>^","^>>^",">>^^","^^>>",">^^>","^>^>"]},
            {('9', '1'),["v<v<","v<<v","vv<<","<<vv","<vv<","<v<v"]},
            {('1', 'A'),[">v>",">>v"]},
            {('A', '1'),["<^<","^<<"]},
            {('2', '2'),[""]},
            {('2', '3'),[">"]},
            {('3', '2'),["<"]},
            {('2', '4'),["^<","<^"]},
            {('4', '2'),[">v","v>"]},
            {('2', '5'),["^"]},
            {('5', '2'),["v"]},
            {('2', '6'),[">^","^>"]},
            {('6', '2'),["v<","<v"]},
            {('2', '7'),["^<^","<^^","^^<"]},
            {('7', '2'),["v>v","vv>",">vv"]},
            {('2', '8'),["^^"]},
            {('8', '2'),["vv"]},
            {('2', '9'),[">^^","^>^","^^>"]},
            {('9', '2'),["vv<","v<v","<vv"]},
            {('2', 'A'),[">v","v>"]},
            {('A', '2'),["^<","<^"]},
            {('3', '3'),[""]},
            {('3', '4'),["<^<","^<<","<<^"]},
            {('4', '3'),[">v>",">>v","v>>"]},
            {('3', '5'),["<^","^<"]},
            {('5', '3'),["v>",">v"]},
            {('3', '6'),["^"]},
            {('6', '3'),["v"]},
            {('3', '7'),["<^<^","^<<^","<<^^","^^<<","<^^<","^<^<"]},
            {('7', '3'),["v>v>","v>>v","vv>>",">>vv",">vv>",">v>v"]},
            {('3', '8'),["^^<","<^^","^<^"]},
            {('8', '3'),[">vv","vv>","v>v"]},
            {('3', '9'),["^^"]},
            {('9', '3'),["vv"]},
            {('3', 'A'),["v"]},
            {('A', '3'),["^"]},
            {('4', '4'),[""]},
            {('4', '5'),[">"]},
            {('5', '4'),["<"]},
            {('4', '6'),[">>"]},
            {('6', '4'),["<<"]},
            {('4', '7'),["^"]},
            {('7', '4'),["v"]},
            {('4', '8'),[">^","^>"]},
            {('8', '4'),["v<","<v"]},
            {('4', '9'),[">^>","^>>",">>^"]},
            {('9', '4'),["<v<","<<v","v<<"]},
            {('4', 'A'),[">v>v","v>>v",">>vv",">vv>","v>v>"]},
            {('A', '4'),["^<^<","^<<^","^^<<","<^^<","<^<^"]},
            {('5', '5'),[""]},
            {('5', '6'),[">"]},
            {('6', '5'),["<"]},
            {('5', '7'),["^<","<^"]},
            {('7', '5'),[">v","v>"]},
            {('5', '8'),["^"]},
            {('8', '5'),["v"]},
            {('5', '9'),[">^","^>"]},
            {('9', '5'),["v<","<v"]},
            {('5', 'A'),["vv>",">vv","v>v"]},
            {('A', '5'),["<^^","^^<","^<^"]},
            {('6', '6'),[""]},
            {('6', '7'),["<^<","^<<","<<^"]},
            {('7', '6'),[">v>",">>v","v>>"]},
            {('6', '8'),["<^","^<"]},
            {('8', '6'),["v>",">v"]},
            {('6', '9'),["^"]},
            {('9', '6'),["v"]},
            {('6', 'A'),["vv"]},
            {('A', '6'),["^^"]},
            {('7', '7'),[""]},
            {('7', '8'),[">"]},
            {('8', '7'),["<"]},
            {('7', '9'),[">>"]},
            {('9', '7'),["<<"]},
            {('7', 'A'),[">v>vv","v>>vv",">>vvv",">vv>v","v>v>v","vv>>v",">vvv>","v>vv>","vv>v>"]},
            {('A', '7'),["^^<^<","^^<<^","^^^<<","^<^^<","^<^<^","^<<^^","<^^^<","<^^<^","<^<^^"]},
            {('8', '8'),[""]},
            {('8', '9'),[">"]},
            {('9', '8'),["<"]},
            {('8', 'A'),["vv>v",">vvv","v>vv","vvv>"]},
            {('A', '8'),["^<^^","^^^<","^^<^","<^^^"]},
            {('9', '9'),[""]},
            {('9', 'A'),["vvv"]},
            {('A', '9'),["^^^"]},
            {('<', '<'),[""]},
            {('<', '^'),[">^"]},
            {('^', '<'),["v<"]},
            {('<', '>'),[">>"]},
            {('>', '<'),["<<"]},
            {('<', 'v'),[">"]},
            {('v', '<'),["<"]},
            {('<', 'A'),[">^>",">>^"]},
            {('A', '<'),["<v<","v<<"]},
            {('^', '^'),[""]},
            {('^', '>'),[">v","v>"]},
            {('>', '^'),["^<","<^"]},
            {('^', 'v'),["v"]},
            {('v', '^'),["^"]},
            {('^', 'A'),[">"]},
            {('A', '^'),["<"]},
            {('>', '>'),[""]},
            {('>', 'v'),["<"]},
            {('v', '>'),[">"]},
            {('>', 'A'),["^"]},
            {('A', '>'),["v"]},
            {('v', 'v'),[""]},
            {('v', 'A'),[">^","^>"]},
            {('A', 'v'),["v<","<v"]},
            {('A', 'A'),[""]}
        };

        private static Dictionary<(int depth, string path), long> cache = new();

        // Get all possible paths for this loop
        private static List<string> GetAllPaths(string value)
        {
            List<string> paths = [""];
            char curr = 'A';

            foreach (var tile in value)
            {
                var newList = new List<string>();
                var nextMoves = allPaths[(curr, tile)];
                foreach (var path in paths)
                {
                    foreach (var move in nextMoves)
                    {
                        newList.Add(path + move + 'A');
                    }
                }

                curr = tile;
                paths = newList;
            }

            return paths;
        }

        private static long GeneratePath(string robotPath, int depth)
        {
            // There's no path, just return
            if (string.IsNullOrEmpty(robotPath))
                return 0;

            // We already know the best path
            if (cache.ContainsKey((depth, robotPath)))
                return cache[(depth, robotPath)];

            if (depth == 0)
            {
                // We're at the deepest level. Find all possible paths for it and return the smallest one
                var pathLengthsAtDeepest = GetAllPaths(robotPath).Select(x => x.LongCount());
                var bestPath = pathLengthsAtDeepest.Min();
                cache.Add((depth, robotPath), bestPath);
                return bestPath;
            }

            long best = long.MaxValue;

            // Break this up one chunk at a time
            var loopIndex = robotPath.IndexOf('A') + 1;
            var searchSequence = robotPath.Substring(0, loopIndex);
            var sameLevelRecursion = robotPath.Substring(loopIndex);

            var searchPaths = GetAllPaths(searchSequence);
            foreach (var path in searchPaths)
            {
                // Get the best score for this chunk
                long score = GeneratePath(path, depth - 1);
                if (best > score)
                {
                    best = score;
                }
            }

            if (!string.IsNullOrWhiteSpace(sameLevelRecursion))
            {
                // If there's more to the path, process the remaining chunks
                best += GeneratePath(sameLevelRecursion, depth);
            }

            // Add to the cache
            cache.Add((depth, robotPath), best);

            return best;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                long score = 0;

                do
                {
                    var line = reader.ReadLine();

                    var number = long.Parse(Regex.Match(line, @"(\d+)").Groups[1].Value);
                    var lineScore = GeneratePath(line, 2);

                    score += lineScore * number;

                } while (!reader.EndOfStream);

                Console.WriteLine(score);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                long score = 0;

                do
                {
                    var line = reader.ReadLine();

                    var number = long.Parse(Regex.Match(line, @"(\d+)").Groups[1].Value);
                    var lineScore = GeneratePath(line, 25);

                    score += lineScore * number;

                } while (!reader.EndOfStream);

                Console.WriteLine(score);
            }
        }

    }
}
