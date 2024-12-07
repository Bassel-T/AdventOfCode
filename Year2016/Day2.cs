using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016
{
    public static class Day2
    {
        private static int[,] keypad = new int[3, 3] {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        private static string[,] keypad2 = new string[5, 5] {
            { "-1", "-1", "1", "-1", "-1" },
            { "-1", "2", "3", "4", "-1" },
            { "5", "6", "7", "8", "9" },
            { "-1", "A", "B", "C", "-1" },
            { "-1", "-1", "D", "-1", "-1" }

        };

        public static void Part1()
        {
            int x = 1, y = 1;

            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "DayTwo.txt")))
            {
                string[] lines = sr.ReadToEnd().Split('\n');
                foreach (string path in lines)
                {
                    foreach (char dir in path)
                    {
                        if (dir == 'U' && y > 0)
                        {
                            y--;
                        }
                        else if (dir == 'D' && y < 2)
                        {
                            y++;
                        }
                        else if (dir == 'L' && x > 0)
                        {
                            x--;
                        }
                        else if (dir == 'R' && x < 2)
                        {
                            x++;
                        }
                    }

                    Console.Write(keypad[y, x]);
                }
            }
        }

        public static void Part2()
        {
            int x = 0, y = 2;

            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "DayTwo.txt")))
            {
                string[] lines = sr.ReadToEnd().Split('\n');
                foreach (string path in lines)
                {
                    foreach (char dir in path)
                    {
                        if (dir == 'U' && y > 0)
                        {
                            if (keypad2[y - 1, x] != "-1")
                                y--;
                        }
                        else if (dir == 'D' && y < 4)
                        {
                            if (keypad2[y + 1, x] != "-1")
                                y++;
                        }
                        else if (dir == 'L' && x > 0)
                        {
                            if (keypad2[y, x - 1] != "-1")
                                x--;
                        }
                        else if (dir == 'R' && x < 4)
                        {
                            if (keypad2[y, x + 1] != "-1")
                                x++;
                        }
                    }

                    Console.Write(keypad2[y, x]);
                }
            }
        }
    }
}
