using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day10
    {

        private static int HandleCycle(int cycle, int x)
        {
            if ((cycle - 20) % 40 == 0)
            {
                Console.WriteLine(x * cycle);
                return x * cycle;
            }

            return 0;
        }

        public static void Part1()
        {
            var text = File.ReadAllLines("Input.txt");

            var cycle = 1;
            var x = 1;
            var sum = 0;

            foreach (var line in text)
            {

                if (line.StartsWith("addx"))
                {
                    cycle++;
                    sum += HandleCycle(cycle, x);
                    x += int.Parse(line.Split(' ')[1]);
                }


                cycle++;
                sum += HandleCycle(cycle, x);
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            var text = File.ReadAllLines("Input.txt");

            var x = 1;
            var cycle = 0;
            Console.Write("#");

            foreach (var line in text)
            {

                if (line.StartsWith("addx"))
                {
                    cycle++;
                    Console.Write(Math.Abs(x - cycle % 40) < 2 ? "#" : ".");
                    if (cycle % 40 == 39) { Console.WriteLine(); }
                    x += int.Parse(line.Split(' ')[1]);
                }


                cycle++;
                Console.Write(Math.Abs(x - cycle % 40) < 2 ? "#" : ".");
                if (cycle % 40 == 39) { Console.WriteLine(); }

            }
        }

    }
}
