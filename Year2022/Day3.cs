using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day3
    {
        public class Fragments
        {
            public string s1 { get; set; }
            public string s2 { get; set; }
        }

        public class Frag2
        {
            public string s1 { get; set; }
            public string s2 { get; set; }
            public string s3 { get; set; }
        }

        public static void Part1()
        {
            var text = File.ReadAllLines("Input.txt").Select(x => new Fragments()
            {
                s1 = x.Substring(0, x.Length / 2),
                s2 = x.Substring(x.Length / 2)
            });

            var score = 0;

            foreach (var line in text)
            {
                var overlap = line.s1.Intersect(line.s2);
                var over = Convert.ToInt32(overlap.First());
                score += over > 96 ? over - 96 : over - 38;
            }

            Console.WriteLine(score);
        }

        public static void Part2()
        {
            var text = File.ReadAllLines("Input.txt");
            var groups = new List<Frag2>();

            for (int i = 0; i < text.Length - 2; i += 3)
            {
                groups.Add(new Frag2()
                {
                    s1 = text[i],
                    s2 = text[i + 1],
                    s3 = text[i + 2]
                });
            }

            var score = 0;

            foreach (var line in groups)
            {
                var overlap = line.s1.Intersect(line.s2.Intersect(line.s3));
                var over = Convert.ToInt32(overlap.First());
                score += over > 96 ? over - 96 : over - 38;
            }

            Console.WriteLine(score);
        }

    }
}
