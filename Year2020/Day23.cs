using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day23
    {
        private static string input = "389125467";

        public static void Part1()
        {
            for (int i = input.Length; i < 10 + input.Length; i++)
            {
                int curr = i % input.Length;
                string move = "";
                if (curr + 3 >= input.Length)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if (curr + j == input.Length) { break; }
                        move += input.Substring(curr + j, 1);
                    }

                    input = input.Replace(move, "");

                    if (move.Length < 3)
                    {
                        move += input.Substring(0, 3 - move.Length);
                        input = input.Remove(0, 3 - move.Length);
                    }
                }
                else
                {
                    move = input.Substring(curr + 1, 3);
                    input = input.Remove(curr + 1, 3);
                }

                char destination = (char)(Convert.ToInt32(input[curr]) - 1);

                while (!input.Contains(destination))
                {
                    destination = (char)(Convert.ToInt32(destination) - 1);
                    if (destination == '0') { destination = '9'; }
                }

                input = input.Insert(input.IndexOf(destination) + 1, move);
            }

            Console.WriteLine(input);
        }

        public static void Part2()
        {
            // Where is this??? I have the star???
        }
    }
}
