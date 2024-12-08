using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day8
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var totalCode = 0;
                var totalMemory = 0;

                var hexEscape = new Regex(@"\\x[0-9a-fA-F]{2}");
                var quoteEscape = new Regex(@"\\\""");
                var backslash = new Regex(@"\\\\");

                do
                {
                    var line = reader.ReadLine();

                    totalCode += line.Length;
                    string memString = line.Substring(1, line.Length - 2);

                    memString = hexEscape.Replace(memString, "s");
                    memString = quoteEscape.Replace(memString, "\"");
                    memString = backslash.Replace(memString, "\\");

                    totalMemory += memString.Length;

                    Console.WriteLine($"{line.Length} , {memString.Length}");

                } while (!reader.EndOfStream);

                Console.WriteLine(totalCode - totalMemory);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var totalOld = 0;
                var totalNew = 0;

                do
                {
                    var line = reader.ReadLine();

                    totalOld += line.Length;

                    string newString = "\"";

                    foreach (var character in line)
                    {
                        if (character == '\\')
                            newString += "\\\\";
                        else if (character == '\"')
                            newString += "\\\"";
                        else
                            newString += character;
                    }

                    newString += "\"";

                    totalNew += newString.Length;

                } while (!reader.EndOfStream);

                Console.WriteLine(totalNew - totalOld);
            }
        }
    }
}
