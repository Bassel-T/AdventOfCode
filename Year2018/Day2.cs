using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2018
{
    public static class Day2
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var totalTwos = 0;
                var totalThrees = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var batches = line.GroupBy(x => x).Select(x => new { Key = x.Key, Count = x.Count()} );

                    if (batches.Any(x => x.Count == 2))
                        totalTwos++;

                    if (batches.Any(x => x.Count == 3))
                        totalThrees++;
                }

                Console.WriteLine(totalTwos * totalThrees);
            }
        }
        
        private static List<char> CompareStrings(string x, string y)
        {
            List<char> similarChars = new List<char>();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == y[i])
                    similarChars.Add(x[i]);
            }

            return similarChars;
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var lines = reader.ReadToEnd().Split("\r\n");

                for (int i = 0; i < lines.Length - 1; i++)
                {
                    var test = lines[i];

                    var checks = lines.Except([test]).Select((x, i) => new { Value = CompareStrings(test, x), Index = i });

                    var match = checks.FirstOrDefault(x => x.Value.Count() == test.Length - 1);

                    if (match != null)
                    {
                        var similarChars = string.Join("", match.Value);
                        Console.WriteLine(similarChars);
                        break;
                    }
                }
            }
        }
    }
}
