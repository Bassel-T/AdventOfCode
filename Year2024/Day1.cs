using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day1
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<string> lines = reader.ReadToEnd().Split('\n').ToList();

                List<int> leftColumn = new List<int>();
                List<int> rightColumn = new List<int>();

                foreach (var line in lines)
                {
                    var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    leftColumn.Add(int.Parse(numbers[0]));
                    rightColumn.Add(int.Parse(numbers[1]));
                }

                leftColumn = leftColumn.OrderBy(x => x).ToList();
                rightColumn = rightColumn.OrderBy(x => x).ToList();

                int distance = 0;

                for (int i = 0; i < leftColumn.Count; i++)
                {
                    distance += Math.Abs(leftColumn[i] - rightColumn[i]);
                }

                Console.WriteLine(distance);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<string> lines = reader.ReadToEnd().Split('\n').ToList();

                List<int> leftColumn = new List<int>();
                List<int> rightColumn = new List<int>();

                foreach (var line in lines)
                {
                    var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    leftColumn.Add(int.Parse(numbers[0]));
                    rightColumn.Add(int.Parse(numbers[1]));
                }

                int distance = 0;

                for (int i = 0; i < leftColumn.Count; i++)
                {
                    distance += leftColumn[i] * rightColumn.Count(x => x == leftColumn[i]);
                }

                Console.WriteLine(distance);
            }
        }
    }
}
