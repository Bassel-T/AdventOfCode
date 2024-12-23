﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day11
    {
        private static int GetOccupied(string[] input, int i, int j)
        {
            int toReturn = 0;
            for (int x = i - 1; x < i + 2; x++)
            {
                for (int y = j - 1; y < j + 2; y++)
                {
                    if (x < 0 || y < 0 || x >= input.Length || y >= input[x].Length || (x == i && j == y))
                    {
                        // Out of bounds or is current seat
                        continue;
                    }

                    if (input[x].Substring(y, 1) == "#")
                    {
                        // Seat is full, increment
                        toReturn++;
                    }
                }
            }

            return toReturn;
        }

        // Check distances in straight lines
        private static int FarCheck(string[] input, int i, int j)
        {
            int toReturn = 0;

            // Up
            for (int x = i - 1; x >= 0; x--)
            {
                string place = input[x].Substring(j, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            // Down
            for (int x = i + 1; x < input.Length; x++)
            {
                string place = input[x].Substring(j, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            // Left
            for (int y = j - 1; y >= 0; y--)
            {
                string place = input[i].Substring(y, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            // Right
            for (int y = j + 1; y < input[i].Length; y++)
            {
                string place = input[i].Substring(y, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            // Top-Left
            for (int k = 1; i - k > -1 && j - k > -1; k++)
            {
                string place = input[i - k].Substring(j - k, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            // Top-Right
            for (int k = 1; i - k > -1 && j + k < input[i].Length; k++)
            {
                string place = input[i - k].Substring(j + k, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            // Bottom-Left
            for (int k = 1; i + k < input.Length && j - k > -1; k++)
            {
                string place = input[i + k].Substring(j - k, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            // Bottom-Right
            for (int k = 1; i + k < input.Length && j + k < input[i + k].Length; k++)
            {
                string place = input[i + k].Substring(j + k, 1);
                if (place == "#")
                {
                    toReturn++;
                    break;
                }
                else if (place == "L")
                {
                    break;
                }
            }

            return toReturn;
        }

        public static void Part1()
        {
            // Initialize variables & Input
            string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input11.txt"));
            bool equal = false;
            int count = 0;

            do
            {
                // Copy current output
                string[] newInput = (string[])input.Clone();
                count = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    string line = "";
                    // Generate the line based on previous iteration
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        int amount = GetOccupied(input, i, j);

                        if (input[i].Substring(j, 1) == ".")
                        {
                            line += ".";
                        }
                        else if (input[i].Substring(j, 1) == "L")
                        {
                            if (amount == 0)
                            {
                                line += "#";
                                count++;
                            }
                            else
                            {
                                line += "L";
                            }
                        }
                        else if (input[i].Substring(j, 1) == "#")
                        {
                            if (amount >= 4)
                            {
                                line += "L";
                            }
                            else
                            {
                                line += "#";
                                count++;
                            }
                        }
                    }

                    // Input next iteration
                    newInput[i] = line;
                }

                // Check if the iteration is unchanged
                equal = Enumerable.SequenceEqual(newInput, input);
                input = (string[])newInput.Clone();
            } while (!equal);

            // Count all filled seats
            int secondCount = 0;
            foreach (string line in input)
            {
                secondCount += Array.FindAll(line.ToCharArray(), x => x == '#').Length;
            }

            Console.WriteLine(secondCount);
        }

        public static void Part2()
        {
            // Get user input
            string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Input11.txt"));
            bool equal = false;
            int count = 0;

            do
            {
                // Clone the input
                string[] newInput = (string[])input.Clone();
                count = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    string line = "";
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        int amount = FarCheck(input, i, j);

                        // Find data for the line
                        if (input[i].Substring(j, 1) == ".")
                        {
                            line += ".";
                        }
                        else if (input[i].Substring(j, 1) == "L")
                        {
                            if (amount == 0)
                            {
                                line += "#";
                                count++;
                            }
                            else
                            {
                                line += "L";
                            }
                        }
                        else if (input[i].Substring(j, 1) == "#")
                        {
                            if (amount >= 5)
                            {
                                line += "L";
                            }
                            else
                            {
                                line += "#";
                                count++;
                            }
                        }
                    }

                    newInput[i] = line;
                }

                // Check for equality
                equal = Enumerable.SequenceEqual(newInput, input);
                input = (string[])newInput.Clone();
            } while (!equal);

            // Count full seats
            int secondCount = 0;
            foreach (string line in input)
            {
                secondCount += Array.FindAll(line.ToCharArray(), x => x == '#').Length;
            }

            Console.WriteLine(secondCount);
        }
    }
}
