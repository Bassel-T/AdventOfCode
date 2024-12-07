using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day3
    {
        public static void Part1()
        {
            int[,] houses = new int[200, 200];
            int x = 100;
            int y = 100;
            int count = 1;
            houses[x, y] = 1;
            string input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input3.txt"));

            foreach (char c in input)
            {
                switch (c)
                {
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '<':
                        x--;
                        break;
                    case '>':
                        x++;
                        break;
                }

                houses[x, y]++;

                if (houses[x, y] == 1) { count++; }
            }

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            int[,] houses = new int[200, 200];
            int x = 100;
            int y = 100;
            int a = 100;
            int b = 100;
            int count = 1;
            houses[x, y] = 1;
            string input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input3.txt"));

            for (int i = 0; i < input.Length; i += 2)
            {
                switch (input[i])
                {
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '<':
                        x--;
                        break;
                    case '>':
                        x++;
                        break;
                }

                houses[x, y]++;

                if (houses[x, y] == 1) { count++; }

                switch (input[i + 1])
                {
                    case '^':
                        b++;
                        break;
                    case 'v':
                        b--;
                        break;
                    case '<':
                        a--;
                        break;
                    case '>':
                        a++;
                        break;
                }

                houses[a, b]++;

                if (houses[a, b] == 1) { count++; }
            }

            Console.WriteLine(count);
        }
    }
}
