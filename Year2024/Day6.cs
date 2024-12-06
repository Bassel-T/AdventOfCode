using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day6
    {
        enum FACING
        {
            UP,
            RIGHT,
            DOWN,
            LEFT
        }

        class State
        {
            public int X { get; set; }
            public int Y { get; set; }
            public FACING Face { get; set; }
        }

        public static List<Tuple<int, int>> Part1()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>();
            using (var reader = new StreamReader("input.txt"))
            {
                var data = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().ToList()).ToList();

                var xPos = data.IndexOf(data.First(x => x.Contains('^')));
                var yPos = data[xPos].IndexOf('^');

                var facing = FACING.UP;

                try
                {
                    while (true)
                    {
                        positions.Add(new Tuple<int, int>(xPos, yPos));

                        switch (facing)
                        {
                            case FACING.UP:
                                if (data[xPos - 1][yPos] == '#')
                                {
                                    facing = FACING.RIGHT;
                                }
                                else
                                {
                                    xPos--;
                                }
                                break;
                            case FACING.DOWN:
                                if (data[xPos + 1][yPos] == '#')
                                {
                                    facing = FACING.LEFT;
                                }
                                else
                                {
                                    xPos++;
                                }
                                break;
                            case FACING.LEFT:
                                if (data[xPos][yPos - 1] == '#')
                                {
                                    facing = FACING.UP;
                                }
                                else
                                {
                                    yPos--;
                                }
                                break;
                            case FACING.RIGHT:
                                if (data[xPos][yPos + 1] == '#')
                                {
                                    facing = FACING.DOWN;
                                }
                                else
                                {
                                    yPos++;
                                }
                                break;
                            default:
                                throw new Exception();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(positions.Distinct().Count());
                }
            }

            return positions.Distinct().ToList();
        }
        
        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var data = reader.ReadToEnd()
                    .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToCharArray().ToList())
                    .ToList();

                var xPos = data.FindIndex(x => x.Contains('^'));
                var yPos = data[xPos].IndexOf('^');

                var initialX = xPos;
                var initialY = yPos;
                
                var initialFacing = FACING.UP;

                int score = 0;

                var positions = Part1();
                foreach (var position in positions)
                {
                    if (position.Item1 == initialX && position.Item2 == initialY)
                        continue;

                    var copy = data.Select(row => row.ToList()).ToList();
                    copy[position.Item1][position.Item2] = '#';

                    xPos = initialX;
                    yPos = initialY;
                    var facing = initialFacing;

                    var visited = new List<State>();

                    try
                    {
                        do
                        {
                            visited.Add(new State
                            {
                                X = xPos,
                                Y = yPos,
                                Face = facing
                            });

                            switch (facing)
                            {
                                case FACING.UP:
                                    if (copy[xPos - 1][yPos] == '#')
                                    {
                                        facing = FACING.RIGHT;
                                    }
                                    else
                                    {
                                        xPos--;
                                    }
                                    break;
                                case FACING.DOWN:
                                    if (copy[xPos + 1][yPos] == '#')
                                    {
                                        facing = FACING.LEFT;
                                    }
                                    else
                                    {
                                        xPos++;
                                    }
                                    break;
                                case FACING.LEFT:
                                    if (copy[xPos][yPos - 1] == '#')
                                    {
                                        facing = FACING.UP;
                                    }
                                    else
                                    {
                                        yPos--;
                                    }
                                    break;
                                case FACING.RIGHT:
                                    if (copy[xPos][yPos + 1] == '#')
                                    {
                                        facing = FACING.DOWN;
                                    }
                                    else
                                    {
                                        yPos++;
                                    }
                                    break;
                                default:
                                    throw new InvalidOperationException("Invalid facing direction");
                            }
                        } while (!visited.Any(x => x.X == xPos && x.Y == yPos && x.Face == facing));
                        score++;
                    }
                    catch (Exception e)
                    {
                        
                    }
                }

                Console.WriteLine(score);
            }

        }
    }
}
