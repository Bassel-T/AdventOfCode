using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day4
    {
        class Group4
        {
            public int start1 { get; set; }
            public int end1 { get; set; }
            public int start2 { get; set; }
            public int end2 { get; set; }
        }

        public static void Part1()
        {
            var text = File.ReadAllLines("Input.txt").Select(x => {
                var split = x.Split(',').Select(y => y.Split('-').ToList()).ToList();
                return new Group4
                {
                    start1 = int.Parse(split[0][0]),
                    end1 = int.Parse(split[0][1]),
                    start2 = int.Parse(split[1][0]),
                    end2 = int.Parse(split[1][1])
                };
            });

            Console.WriteLine(text.Count(x => {
                bool first = x.start1 <= x.start2 && x.end1 >= x.end2;
                bool second = x.start2 <= x.start1 && x.end2 >= x.end1;
                return first || second;
            }));

        }

        public static void Part2()
        {
            var text = File.ReadAllLines("Input.txt").Select(x => {
                var split = x.Split(',').Select(y => y.Split('-').ToList()).ToList();
                return new Group4
                {
                    start1 = int.Parse(split[0][0]),
                    end1 = int.Parse(split[0][1]),
                    start2 = int.Parse(split[1][0]),
                    end2 = int.Parse(split[1][1])
                };
            });

            Console.WriteLine(text.Count(x => {
                bool first = x.start1 <= x.start2 && x.end1 >= x.start2;
                bool second = x.start2 <= x.start1 && x.end2 >= x.start1;
                bool third = x.start1 <= x.end2 && x.end1 >= x.end2;
                bool fourth = x.start2 <= x.end1 && x.end2 >= x.end1;
                return first || second || third || fourth;
            }));
        }

    }
}
