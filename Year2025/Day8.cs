using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day8
    {
        private class Vertex
        {
            public int Id;

            public ulong X;
            public ulong Y;
            public ulong Z;
        }

        private class Edge
        {
            public Vertex V1;
            public Vertex V2;

            // Technically should be the square root of this, but that's just a matter of scale
            public ulong Weight => (V1.X - V2.X) * (V1.X - V2.X)
                                  + (V1.Y - V2.Y) * (V1.Y - V2.Y)
                                  + (V1.Z - V2.Z) * (V1.Z - V2.Z);
        }

        // Derived from Kruskal's Algorithm
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var vertices = reader.ReadToEnd().Split("\r\n").Select((x, i) => {
                    var frag = x.Split(',');
                    return new Vertex
                    {
                        Id = i,
                        X = ulong.Parse(frag[0]),
                        Y = ulong.Parse(frag[1]),
                        Z = ulong.Parse(frag[2])
                    };
                }).ToList();

                var edges = new List<Edge>();

                List<HashSet<Vertex>> sets = new List<HashSet<Vertex>>();

                for (int i = 0; i < vertices.Count; i++)
                {
                    sets.Add([vertices[i]]);

                    for (int j = i + 1; j < vertices.Count; j++)
                    {
                        var edge = new Edge { V1 = vertices[i], V2 = vertices[j] };
                        edges.Add(edge);
                    }
                }

                edges = edges.OrderBy(x => x.Weight).ToList();

                for (int i = 0; i < 1000; i++)
                {
                    var edge = edges[i];

                    HashSet<Vertex> set1 = sets.First(x => x.Contains(edge.V1));
                    HashSet<Vertex> set2 = sets.First(x => x.Contains(edge.V2));

                    if (set1 != set2)
                    {
                        set1.UnionWith(set2);
                        sets.Remove(set2);
                    }
                }

                sets = sets.OrderByDescending(x => x.Count).ToList();
                var answer = 1l;

                for (int i = 0; i < 3; i++)
                {
                    answer *= sets[i].Count;
                }

                Console.WriteLine(answer);
            }
        }

        // Actual Kruskal's Algorithm
        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var vertices = reader.ReadToEnd().Split("\r\n").Select((x, i) => {
                    var frag = x.Split(',');
                    return new Vertex
                    {
                        Id = i,
                        X = ulong.Parse(frag[0]),
                        Y = ulong.Parse(frag[1]),
                        Z = ulong.Parse(frag[2])
                    };
                }).ToList();

                var edges = new List<Edge>();

                List<HashSet<Vertex>> sets = new List<HashSet<Vertex>>();

                for (int i = 0; i < vertices.Count; i++)
                {
                    sets.Add([vertices[i]]);

                    for (int j = i + 1; j < vertices.Count; j++)
                    {
                        var edge = new Edge { V1 = vertices[i], V2 = vertices[j] };
                        edges.Add(edge);
                    }
                }

                edges = edges.OrderBy(x => x.Weight).ToList();

                int mergesNeeded = vertices.Count - 1;
                int merges = 0;

                for (int i = 0; i < edges.Count; i++)
                {
                    var edge = edges[i];

                    HashSet<Vertex> set1 = sets.First(x => x.Contains(edge.V1));
                    HashSet<Vertex> set2 = sets.First(x => x.Contains(edge.V2));

                    if (set1 != set2)
                    {
                        set1.UnionWith(set2);
                        sets.Remove(set2);
                        merges++;

                        if (merges == mergesNeeded)
                        {
                            Console.WriteLine(edge.V1.X * edge.V2.X);
                            break;
                        }
                    }
                }
            }
        }
    }
}
