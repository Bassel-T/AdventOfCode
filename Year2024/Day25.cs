using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day25
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<List<List<char>>> graphs = new List<List<List<char>>>();
                List<List<char>> curr = new List<List<char>>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        graphs.Add(curr.Select(x => x).ToList());
                        curr.Clear();
                    } else
                    {
                        curr.Add(line.ToCharArray().ToList());
                    }
                }

                graphs.Add(curr.Select(X => X).ToList());

                var locks = graphs.Where(item => item[0].All(x => x == '#') && item.Last().All(x => x == '.')).ToList();
                var keys = graphs.Where(item => item.Last().All(x => x == '#') && item[0].All(x => x == '.')).ToList();

                List<List<int>> lockHeights = locks.Select(lockGraph =>
                {
                    List<int> heights = lockGraph.First().Select(x => 0).ToList();
                    for (int i = 0; i < lockGraph.Count; i++)
                    {
                        for (int j = 0; j < lockGraph[i].Count; j++)
                        {
                            if (lockGraph[i][j] == '#') heights[j]++;
                        }
                    }

                    return heights;
                }).ToList();

                List<List<int>> keyHeights = keys.Select(key =>
                {
                    List<int> heights = key.First().Select(x => 0).ToList();
                    for (int i = key.Count - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < key[i].Count; j++)
                        {
                            if (key[i][j] == '#') heights[j]++;
                        }
                    }

                    return heights;
                }).ToList();

                var score = lockHeights.Sum(item =>
                {
                    var subscore = 0;

                    foreach (var keyHeight in keyHeights)
                    {
                        bool fits = true;
                        for (int i = 0; i < keyHeight.Count; i++)
                        {
                            if (item[i] + keyHeight[i] > 7)
                            {
                                fits = false;
                                break;
                            }
                        }

                        if (fits)
                            subscore++;
                    }
                    return subscore;
                });

                Console.WriteLine(score);
            }
        }

        public static void Part2()
        {
            // "There is no Easter Bunny, there is no Tooth Fairy, and there is no Part 2 of Day 25." -Hal (Megamind, circa 2010)
        }
    }
}
