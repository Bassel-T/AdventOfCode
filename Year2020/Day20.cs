using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day20
    {
        class Node
        {
            public int ID { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Up { get; set; }
            public Node Down { get; set; }
            public string Map { get; set; }

            public Node(int id)
            {
                ID = id;
                Left = Right = Up = Down = null;
                Map = "";
            }

            public override bool Equals(object obj)
            {
                if (obj is Node)
                {
                    Node cmp = (Node)obj;
                    return cmp.ID == ID;
                }
                else if (obj is int)
                {
                    return ID == (int)obj;
                }

                return false;
            }

            public int LastDirection(Node last)
            {
                if (last.Equals(Up))
                {
                    return 0;
                }
                else if (last.Equals(Right))
                {
                    return 1;
                }
                else if (last.Equals(Down))
                {
                    return 2;
                }
                else if (last.Equals(Left))
                {
                    return 3;
                }

                // No match anywhere
                return -1;
            }
        }

        private static short Reverse(short input)
        {
            short toReturn = 0;

            for (int i = 0; i < 10; i++)
            {
                int pow = (int)Math.Pow(2, i);
                if ((input & pow) == pow)
                {
                    toReturn |= (short)(1 << (9 - i));
                }
            }

            Console.WriteLine($"{input}, {Convert.ToString(input, 2)}");
            Console.WriteLine($"{toReturn}, {Convert.ToString(toReturn, 2)}");
            return toReturn;
        }

        public static List<int> Part1()
        {
            List<List<short>> tiles = new List<List<short>>();
            List<int> tileID = new List<int>();

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input20.txt")))
            {
                string input = "";

                while (!reader.EndOfStream)
                {
                    input = reader.ReadLine();
                    Console.WriteLine(input.Substring(5, 4));
                    tileID.Add(int.Parse(input.Substring(5, 4)));
                    List<short> data = new List<short>();
                    short left = 0;
                    short right = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        input = reader.ReadLine();
                        if (i == 0 || i == 9)
                        {
                            short line = (short)Convert.ToInt32(input.Replace('#', '1').Replace('.', '0'), 2);
                            data.Add(line);
                            data.Add(Reverse(line));
                        }

                        if (input.StartsWith('#'))
                        {
                            left |= (short)(1 << i);
                        }

                        if (input.EndsWith('#'))
                        {
                            right |= (short)(1 << i);
                        }
                    }

                    data.Add(left);
                    data.Add(right);
                    data.Add(Reverse(left));
                    data.Add(Reverse(right));

                    tiles.Add(data);

                    // Blank line
                    input = reader.ReadLine();
                }
            }

            ulong prod = 1;
            List<int> cornerID = new List<int>();

            for (int i = 0; i < tiles.Count; i++)
            {
                for (int j = i + 1; j < tiles.Count; j++)
                {
                    List<short> intersect = tiles[i].Intersect(tiles[j]).ToList();
                    tiles[i] = tiles[i].Except(intersect.Intersect(tiles[i])).ToList();
                    tiles[j] = tiles[j].Except(intersect.Intersect(tiles[j])).ToList();
                }

                if (tiles[i].Count == 4)
                {
                    prod *= (ulong)tileID[i];
                    cornerID.Add(tileID[i]);
                }
            }

            Console.WriteLine($"Part 1: {prod}");

            return cornerID;
        }

        public static void Part2()
        {
            List<List<short>> tiles = new List<List<short>>();
            List<Node> tileData = new List<Node>();

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input20.txt")))
            {
                string input = "";

                while (!reader.EndOfStream)
                {
                    input = reader.ReadLine();
                    Console.WriteLine(input.Substring(5, 4));
                    Node newNode = new Node(int.Parse(input.Substring(5, 4)));
                    List<short> data = new List<short>();
                    short left = 0;
                    short right = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        input = reader.ReadLine();
                        if (i == 0 || i == 9)
                        {
                            short line = (short)Convert.ToInt32(input.Replace('#', '1').Replace('.', '0'), 2);
                            data.Add(line);
                            data.Add(Reverse(line));
                        }
                        else
                        {
                            newNode.Map += input.Substring(1, 8) + "\n";
                        }

                        if (input.StartsWith('#'))
                        {
                            left |= (short)(1 << i);
                        }

                        if (input.EndsWith('#'))
                        {
                            right |= (short)(1 << i);
                        }
                    }

                    data.Add(left);
                    data.Add(Reverse(left));
                    data.Add(right);
                    data.Add(Reverse(right));

                    tileData.Add(newNode);
                    tiles.Add(data);

                    // Blank line
                    input = reader.ReadLine();
                }
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                for (int j = i + 1; j < tiles.Count; j++)
                {
                    List<short> intersect = tiles[i].Intersect(tiles[j]).ToList();
                    for (int k = 0; k < intersect.Count; k += 2)
                    {
                        switch (tiles[i].IndexOf(intersect[k]))
                        {
                            case (0):
                            case (1):
                                tileData[i].Up = tileData[j];
                                break;
                            case (2):
                            case (3):
                                tileData[i].Down = tileData[j];
                                break;
                            case (4):
                            case (5):
                                tileData[i].Left = tileData[j];
                                break;
                            case (6):
                            case (7):
                                tileData[i].Left = tileData[j];
                                break;
                        }

                        switch (tiles[j].IndexOf(intersect[k]))
                        {
                            case (0):
                            case (1):
                                tileData[j].Up = tileData[i];
                                break;
                            case (2):
                            case (3):
                                tileData[j].Down = tileData[i];
                                break;
                            case (4):
                            case (5):
                                tileData[j].Left = tileData[i];
                                break;
                            case (6):
                            case (7):
                                tileData[j].Left = tileData[i];
                                break;
                        }
                    }
                }
            } // End of Node Generation

            List<int> corners = Part1();

            tileData.Any(x => corners[0] == x.ID);

        }
    }
}
