using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day6
    {

        public static void Part1()
        {
            var text = File.ReadAllText("Input.txt").ToCharArray();
            for (int i = 3; i < text.Length; i++)
            {
                var span = text.Skip(i - 3).Take(4).Distinct().Count();
                if (span == 4)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        public static void Part2()
        {
            var text = File.ReadAllText("Input.txt").ToCharArray();
            for (int i = 13; i < text.Length; i++)
            {
                var span = text.Skip(i - 13).Take(14).Distinct().Count();
                if (span == 14)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

    }
}
