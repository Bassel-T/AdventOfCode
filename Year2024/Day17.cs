using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode.Year2024
{
    public static class Day17
    {
        private static long DiscoverRegisterA(List<int> values, int index, long currentValue)
        {
            if (index == values.Count) return currentValue;

            for (long i = 0; i < 8; i++)
            {
                long nextValue = (currentValue << 3) + i;
                int value = (int)(((((nextValue % 8) ^ 5) ^ 6) ^ (nextValue >> (int)((nextValue % 8) ^ 5))) % 8);

                if (value == values[values.Count - 1 - index])
                {
                    var result = DiscoverRegisterA(values, index + 1, nextValue);
                    if (result != -1) return result;
                }
            }

            return -1;
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                // reader.ReadLine();
                ulong regA = ulong.Parse(Regex.Match(reader.ReadLine(), @"(\d+)").Value);
                ulong regB = ulong.Parse(Regex.Match(reader.ReadLine(), @"(\d+)").Value);
                ulong regC = ulong.Parse(Regex.Match(reader.ReadLine(), @"(\d+)").Value);

                reader.ReadLine();
                var instructions = reader.ReadLine().Substring(9).Split(',').Select(x => ulong.Parse(x)).ToList();
                var output = new List<ulong>();

                for (int instructionPoulonger = 0; instructionPoulonger < instructions.Count; instructionPoulonger += 2)
                {
                    var opCode = instructions[instructionPoulonger];
                    int literalOp = (int)instructions[instructionPoulonger + 1];

                    ulong comboOp = (literalOp) switch
                    {
                        0 => 0,
                        1 => 1,
                        2 => 2,
                        3 => 3,
                        4 => regA,
                        5 => regB,
                        6 => regC,
                        _ => throw new NotImplementedException()
                    };

                    switch (opCode)
                    {
                        case 0:
                            regA = regA / (ulong)Math.Pow(2, comboOp);
                            break;
                        case 1:
                            regB = regB ^ (ulong)literalOp;
                            break;
                        case 2:
                            regB = comboOp % 8;
                            break;
                        case 3:
                            if (regA != 0)
                                instructionPoulonger = literalOp - 2; // -2 because of the increment in the for loop
                            break;
                        case 4:
                            regB = regB ^ regC;
                            break;
                        case 5:
                            output.Add(comboOp % 8);
                            var nextPoulonger = instructionPoulonger + 2;
                            break;
                        case 6:
                            regB = regA / (ulong)Math.Pow(2, comboOp);
                            break;
                        case 7:
                            regC = regA / (ulong)Math.Pow(2, comboOp);
                            break;
                    }
                }

                Console.WriteLine(string.Join(",", output));
            }
        }

        public static void Part2()
        {
            // I analyzed the program and simplified it to the following:
            // My formula: Print: (6 ^ ((A % 8) ^ 5)) ^ (A >> ((A % 8) ^ 5))
            // A = A >> 3

            // We bit shift right by 3 at the end of every iteration
            // This means we need 48 bits of information. 
            // Therefore, these need to be long values
            
            // These are processed one chunk at a time... We don't need to brute force everything...
            // Find the three bits that give us the output we want, bit shift them... Move on.

            using (var reader = new StreamReader("input.txt"))
            {
                reader.ReadLine(); // A
                reader.ReadLine(); // B
                reader.ReadLine(); // C
                reader.ReadLine(); // Blank

                var instructions = reader.ReadLine().Substring(9).Split(',').Select(int.Parse).ToList();
                long finalA = DiscoverRegisterA(instructions, 0, 0);

                Console.WriteLine(finalA);
            }
        }
    }
}
