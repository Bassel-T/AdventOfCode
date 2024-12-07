using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016
{
    public static class Day3
    {
        public static void Part1()
        {
            int valid = 0;
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DayThree.txt"));
            Console.WriteLine(lines.Length);
            foreach (string line in lines)
            {

                Console.WriteLine(line);
                int[] comp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();
                Array.Sort(comp);

                if (comp[0] + comp[1] > comp[2])
                {
                    valid++;
                }
            }

            Console.WriteLine(valid);
        }

        public static void Part2()
        {
            int valid = 0;
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DayThree.txt"));

            int[] Col1 = new int[3];
            int[] Col2 = new int[3];
            int[] Col3 = new int[3];

            int i = 0;

            foreach (string line in lines)
            {
                int[] comp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();
                Col1[i] = (comp[0]);
                Col2[i] = (comp[1]);
                Col3[i] = (comp[2]);

                i++;

                if (i == 3)
                {
                    Array.Sort(Col1);
                    Array.Sort(Col2);
                    Array.Sort(Col3);

                    if (Col1[0] + Col1[1] > Col1[2]) { valid++; }
                    if (Col2[0] + Col2[1] > Col2[2]) { valid++; }
                    if (Col3[0] + Col3[1] > Col3[2]) { valid++; }

                    i = 0;
                }
            }

            Console.WriteLine(valid);

        }

    }
}
