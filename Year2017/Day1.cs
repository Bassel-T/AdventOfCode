using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2017
{
    public static class Day1
    {
        public static void Part1()
        {
            List<int> data = File.ReadAllText("Input.txt").Select(x => int.Parse($"{x}")).ToList();
            int sum = data.First() == data.Last() ? data.First() : 0;

            for (int i = 0, c = data.Count - 1; i < c; i++)
            {
                if (data[i] == data[i + 1])
                {
                    sum += data[i];
                }
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            List<int> data = File.ReadAllText("Input.txt").Select(x => int.Parse($"{x}")).ToList();
            int sum = 0;

            for (int i = 0, c = data.Count / 2; i < c; i++)
            {
                if (data[i] == data[i + c])
                {
                    sum += 2 * data[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
