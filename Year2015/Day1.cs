using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day1
    {

        public static void Part1()
        {
            string input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input1.txt"));
            int floor = 0;

            foreach (char c in input)
            {
                if (c == '(')
                {
                    floor++;
                }
                else
                {
                    floor--;
                }
            }

            Console.WriteLine(floor);

        }

        public static void Part2()
        {
            string input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input1.txt"));
            int floor = 0;
            int count = 0;
            foreach (char c in input)
            {
                if (c == '(')
                {
                    floor++;
                }
                else
                {
                    floor--;
                }

                count++;

                if (floor < 0)
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

    }
}
