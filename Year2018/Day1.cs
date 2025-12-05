using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2018
{
    public static class Day1
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var frequency = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line[0] == '+')
                        frequency += int.Parse(line[1..]);
                    else
                        frequency -= int.Parse(line[1..]);
                }

                Console.WriteLine(frequency);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var lines = reader.ReadToEnd().Split("\r\n");

                HashSet<int> viewed = new() { 0 };
                var frequency = 0;

                while (true)
                {
                    foreach (var line in lines)
                    {
                        if (line[0] == '+')
                            frequency += int.Parse(line[1..]);
                        else
                            frequency -= int.Parse(line[1..]);

                        if (!viewed.Add(frequency))
                        {
                            Console.WriteLine(frequency);
                            return;
                        }
                    }
                }
            }
        }
    }
}
