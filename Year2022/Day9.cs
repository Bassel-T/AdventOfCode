using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day9
    {
        class Group9
        {
            public int x { get; set; } = 0;
            public int y { get; set; } = 0;
        }

        class Group9Instruction
        {
            public string Dir { get; set; }
            public int Count { get; set; }

            public Group9Instruction(string s)
            {
                var frags = s.Split(' ');
                Dir = frags[0];
                Count = int.Parse(frags[1]);
            }
        }

        public static void Part1()
        {
            var text = File.ReadAllLines("Input.txt");

            var head = new Group9();
            var tail = new Group9();
            List<Group9> tailVisits = new List<Group9>();
            tailVisits.Add(new Group9() { x = 0, y = 0 });

            foreach (var line in text)
            {
                var instruc = new Group9Instruction(line);

                for (int i = 0; i < instruc.Count; i++)
                {
                    switch (instruc.Dir)
                    {
                        case "U":
                            head.y++;
                            break;
                        case "D":
                            head.y--;
                            break;
                        case "L":
                            head.x--;
                            break;
                        case "R":
                            head.x++;
                            break;
                    }

                    if (Math.Abs(head.x - tail.x) < 2 && Math.Abs(head.y - tail.y) < 2)
                    {
                        continue;
                    }

                    var deltaX = head.x - tail.x;
                    var deltaY = head.y - tail.y;

                    tail.x += Math.Sign(deltaX);
                    tail.y += Math.Sign(deltaY);

                    if (!tailVisits.Any(x => x.x == tail.x && x.y == tail.y))
                    {
                        tailVisits.Add(new Group9()
                        {
                            x = tail.x,
                            y = tail.y
                        });
                    }
                }

            }

            Console.WriteLine(tailVisits.Count());
        }

        public static void Part2()
        {
            var text = File.ReadAllLines("Input.txt");

            var head = new Group9();
            var tails = new List<Group9>();
            for (int i = 0; i < 9; i++)
            {
                tails.Add(new Group9());
            }

            List<Group9> tailVisits = new List<Group9>();
            tailVisits.Add(new Group9() { x = 0, y = 0 });

            foreach (var line in text)
            {
                var instruc = new Group9Instruction(line);

                for (int i = 0; i < instruc.Count; i++)
                {
                    switch (instruc.Dir)
                    {
                        case "U":
                            head.y++;
                            break;
                        case "D":
                            head.y--;
                            break;
                        case "L":
                            head.x--;
                            break;
                        case "R":
                            head.x++;
                            break;
                    }

                    if (Math.Abs(head.x - tails.First().x) < 2 && Math.Abs(head.y - tails.First().y) < 2)
                    {
                        continue;
                    }

                    var deltaX = head.x - tails.First().x;
                    var deltaY = head.y - tails.First().y;

                    tails.First().x += Math.Sign(deltaX);
                    tails.First().y += Math.Sign(deltaY);

                    for (int next = 1; next < tails.Count; next++)
                    {
                        if (Math.Abs(tails[next - 1].x - tails[next].x) < 2 && Math.Abs(tails[next - 1].y - tails[next].y) < 2)
                        {
                            continue;
                        }

                        deltaX = tails[next - 1].x - tails[next].x;
                        deltaY = tails[next - 1].y - tails[next].y;

                        tails[next].x += Math.Sign(deltaX);
                        tails[next].y += Math.Sign(deltaY);
                    }

                    if (!tailVisits.Any(x => x.x == tails.Last().x && x.y == tails.Last().y))
                    {
                        tailVisits.Add(new Group9()
                        {
                            x = tails.Last().x,
                            y = tails.Last().y
                        });
                    }
                }

            }

            Console.WriteLine(tailVisits.Count());
        }

    }
}
