using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day11
    {
        class Group11
        {
            public Queue<long> Item { get; set; } = new Queue<long>();
            public char Operation { get; set; }
            public long? Modifier { get; set; }
            public int Divisibility { get; set; }
            public int TrueCase { get; set; }
            public int FalseCase { get; set; }
            public long Analyzed { get; set; }

            public Group11(string s)
            {
                Regex num = new Regex(@"[0-9]+");
                var lines = s.Split("\r\n");

                var items = num.Matches(lines[1]).Select(x => int.Parse(x.Value)).ToList();
                foreach (var item in items)
                {
                    Item.Enqueue(item);
                }

                Operation = lines[2].First(x => x == '+' || x == '*');
                if (long.TryParse(num.Match(lines[2]).Value, out long possible))
                {
                    Modifier = possible;
                }
                else
                {
                    Modifier = null;
                }

                Divisibility = int.Parse(num.Match(lines[3]).Value);
                TrueCase = int.Parse(num.Match(lines[4]).Value);
                FalseCase = int.Parse(num.Match(lines[5]).Value);
            }

            public long Analyze1()
            {
                Analyzed++;
                long worry = 0;
                if (Operation == '*')
                {
                    worry = Item.Peek() * (Modifier ?? Item.Peek());
                }
                else if (Operation == '+')
                {
                    worry = Item.Peek() + (Modifier ?? Item.Peek());
                }

                return worry / 3;
            }

            public long Analyze2()
            {
                Analyzed++;
                long worry = 0;
                if (Operation == '*')
                {
                    worry = Item.Peek() * (Modifier ?? Item.Peek());
                }
                else if (Operation == '+')
                {
                    worry = Item.Peek() + (Modifier ?? Item.Peek());
                }

                return worry;
            }
        }

        public static void Part1()
        {
            List<Group11> monkeys = File.ReadAllText("Input.txt").Split("\r\n\r\n").Select(x => new Group11(x)).ToList();

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Item.Count != 0)
                    {
                        var newWorry = monkey.Analyze1();
                        if (newWorry % monkey.Divisibility == 0)
                        {
                            monkeys[monkey.TrueCase].Item.Enqueue(newWorry);
                        }
                        else
                        {
                            monkeys[monkey.FalseCase].Item.Enqueue(newWorry);
                        }

                        monkey.Item.Dequeue();
                    }
                }
            }

            var asList = monkeys.OrderByDescending(x => x.Analyzed).ToList();
            Console.WriteLine(asList[0].Analyzed * asList[1].Analyzed);

        }

        public static void Part2()
        {
            List<Group11> monkeys = File.ReadAllText("Input.txt").Split("\r\n\r\n").Select(x => new Group11(x)).ToList();
            var superMod = 1;

            monkeys.ForEach(x => superMod *= x.Divisibility);

            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Item.Any())
                    {
                        var newWorry = monkey.Analyze2() % superMod;
                        if (newWorry % monkey.Divisibility == 0)
                        {
                            monkeys[monkey.TrueCase].Item.Enqueue(newWorry);
                        }
                        else
                        {
                            monkeys[monkey.FalseCase].Item.Enqueue(newWorry);
                        }

                        monkey.Item.Dequeue();
                    }
                }
            }

            var asList = monkeys.OrderByDescending(x => x.Analyzed).ToList();
            Console.WriteLine(asList[0].Analyzed * asList[1].Analyzed);
        }

    }
}
