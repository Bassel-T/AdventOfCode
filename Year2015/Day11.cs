using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day11
    {
        private static string input = "vzbxkghb";

        private static bool HasIncreasingRun(string data)
        {
            for (int i = 0; i < data.Length - 2; i++)
            {
                if (data[i] == data[i + 1] - 1 && data[i + 1] == data[i + 2] - 1)
                    return true;
            }

            return false;
        }

        private static bool HasNoIllegalChars(string data)
        {
            return data.All(x => x != 'i' && x != 'o' && x != 'l');
        }

        private static bool HasDoubleLetter(string data)
        {
            int pairs = 0;
            List<char> sets = new List<char>();
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] == data[i + 1] && !sets.Contains(data[i]))
                {
                    pairs++;
                    i++;
                    sets.Add(data[i]);
                }
            }

            return pairs > 1;
        }

        private static string Increment(string inc)
        {
            List<char> chars = inc.ToCharArray().ToList();
            int i = chars.Count - 1;

            while (i >= 0)
            {
                if (chars[i] == 'z')
                {
                    chars[i] = 'a';
                    i--;

                    if (i == -1)
                        chars.Insert(0, 'a');
                }
                else
                {
                    chars[i]++;
                    break;
                }
            }

            return string.Join("", chars);
        }

        private static string CalculateNext(string data)
        {
            data = Increment(data);

            while (!HasDoubleLetter(data) || !HasIncreasingRun(data) || !HasNoIllegalChars(data))
            {
                data = Increment(data);
            }

            return data;
        }

        public static void Part1()
        {
            var data = CalculateNext(input);
            Console.WriteLine(data);
        }

        public static void Part2()
        {
            var data = CalculateNext(CalculateNext(input));
            Console.WriteLine(data);
        }
    }
}
