using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day5
    {
        public class Group5
        {
            public int Count { get; set; }
            public int From { get; set; }
            public int To { get; set; }
        }

        public static void Part1()
        {
            var text = File.ReadAllText("Input.txt");
            var frag = text.Split("\r\n\r\n");

            // frag[0] is the stack, frag[1] is the restfrag
            var inputStacks = frag[0].Split("\r\n").Reverse().ToList();
            var stacks = new List<List<char>>();

            stacks.Add(new List<char>());

            for (int i = 0; i < 9; i++)
            {
                stacks.Add(new List<char>());
            }

            for (int i = 1; i < inputStacks.Count; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (inputStacks[i][1 + 4 * j] != ' ')
                    {
                        stacks[j + 1].Add(inputStacks[i][1 + 4 * j]);
                    }
                }
            }

            Regex num = new Regex(@"[0-9]+");

            var movements = frag[1].Split("\r\n").Select(x => {
                var nums = num.Matches(x);
                return new Group5
                {
                    Count = int.Parse(nums[0].Value),
                    From = int.Parse(nums[1].Value),
                    To = int.Parse(nums[2].Value)
                };
            });

            foreach (var move in movements)
            {
                var temp = stacks[move.From].Skip(stacks[move.From].Count - move.Count).Reverse();
                stacks[move.To].AddRange(temp);
                stacks[move.From].RemoveRange(stacks[move.From].Count - move.Count, move.Count);
            }

            stacks.ForEach(x => {
                if (x.Any())
                {
                    Console.Write(x.Last());
                }
                else
                {
                    Console.Write(" ");
                }
            });
        }

        public static void Part2()
        {
            var text = File.ReadAllText("Input.txt");
            var frag = text.Split("\r\n\r\n");

            // frag[0] is the stack, frag[1] is the restfrag
            var inputStacks = frag[0].Split("\r\n").Reverse().ToList();
            var stacks = new List<List<char>>();

            stacks.Add(new List<char>());

            for (int i = 0; i < 9; i++)
            {
                stacks.Add(new List<char>());
            }

            for (int i = 1; i < inputStacks.Count; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (inputStacks[i][1 + 4 * j] != ' ')
                    {
                        stacks[j + 1].Add(inputStacks[i][1 + 4 * j]);
                    }
                }
            }

            Regex num = new Regex(@"[0-9]+");

            var movements = frag[1].Split("\r\n").Select(x => {
                var nums = num.Matches(x);
                return new Group5
                {
                    Count = int.Parse(nums[0].Value),
                    From = int.Parse(nums[1].Value),
                    To = int.Parse(nums[2].Value)
                };
            });

            foreach (var move in movements)
            {
                var temp = stacks[move.From].Skip(stacks[move.From].Count - move.Count);
                stacks[move.To].AddRange(temp);
                stacks[move.From].RemoveRange(stacks[move.From].Count - move.Count, move.Count);
            }

            stacks.ForEach(x => {
                if (x.Any())
                {
                    Console.Write(x.Last());
                }
                else
                {
                    Console.Write(" ");
                }
            });
        }

    }
}
