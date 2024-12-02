using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day2
    {
        private static bool IsSafe(List<int> nums)
        {
            var sign = 0;

            for (int i = 0; i < nums.Count - 1; i++)
            {
                var diff = (nums[i] - nums[i + 1]);
                var localSign = Math.Sign(diff);
                if (sign == 0) { sign = localSign; }
                if (Math.Abs(diff) > 3 || sign != localSign || sign == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var safe = 0;
                do
                {
                    var input = reader.ReadLine();
                    var nums = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();                 

                    if (IsSafe(nums)) { safe++; }

                } while (!reader.EndOfStream);

                Console.WriteLine(safe);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var safe = 0;
                do
                {
                    var input = reader.ReadLine();
                    var nums = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

                    if (IsSafe(nums)) {
                        safe++;
                        continue;
                    }

                    for (int i = 0; i < nums.Count; i++)
                    {
                        var withoutIndex = new List<int>(nums);
                        withoutIndex.RemoveAt(i);
                        if (IsSafe(withoutIndex))
                        {
                            safe++;
                            break;
                        }
                    }

                } while (!reader.EndOfStream);

                Console.WriteLine(safe);
            }
        }
    }
}
