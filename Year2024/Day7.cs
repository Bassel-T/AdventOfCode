using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day7
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                long score = 0;

                do
                {
                    var line = reader.ReadLine();

                    var parts = line.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                    long target = long.Parse(parts[0]);
                    List<long> potentials = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToList();

                    for (long i = 0; i < Math.Pow(2, potentials.Count - 1); i++)
                    {
                        long result = potentials[0];
                        for (int  j = 1; j < potentials.Count; j++)
                        {
                            switch ((i / (int)Math.Pow(2, j - 1)) & 1)
                            {
                                case 0:
                                    result += potentials[j];
                                    break;
                                case 1:
                                    result *= potentials[j];
                                    break;
                                default:
                                    throw new Exception("Quantum computing achieved.");
                            }

                            if (result > target) break;
                        }

                        if (result == target)
                        {
                            Console.WriteLine($"{target} works!");
                            score += target;
                            break;
                        }
                    }

                } while (!reader.EndOfStream);

                Console.WriteLine(score);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                long score = 0;

                do
                {
                    var line = reader.ReadLine();

                    var parts = line.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                    long target = long.Parse(parts[0]);
                    List<long> potentials = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToList();

                    for (long i = 0; i < Math.Pow(3, potentials.Count - 1); i++)
                    {
                        long result = potentials[0];
                        for (int j = 1; j < potentials.Count; j++)
                        {
                            switch ((i / (int)Math.Pow(3, j - 1)) % 3)
                            {
                                case 0:
                                    result += potentials[j];
                                    break;
                                case 1:
                                    result *= potentials[j];
                                    break;
                                case 2:
                                    result = long.Parse($"{result}{potentials[j]}");
                                    break;
                                default:
                                    throw new Exception("Quantum computing achieved.");
                            }

                            if (result > target) break;
                        }

                        if (result == target)
                        {
                            Console.WriteLine($"{target} works!");
                            score += target;
                            break;
                        }
                    }

                } while (!reader.EndOfStream);

                Console.WriteLine(score);
            }
        }
    }
}
