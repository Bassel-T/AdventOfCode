using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day24
    {
        private static List<ushort> ExpectedOutput(Dictionary<string, ushort> parsed)
        {
            var xWires = parsed.Keys.Where(x => Regex.IsMatch(x, @"x[0-9]+")).OrderBy(x => x).ToList();
            var xOut = xWires.Select(x => parsed[x]).ToList();
            var x = Convert.ToInt64(string.Join("", xOut.Select(x => x.ToString())), 2);
            
            var yWires = parsed.Keys.Where(x => Regex.IsMatch(x, @"y[0-9]+")).OrderBy(x => x).ToList();
            var yOut = yWires.Select(x => parsed[x]).ToList();
            var y = Convert.ToInt64(string.Join("", xOut.Select(x => x.ToString())), 2);

            return Convert.ToString(x + y, 2).Select(x => ushort.Parse($"{x}")).ToList();
        }

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
            else
            {
                ushort left = (ushort)Evaluate(expression[0], rules, parsed);
                ushort right = (ushort)Evaluate(expression[2], rules, parsed);

                if (expression[1] == "AND")
                    result = (ushort)(left & right);
                else if (expression[1] == "OR")
                    result = (ushort)(left | right);
                else if (expression[1] == "XOR")
                    result = (ushort)(left ^ right);
            }

            result = (ushort)(result & 65535);
            parsed[key] = result;
            return result;
        }

        private static bool IsFirstLevel(KeyValuePair<string, List<string>> item)
        {
            return (Regex.IsMatch(item.Value[0], @"x[0-9]+") && Regex.IsMatch(item.Value[2], @"y[0-9]+"))
            || (Regex.IsMatch(item.Value[0], @"y[0-9]+") && Regex.IsMatch(item.Value[2], @"x[0-9]+"));
        }

        private static bool ZBitRight(KeyValuePair<string, List<string>> zBit, string currentGate, string carryGate)
        {
            return (zBit.Value[0] == currentGate && zBit.Value[2] == carryGate)
            || (zBit.Value[0] == carryGate && zBit.Value[2] == currentGate);
        }


        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                Dictionary<string, string> rules = new Dictionary<string, string>();
                Dictionary<string, ushort> parsed = new Dictionary<string, ushort>();

                var line = reader.ReadLine();

                while (!string.IsNullOrWhiteSpace(line))
                {
                    var def = line.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                    parsed[def[0]] = ushort.Parse(def[1]);

                    line = reader.ReadLine();
                }

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var inOut = line.Split(" -> ", StringSplitOptions.TrimEntries);
                    rules[inOut[1]] = inOut[0];
                }

                List<int> outputs = new List<int>();
                List<string> testChars = rules.Keys.Where(x => Regex.IsMatch(x, "z[0-9]+")).OrderByDescending(x => x).ToList();

                foreach (var rule in testChars)
                {
                    outputs.Add(Evaluate(rule, rules, parsed));
                }

                var output = Convert.ToUInt64(string.Join("", outputs), 2);

                Console.WriteLine(output);
            }
        }

        public static void Part2()
        {
            Dictionary<string, List<string>> gates = new();

            using (var reader = new StreamReader("input.txt"))
            {
                // Don't need starting inputs
                while (!string.IsNullOrWhiteSpace(reader.ReadLine())) ;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var fragments = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    var requirements = fragments[0].Split(" ", StringSplitOptions.TrimEntries).ToList();

                    gates[fragments[1]] = requirements;
                }

                var wrong = gates.Where(item =>
                {
                    // The gate going into the output (except for the last one) isn't an xor
                    var isOutput = item.Key.StartsWith("z");
                    var isNotLastCarry = item.Key != "z45";
                    var isNotXor = item.Value[1] != "XOR";
                    return isOutput && isNotLastCarry && isNotXor;
                }).Select(item => item.Key).ToHashSet();

                if (gates["z45"][1] != "OR") { wrong.Add("z45"); }

                var firstXor = gates.Where(item =>
                {
                    // Non-output xor gates don't start with x or y items
                    var isNotOutput = !item.Key.StartsWith("z");
                    var leftInvalid = !(item.Value[0].StartsWith("x") || item.Value[0].StartsWith("y"));
                    var rightInvalid = !(item.Value[2].StartsWith("x") || item.Value[2].StartsWith("y"));
                    var isXor = item.Value[1] == "XOR";
                    return isNotOutput && leftInvalid && rightInvalid && isXor;
                }).Select(item => item.Key);

                foreach (var item in firstXor)
                {
                    wrong.Add(item);
                }

                // All AND gates point into OR gates except the first one
                var notFirstAndGates = gates.Where(item =>
                {
                    var isAnd = item.Value[1] == "AND";
                    var isNotFirst = item.Value[0] != "x00" && item.Value[0] != "y00" && item.Value[2] != "x00" && item.Value[2] != "y00";
                    return isNotFirst && isAnd;
                });

                var wrongAndGates = notFirstAndGates.Where(item =>
                {
                    return gates.Any(parent =>
                    {
                        var isChild = item.Key == parent.Value[0] || item.Key == parent.Value[2];
                        var isNotParentOr = parent.Value[1] != "OR";
                        return isChild && isNotParentOr;
                    });
                });

                foreach (var gate in wrongAndGates)
                {
                    wrong.Add(gate.Key);
                }

                // XOR gates can never point into OR gates
                var xorGates = gates.Where(item => {
                    var isXor = item.Value[1] == "XOR";
                    var isChildOfOr = gates.Any(parent =>
                    {
                        var isChild = item.Key == parent.Value[0] || item.Key == parent.Value[2];
                        var isParentOr = parent.Value[1] == "OR";
                        return isChild && isParentOr;
                    });

                    return isXor && isChildOfOr;
                });

                foreach (var gate in xorGates)
                {
                    wrong.Add(gate.Key);
                }

                // Generate output
                wrong = wrong.Order().ToHashSet();
                Console.WriteLine(string.Join(",", wrong));
            }
        }
    }
}
