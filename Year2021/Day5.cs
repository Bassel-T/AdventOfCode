using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day5
    {
        public static void Part1()
        {
            List<List<int>> lines = new List<List<int>>();
            for (int i = 0; i < 1000; ++i)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 1000; ++j)
                {
                    row.Add(0);
                }
                lines.Add(row);
            }

            using (var reader = new StreamReader("Input5.txt"))
            {
                while (!reader.EndOfStream)
                {
                    List<int> line = new List<int>();
                    List<string> data = reader.ReadLine()
                        .Split(new char[] { ',', ' ' })
                        .ToList();
                    data.RemoveAt(2);
                    foreach (string i in data)
                    {
                        line.Add(Convert.ToInt32(i));
                    }

                    if (line[0] == line[2])
                    {
                        int startY = Math.Min(line[1], line[3]);
                        int endY = Math.Max(line[1], line[3]);

                        for (; startY <= endY; ++startY)
                        {
                            ++lines[startY][line[0]];
                        }
                    }

                    if (line[1] == line[3])
                    {
                        int startX = Math.Min(line[0], line[2]);
                        int endX = Math.Max(line[0], line[2]);

                        for (; startX <= endX; ++startX)
                        {
                            ++lines[line[1]][startX];
                        }
                    }
                }
            }

            int total = 0;
            foreach (List<int> line in lines)
            {
                foreach (int i in line)
                {
                    if (i > 1)
                    {
                        ++total;
                    }
                }
            }

            Console.WriteLine(total);
        }

        public static void Part2()
        {
            List<List<int>> lines = new List<List<int>>();
            for (int i = 0; i < 1000; ++i)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 1000; ++j)
                {
                    row.Add(0);
                }
                lines.Add(row);
            }

            using (var reader = new StreamReader("Input5.txt"))
            {
                while (!reader.EndOfStream)
                {
                    List<int> line = new List<int>();
                    List<string> data = reader.ReadLine()
                        .Split(new char[] { ',', ' ' })
                        .ToList();
                    data.RemoveAt(2);
                    foreach (string i in data)
                    {
                        line.Add(Convert.ToInt32(i));
                    }

                    if (line[0] == line[2])
                    {
                        int startY = Math.Min(line[1], line[3]);
                        int endY = Math.Max(line[1], line[3]);

                        for (; startY <= endY; ++startY)
                        {
                            ++lines[startY][line[0]];
                        }
                    }
                    else if (line[1] == line[3])
                    {
                        int startX = Math.Min(line[0], line[2]);
                        int endX = Math.Max(line[0], line[2]);

                        for (; startX <= endX; ++startX)
                        {
                            ++lines[line[1]][startX];
                        }
                    }
                    else
                    {
                        // Diagonal
                        int dx = line[2] - line[0];
                        int dy = line[3] - line[1];
                        for (int x = line[0], y = line[1]; x != line[2] && y != line[3]; x += Math.Sign(dx), y += Math.Sign(dy))
                        {
                            ++lines[y][x];
                        }
                        ++lines[line[3]][line[2]];
                    }
                }
            }

            int total = 0;
            foreach (List<int> line in lines)
            {
                foreach (int i in line)
                {
                    if (i > 1)
                    {
                        ++total;
                    }
                }
            }

            Console.WriteLine(total);
        }
    }
}
