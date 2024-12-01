using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day2
    {
        public static void Part1()
        {
            long depth = 0, horizontal = 0;

            using (var reader = new StreamReader("Input2.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] command = reader.ReadLine().Split(' ');
                    switch (command[0])
                    {
                        case "up":
                            depth -= Convert.ToInt32(command[1]);
                            break;
                        case "down":
                            depth += Convert.ToInt32(command[1]);
                            break;
                        default:
                            horizontal += Convert.ToInt32(command[1]);
                            break;
                    }
                }
            }

            Console.WriteLine(depth * horizontal);
        }

        public static void Part2()
        {
            long depth = 0, horizontal = 0, aim = 0;

            using (var reader = new StreamReader("Input2.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] command = reader.ReadLine().Split(' ');
                    switch (command[0])
                    {
                        case "up":
                            aim -= Convert.ToInt32(command[1]);
                            break;
                        case "down":
                            aim += Convert.ToInt32(command[1]);
                            break;
                        default:
                            horizontal += Convert.ToInt32(command[1]);
                            depth += aim * Convert.ToInt32(command[1]);
                            break;
                    }
                }
            }

            Console.WriteLine(depth * horizontal);
        }
    }
}
