using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode.Year2025
{
    public static class Day9
    {
        private class Point
        {
            public long x, y;
        }

        private class Edge
        {
            public Point p1, p2;

            public bool IsYAxis => p1.y == p2.y;

            public long SmallerX => Math.Min(p1.x, p2.x);
            public long LargerX => Math.Max(p1.x, p2.x);
            public long SmallerY => Math.Min(p1.y, p2.y);
            public long LargerY => Math.Max(p1.y, p2.y);
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var data = reader.ReadToEnd().Split("\r\n").Select(x =>
                {
                    var frag = x.Split(',');
                    return new Point()
                    {
                        x = long.Parse(frag[0]),
                        y = long.Parse(frag[1])
                    };
                }).ToList();

                long answer = 0;

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        // So... I got lucky with this assumption. An assumption that got me in Part 2
                        long newProd = Math.Abs((data[i].x - data[j].x + 1) * (1 + data[i].y - data[j].y));

                        if (newProd > answer) answer = newProd;
                    }
                }

                Console.WriteLine(answer);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var data = reader.ReadToEnd().Split("\r\n").Select(x =>
                {
                    var frag = x.Split(',');
                    return new Point()
                    {
                        x = long.Parse(frag[0]),
                        y = long.Parse(frag[1])
                    };
                }).ToList();

                var edges = new List<Edge>();

                for (int i = 0; i < data.Count; i++)
                {
                    var p1 = data[i];
                    var p2 = data[(i + 1) % data.Count];

                    edges.Add(new Edge { p1 = p1, p2 = p2 });
                }

                long answer = 0;

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        var smallerX = Math.Min(data[i].x, data[j].x);
                        var largerX = Math.Max(data[i].x, data[j].x);
                        var smallerY = Math.Min(data[i].y, data[j].y);
                        var largerY = Math.Max(data[i].y, data[j].y);

                        long newProd = (largerX - smallerX + 1) * (largerY - smallerY + 1);
                        if (newProd <= answer)
                            continue;
                        
                        if (RectangleInPolygon(data[i], data[j], edges))
                            answer = newProd;
                    }
                }

                Console.WriteLine(answer);
            }
        }

        private static bool RectangleInPolygon(Point p1, Point p2, List<Edge> edges)
        {
            var minX = Math.Min(p1.x, p2.x);
            var maxX = Math.Max(p1.x, p2.x);
            var minY = Math.Min(p1.y, p2.y);
            var maxY = Math.Max(p1.y, p2.y);

            foreach (var edge in edges)
            {
                if (edge.IsYAxis)
                {
                    if (minY < edge.p1.y && edge.p1.y < maxY &&
                        (Math.Min(edge.p1.x, edge.p2.x) <= minX && minX < Math.Max(edge.p1.x, edge.p2.x) ||
                         Math.Min(edge.p1.x, edge.p2.x) < maxX && maxX <= Math.Max(edge.p1.x, edge.p2.x)))
                    {
                        return false;
                    }
                }
                else
                {
                    if (minX < edge.p1.x && edge.p1.x < maxX &&
                        (Math.Min(edge.p1.y, edge.p2.y) <= minY && minY < Math.Max(edge.p1.y, edge.p2.y) ||
                         Math.Min(edge.p1.y, edge.p2.y) < maxY && maxY <= Math.Max(edge.p1.y, edge.p2.y)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
