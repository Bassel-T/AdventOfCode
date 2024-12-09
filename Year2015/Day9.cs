using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day9
    {
        private static List<List<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new List<T> { t }).ToList();

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Append(t2).ToList()).ToList();
        }

        public static void Part1()
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();
            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var matches = Regex.Match(line, @"(\w+) to (\w+) = (\d+)");
                    string city1 = matches.Groups[1].Value;
                    string city2 = matches.Groups[2].Value;
                    int cost = int.Parse(matches.Groups[3].Value);

                    if (!graph.ContainsKey(city1))
                        graph[city1] = new Dictionary<string, int>();
                    if (!graph.ContainsKey(city2))
                        graph[city2] = new Dictionary<string, int>();

                    graph[city1][city2] = cost;
                    graph[city2][city1] = cost;
                }
            }

            var cities = graph.Keys.ToList();

            // Generate all permutations of cities
            var permutations = GetPermutations(cities, cities.Count);

            // Calculate the minimum cost
            int minCost = int.MaxValue;

            foreach (var route in permutations)
            {
                int cost = 0;
                for (int i = 0; i < route.Count - 1; i++)
                {
                    cost += graph[route[i]][route[i + 1]];
                }

                if (cost < minCost)
                    minCost = cost;
            }

            Console.WriteLine(minCost);
        }

        public static void Part2()
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();
            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var matches = Regex.Match(line, @"(\w+) to (\w+) = (\d+)");
                    string city1 = matches.Groups[1].Value;
                    string city2 = matches.Groups[2].Value;
                    int cost = int.Parse(matches.Groups[3].Value);

                    if (!graph.ContainsKey(city1))
                        graph[city1] = new Dictionary<string, int>();
                    if (!graph.ContainsKey(city2))
                        graph[city2] = new Dictionary<string, int>();

                    graph[city1][city2] = cost;
                    graph[city2][city1] = cost;
                }
            }

            var cities = graph.Keys.ToList();

            var permutations = GetPermutations(cities, cities.Count);

            int maxCost = 0;

            foreach (var route in permutations)
            {
                int cost = 0;
                for (int i = 0; i < route.Count - 1; i++)
                {
                    cost += graph[route[i]][route[i + 1]];
                }

                if (cost > maxCost)
                    maxCost = cost;
            }

            Console.WriteLine(maxCost);
        }
    }
}
