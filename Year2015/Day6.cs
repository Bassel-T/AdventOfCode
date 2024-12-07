using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day6
    {
        public static void Part1()
        {
            bool[,] lights = new bool[1000, 1000];
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input6.txt"));
            int count = 0;

            foreach (string l in lines)
            {
                MatchCollection coords = Regex.Matches(l, @"\d+\,\d+");
                List<int> edges = coords[0].ToString().Split(',').Select(x => int.Parse(x)).ToList();
                edges.AddRange(coords[1].ToString().Split(',').Select(x => int.Parse(x)));

                if (l.StartsWith("turn on"))
                {
                    for (int i = edges[0]; i <= edges[2]; i++)
                    {
                        for (int j = edges[1]; j <= edges[3]; j++)
                        {
                            if (!lights[i, j])
                            {
                                lights[i, j] = true;
                                count++;
                            }
                        }
                    }
                }
                else if (l.StartsWith("turn off"))
                {
                    for (int i = edges[0]; i <= edges[2]; i++)
                    {
                        for (int j = edges[1]; j <= edges[3]; j++)
                        {
                            if (lights[i, j])
                            {
                                lights[i, j] = false;
                                count--;
                            }
                        }
                    }
                }
                else if (l.StartsWith("toggle"))
                {
                    for (int i = edges[0]; i <= edges[2]; i++)
                    {
                        for (int j = edges[1]; j <= edges[3]; j++)
                        {
                            lights[i, j] = !lights[i, j];

                            if (lights[i, j])
                            {
                                count++;
                            }
                            else
                            {
                                count--;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            int[,] lights = new int[1000, 1000];
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input6.txt"));
            int count = 0;

            foreach (string l in lines)
            {
                MatchCollection coords = Regex.Matches(l, @"\d+\,\d+");
                List<int> edges = coords[0].ToString().Split(',').Select(x => int.Parse(x)).ToList();
                edges.AddRange(coords[1].ToString().Split(',').Select(x => int.Parse(x)));

                if (l.StartsWith("turn on"))
                {
                    for (int i = edges[0]; i <= edges[2]; i++)
                    {
                        for (int j = edges[1]; j <= edges[3]; j++)
                        {
                            lights[i, j]++;
                            count++;
                        }
                    }
                }
                else if (l.StartsWith("turn off"))
                {
                    for (int i = edges[0]; i <= edges[2]; i++)
                    {
                        for (int j = edges[1]; j <= edges[3]; j++)
                        {
                            if (lights[i, j] > 0)
                            {
                                lights[i, j]--;
                                count--;
                            }
                        }
                    }
                }
                else if (l.StartsWith("toggle"))
                {
                    for (int i = edges[0]; i <= edges[2]; i++)
                    {
                        for (int j = edges[1]; j <= edges[3]; j++)
                        {
                            lights[i, j] += 2;
                            count += 2;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
