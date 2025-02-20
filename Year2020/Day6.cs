﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day6
    {
        public static void Part1()
        {
            int sum = 0;

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input6.txt")))
            {

                // Initialize "found" chars from the group
                bool[] chars = new bool[26];

                do
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        // Reset input
                        chars = new bool[26];
                    }
                    else
                    {
                        foreach (char c in line)
                        {
                            // Analyze current boolean
                            int cAsB = Convert.ToByte(c) - 97;
                            if (!chars[cAsB])
                            {
                                // New char for group
                                chars[cAsB] = true;
                                sum++;
                            }
                        }
                    }

                } while (!reader.EndOfStream);
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            int sum = 0;

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input6.txt")))
            {
                // Initialize counts for group
                byte[] chars = new byte[26];
                int inGroup = 0;

                do
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        // Find all chars that match all
                        for (int i = 0; i < 26; i++)
                        {
                            if (chars[i] == inGroup)
                            {
                                sum++;
                            }
                        }

                        // Reset Values
                        chars = new byte[26];
                        inGroup = 0;
                    }
                    else
                    {
                        foreach (char c in line)
                        {
                            // Increment input
                            int cAsB = Convert.ToByte(c) - 97;
                            chars[cAsB]++;
                        }

                        // New person
                        inGroup++;
                    }

                } while (!reader.EndOfStream);

                // Extra check for last element
                for (int i = 0; i < 26; i++)
                {
                    if (chars[i] == inGroup)
                    {
                        sum++;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
