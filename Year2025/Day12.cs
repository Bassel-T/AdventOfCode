using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day12
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var answer = 0;
                while (!reader.EndOfStream)
                {
                    var data = reader.ReadLine();
                    if (!data.Contains('x')) continue;

                    var regionData = data.Split(' ');
                    var dims = regionData[0].Replace(":", "")
                                                .Split('x')
                                                .Select(int.Parse);

                    var boxCounts = regionData.Skip(1).Sum(int.Parse);

                    if (Math.Ceiling(dims.First() / 3.0) * Math.Ceiling(dims.Last() / 3.0) >= boxCounts)
                    {
                        answer++;
                    }
                }

                Console.WriteLine(answer);
            }
        }

        public static void Part2()
        {
            Console.WriteLine("Merry Christmas!");
        }
    }
}
