using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day1
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("Input1.txt"))
            {

                int oldVal = Convert.ToInt32(reader.ReadLine());
                int newVal;

                int increases = 0;

                while (!reader.EndOfStream)
                {
                    newVal = Convert.ToInt32(reader.ReadLine());
                    if (newVal > oldVal)
                    {
                        ++increases;
                    }
                    oldVal = newVal;
                }

                Console.WriteLine(increases);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("Input1.txt"))
            {
                int[] values = reader.ReadToEnd().Split('\n').Select(x => Convert.ToInt32(x)).ToArray();

                int oldVal = values[0] + values[1] + values[2];
                int newVal = 0;

                int increases = 0;
                for (int i = 1, l = values.Length - 2; i < l; ++i)
                {
                    newVal = values[i] + values[i + 1] + values[i + 2];
                    if (newVal > oldVal)
                    {
                        ++increases;
                    }
                    oldVal = newVal;
                }

                Console.WriteLine(increases);
            }
        }
    }
}
