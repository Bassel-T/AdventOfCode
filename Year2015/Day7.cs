using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day7
    {
        private static ushort Evaluate(string key, Dictionary<string, string> rules, Dictionary<string, ushort> parsed)
        {
            if (int.TryParse(key, out var value)) { return (ushort)(value & 65535); }
            if (parsed.ContainsKey(key)) return parsed[key];

            var expression = rules[key].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ushort result = 0;

            if (expression.Length == 1)
            {
                result = Evaluate(expression[0], rules, parsed);
            }
            else if (expression.Length == 2)
            {
                // "Not" is the only rule here
                result = (ushort)~Evaluate(expression[1], rules, parsed);
            }
            else
            {
                ushort left = (ushort)Evaluate(expression[0], rules, parsed);
                ushort right = (ushort)Evaluate(expression[2], rules, parsed);

                if (expression[1] == "AND")
                    result = (ushort)(left & right);
                else if (expression[1] == "OR")
                    result = (ushort)(left | right);
                else if (expression[1] == "LSHIFT")
                    result = (ushort)(left << right);
                else if (expression[1] == "RSHIFT")
                    result = (ushort)(left >> right);
            }

            result = (ushort)(result & 65535);
            parsed[key] = result;
            return result;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                Dictionary<string, string> rules = new Dictionary<string, string>();
                Dictionary<string, ushort> parsed = new Dictionary<string, ushort>();

                do
                {
                    var line = reader.ReadLine();
                    var inOut = line.Split(" -> ", StringSplitOptions.TrimEntries);
                    rules[inOut[1]] = inOut[0];
                } while (!reader.EndOfStream);

                Console.WriteLine(Evaluate("a", rules, parsed));
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                Dictionary<string, string> rules = new Dictionary<string, string>();
                Dictionary<string, ushort> parsed = new Dictionary<string, ushort>();

                do
                {
                    var line = reader.ReadLine();
                    var inOut = line.Split(" -> ", StringSplitOptions.TrimEntries);
                    rules[inOut[1]] = inOut[0];
                } while (!reader.EndOfStream);

                var newB = Evaluate("a", rules, parsed);
                parsed.Clear();
                parsed.Add("b", newB);
                Console.WriteLine(Evaluate("a", rules, parsed));
            }
        }
    }
}
