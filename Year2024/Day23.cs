using AdventOfCode.Utility;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day23
    {
        private static List<string> Backtrack(Dictionary<string, List<string>> graph, List<string> max, List<string> current, List<string> vertices, int index)
        {
            if (index == vertices.Count)
            {
                if (current.Count > max.Count)
                {
                    // Found a longer one
                    max = new(current);
                }
                return max;
            }

            if (current.All(item => graph[item].Contains(vertices[index])))
            {
                // The next vertex fits within the clique add it and curse
                current.Add(vertices[index]);
                max = Backtrack(graph, max, current, vertices, index + 1);
                current.RemoveAt(current.Count - 1);
            }

            return Backtrack(graph, max, current, vertices, index + 1);
        }

        private static List<string> MaximumClique(Dictionary<string, List<string>> graph)
        {
            List<string> maxClique = [];
            List<string> currentClique = [];
            List<string> vertices = new(graph.Keys);

            maxClique = Backtrack(graph, currentClique, maxClique, vertices, 0);
            return maxClique;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

                do
                {
                    var line = reader.ReadLine();
                    string[] frag = line.Split('-', StringSplitOptions.RemoveEmptyEntries);

                    CollectionUtil.InsertOrAppend(graph, frag[0], frag[1]);
                    CollectionUtil.InsertOrAppend(graph, frag[1], frag[0]);
                } while (!reader.EndOfStream);

                int score = 0;

                foreach (var entry in graph)
                {
                    foreach (var element in entry.Value)
                    {
                        var matches = entry.Value.Intersect(graph[element]).ToList();

                        foreach (var match in matches)
                        {
                            if (entry.Key.StartsWith('t') || element.StartsWith('t') || match.StartsWith('t'))
                            {
                                score++;
                            }
                        }
                    }
                }
                
                // Lazy solution: Divide by six to handle combinations: abc, acb, bac, bca, cab, cba
                Console.WriteLine(score / 6);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<(string c1, string c2)> pairs = new();
                Dictionary<string, List<string>> graph = [];

                do
                {
                    var line = reader.ReadLine();
                    var frag = line.Split('-', StringSplitOptions.RemoveEmptyEntries);

                    CollectionUtil.InsertOrAppend(graph, frag[0], frag[1]);
                    CollectionUtil.InsertOrAppend(graph, frag[1], frag[0]);
                } while (!reader.EndOfStream);

                var clique = MaximumClique(graph);
                var output = string.Join(",", clique.OrderBy(x => x));

                Console.WriteLine(output);
            }
        }
    }
}
