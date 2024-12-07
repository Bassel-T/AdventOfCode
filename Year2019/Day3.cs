using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
    public static class Day3
    {
        private struct Vector2
        {
            int x { get; set; }
            int y { get; set; }

            public Vector2(int _x, int _y)
            {
                x = _x;
                y = _y;
            }

            public int ManhattanDistance(Vector2 other)
            {
                return Math.Abs(x - other.x) + Math.Abs(y - other.y);
            }
        }

        public static void Part1()
        {
            List<Vector2> firstPath = new List<Vector2>();
            List<Vector2> secondPath = new List<Vector2>();

            int x = 0;
            int y = 0;

            firstPath.Add(new Vector2(x, y));

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input3.txt")))
            {
                string[] item = reader.ReadLine().Split(',');
                foreach (string path in item)
                {
                    if (path.StartsWith('R'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x++;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('L'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x--;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('U'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y++;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('D'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y--;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You should never be here... 1: {item}");
                    }
                }

                item = reader.ReadLine().Split(',');

                x = y = 0;
                secondPath.Add(new Vector2(x, y));

                foreach (string path in item)
                {
                    if (path.StartsWith('R'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x++;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('L'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x--;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('U'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y++;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('D'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y--;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You should never be here... 2: {item}");
                    }
                }
            }

            firstPath.Remove(new Vector2(0, 0));

            Console.WriteLine(firstPath.Intersect(secondPath).Select(x => x.ManhattanDistance(new Vector2(0, 0))).Min());
        }

        public static void Part2()
        {
            List<Vector2> firstPath = new List<Vector2>();
            List<Vector2> secondPath = new List<Vector2>();

            int x = 0;
            int y = 0;

            firstPath.Add(new Vector2(x, y));

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input3.txt")))
            {
                string[] item = reader.ReadLine().Split(',');
                foreach (string path in item)
                {
                    if (path.StartsWith('R'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x++;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('L'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x--;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('U'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y++;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('D'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y--;
                            firstPath.Add(new Vector2(x, y));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You should never be here... 1: {item}");
                    }
                }

                item = reader.ReadLine().Split(',');

                x = y = 0;
                secondPath.Add(new Vector2(x, y));

                foreach (string path in item)
                {
                    if (path.StartsWith('R'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x++;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('L'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            x--;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('U'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y++;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else if (path.StartsWith('D'))
                    {
                        for (int i = 0, a = int.Parse(path.Substring(1)); i < a; i++)
                        {
                            y--;
                            secondPath.Add(new Vector2(x, y));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You should never be here... 2: {item}");
                    }
                }
            }

            firstPath.Remove(new Vector2(0, 0));

            // The + 1 below takes into account the fact we removed (0, 0) from firstPath.
            Console.WriteLine(firstPath.Intersect(secondPath).Select(x => firstPath.IndexOf(x) + secondPath.IndexOf(x)).Min() + 1);
        }

    }
}
