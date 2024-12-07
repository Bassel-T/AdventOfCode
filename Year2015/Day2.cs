using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day2
    {

        public static void Part1()
        {
            ulong total = 0;
            List<ulong[]> input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input2.txt"))
                .Select(x => x.Split('x').Select(y => ulong.Parse(y)).ToArray()).ToList();

            foreach (ulong[] arr in input)
            {

                Array.Sort(arr);

                total += 2 * (arr[0] * (arr[1] + arr[2]) + arr[1] * arr[2]) + arr[0] * arr[1];

            }

            Console.WriteLine(total);
        }

        public static void Part2()
        {
            ulong total = 0;
            List<ulong[]> input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input2.txt"))
                .Select(x => x.Split('x').Select(y => ulong.Parse(y)).ToArray()).ToList();

            foreach (ulong[] arr in input)
            {

                Array.Sort(arr);

                total += 2 * (arr[0] + arr[1]) + arr[0] * arr[1] * arr[2];

            }

            Console.WriteLine(total);
        }
    }
}
