using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day5
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var lines = reader.ReadToEnd().Split("\r\n");
                var ranges = new List<(ulong, ulong)>();
                var checkFresh = false;
                var freshIds = 0;

                foreach (var line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        checkFresh = true;
                    }
                    else if (!checkFresh)
                    {
                        var extremes = line.Split('-').Select(ulong.Parse);
                        ranges.Add(new (extremes.First(), extremes.Last()));
                    }
                    else if (checkFresh)
                    {
                        var id = ulong.Parse(line);
                        if (ranges.Any(range => id >= range.Item1 && id <= range.Item2))
                        {
                            freshIds++;
                        }
                    }
                }

                Console.WriteLine(freshIds);
            }
        }

        private class Day5Event
        {
            public ulong Id { get; set; }
            public bool IsStart { get; set; }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var lines = reader.ReadToEnd().Split("\r\n");
                var events = new List<Day5Event>();
                ulong freshIds = 0;

                foreach (var line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    else
                    {
                        var extremes = line.Split('-').Select(ulong.Parse);

                        events.Add(new Day5Event { Id = extremes.First(), IsStart = true });
                        events.Add(new Day5Event { Id = extremes.Last(), IsStart = false });
                    }
                }

                events = events.OrderBy(e => e.Id).ThenBy(e => e.IsStart ? 0 : 1).ToList();

                var currentStart = events.First().Id;
                var currentEnd = events.First().Id;
                var layers = 0;

                foreach (var item in events)
                {
                    if (item.IsStart)
                    {
                        layers++;
                        
                        if (layers == 1)
                        {
                            currentStart = item.Id;
                        }
                    }
                    else
                    {
                        layers--;

                        if (layers == 0)
                        {
                            freshIds += item.Id - currentStart + 1;
                        }
                    }
                }

                Console.WriteLine(freshIds);
            }
        }
    }
}
