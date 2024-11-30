using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day19
    {
        public static void Part1()
        {
            int count = 0;
            Dictionary<string, string> rules = new Dictionary<string, string>();

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input19.txt")))
            {
                string input = reader.ReadLine();
                // Get all the rules
                while (!string.IsNullOrEmpty(input))
                {
                    string[] split = input.Split(": ");
                    rules.Add(split[0], split[1].Replace("\"", string.Empty));
                    input = reader.ReadLine();
                }

                StringBuilder expression = new StringBuilder("^" + rules["0"]);
                Regex digits = new Regex(@"\d+");
                string[] matches = digits.Matches(expression.ToString()).Select(x => x.Value.ToString()).ToArray();

                while (matches.Length > 0)
                {
                    for (int i = 0; i < matches.Length; i++)
                    {
                        expression = expression.Replace(matches[i], "(" + rules[matches[i]].Trim() + ")");
                    }

                    //Console.WriteLine(expression.ToString());
                    //Console.WriteLine("");
                    matches = digits.Matches(expression.ToString()).ToArray().Select(x => x.Value.ToString()).Distinct().ToArray();
                }

                expression.Append("$");
                //expression.Replace(" ", "");

                Console.WriteLine(expression);
                Regex check = new Regex(expression.ToString());

                do
                {
                    input = reader.ReadLine();
                    if (check.Matches(input).Count > 0)
                    {
                        count++;
                    }

                } while (!reader.EndOfStream);

            }

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            // Where is this??? I have the star???
        }
    }
}
