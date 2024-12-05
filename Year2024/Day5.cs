using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode.Year2024
{
    // Sleep means death
    public static class Day5
    {
        private static bool IsValid(List<int> updates, List<Tuple<int, int>> precursor)
        {
            for (int i = 0; i < updates.Count(); i++)
            {
                var entries = precursor.Where(tuple => tuple.Item2 == updates.ElementAt(i)).ToList();

                if (entries == null || entries.Count() == 0) continue;

                if (!entries.All(x => updates.IndexOf(x.Item1) < i))
                {
                    return false;
                }
            }

            return true;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<Tuple<int, int>> precursor = new List<Tuple<int, int>>();
                var score = 0;

                do
                {
                    var line = reader.ReadLine();

                    var mapping = Regex.Match(line, @"(\d+)\|(\d+)");
                    if (mapping.Success)
                    {
                        precursor.Add(new Tuple<int, int>(int.Parse(mapping.Groups[1].Value), int.Parse(mapping.Groups[2].Value)));
                    } else if (!string.IsNullOrWhiteSpace(line))
                    {
                        var updates = line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                        var valid = true;

                        for (int i = 0; i < updates.Count(); i++)
                        {
                            var entries = precursor.Where(tuple => tuple.Item2 == updates.ElementAt(i)).ToList();

                            if (entries == null || entries.Count() == 0) continue;

                            if (!entries.All(x => updates.IndexOf(x.Item1) < i))
                            {
                                valid = false;
                                break;
                            }
                        }

                        if (valid)
                        {
                            score += updates[updates.Count / 2];
                        }
                    }

                } while (!reader.EndOfStream);

                Console.WriteLine(score);
            }    
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var score = 0;

                List<Tuple<int, int>> precursor = new List<Tuple<int, int>>();
                Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

                do
                {
                    var line = reader.ReadLine();

                    var mapping = Regex.Match(line, @"(\d+)\|(\d+)");
                    if (mapping.Success)
                    {
                        int left = int.Parse(mapping.Groups[1].Value);
                        int right = int.Parse(mapping.Groups[2].Value);

                        if (graph.ContainsKey(left))
                            graph[left].Add(right);
                        else
                            graph.Add(left, new List<int>() { right });

                        precursor.Add(new Tuple<int, int>(int.Parse(mapping.Groups[1].Value), int.Parse(mapping.Groups[2].Value)));
                    }
                    else if (!string.IsNullOrWhiteSpace(line))
                    {
                        var updates = line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                        var valid = true;

                        for (int i = 0; i < updates.Count(); i++)
                        {
                            var entries = precursor.Where(tuple => tuple.Item2 == updates.ElementAt(i)).ToList();

                            if (entries == null || entries.Count() == 0) continue;

                            if (!entries.All(x => updates.IndexOf(x.Item1) < i))
                            {
                                valid = false;
                                break;
                            }
                        }

                        if (!valid)
                        {
                            updates.Sort((a, b) =>
                            {
                                if (graph.ContainsKey(a))
                                {
                                    var entry = graph[a];
                                    if (entry.Contains(b))
                                        return -1;

                                    return 1;
                                }

                                return 1;
                            });

                            score += updates.ElementAt(updates.Count() / 2);
                        }
                    }

                } while (!reader.EndOfStream);

                Console.WriteLine(score);
            }
        }
    }
}
