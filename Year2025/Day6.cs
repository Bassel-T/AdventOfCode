using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day6
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<List<long>> values = new List<List<long>>();

                var line = reader.ReadLine();
                
                do
                {
                    values.Add(line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList());
                    line = reader.ReadLine();
                } while (!reader.EndOfStream);

                var operations = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                long total = 0;

                for (int i = 0; i < operations.Count; i++)
                {
                    if (operations[i] == "*")
                    {
                        total += values.Select(x => x[i]).Aggregate(1l, (accumulator, nextItem) => accumulator * nextItem);
                    }
                    else if (operations[i] == "+")
                    {
                        total += values.Select(x => x[i]).Sum();
                    }
                    else
                    {
                        Console.WriteLine($"Error! Unknown property {operations[i]}");
                    }
                }

                Console.WriteLine(total);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<List<char>> values = new List<List<char>>();

                var line = reader.ReadLine();

                do
                {
                    values.Add(line.ToCharArray().ToList());
                    line = reader.ReadLine();
                } while (!reader.EndOfStream);

                var operations = line.ToCharArray().ToList();

                long total = 0;
                string opCode  = string.Empty;

                List<long> numbers = new List<long>();

                for (int i = 0; i < values[0].Count; i++)
                {
                    if (operations[i] == '*') opCode = "*";
                    else if (operations[i] == '+') opCode = "+";

                    if (values.All(x => x[i] == ' '))
                    {
                        if (opCode == "*")
                        {
                            Console.WriteLine(string.Join(opCode, numbers));
                            total += numbers.Aggregate(1l, (accumulator, nextItem) => accumulator * nextItem);
                        }
                        else if (opCode == "+")
                        {
                            Console.WriteLine(string.Join(opCode, numbers));
                            total += numbers.Sum();
                        }

                        numbers.Clear();
                    }
                    else
                    {
                        numbers.Add(long.Parse($"{values[0][i]}{values[1][i]}{values[2][i]}{values[3][i]}"));
                    }
                }

                if (opCode == "*")
                {
                    Console.WriteLine(string.Join(opCode, numbers));
                    total += numbers.Aggregate(1l, (accumulator, nextItem) => accumulator * nextItem);
                }
                else if (opCode == "+")
                {
                    Console.WriteLine(string.Join(opCode, numbers));
                    total += numbers.Sum();
                }

                Console.WriteLine(total);
            }
        }
    }
}
