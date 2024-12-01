using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day1
    {

        #region Original

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

        #endregion


        #region Optimized

        public static void Part1Optimized()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<int> left = new List<int>();
                List<int> right = new List<int>();
                do
                {
                    // Process line by line; O(n) vs O(4n)
                    var line = reader.ReadLine();

                    var numbers = line.Split("   ");
                    left.Add(int.Parse(numbers[0]));
                    right.Add(int.Parse(numbers[1]));
                } while (!reader.EndOfStream);

                // Sort() is more efficient than Order() or OrderBy()
                left.Sort();
                right.Sort();

                var distance = 0;
                for (int i = 0; i < left.Count; i++)
                {
                    distance += Math.Abs(left[i] - right[i]);
                }

                Console.WriteLine(distance);
            }
        }

        public static void Part2Optimized()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<int> left = new List<int>();
                List<int> right = new List<int>();

                do
                {
                    // Process line by line; O(n) vs O(4n)
                    var line = reader.ReadLine();
                    var numbers = line.Split("   ");

                    left.Add(int.Parse(numbers[0]));
                    right.Add(int.Parse(numbers[1]));
                } while (!reader.EndOfStream);

                // LINQ's "Max()" is apparently very slow. Bottlenecked algorithm with 60k ticks
                var leftMax = 0;
                foreach (var number in left)
                {
                    if (number > leftMax) { leftMax = number; }
                }

                var rightMax = 0;
                foreach (var number in right)
                {
                    if (number > rightMax) { rightMax = number; }
                }

                var max = Math.Max(leftMax, rightMax) + 1;

                // Old algorithm here was O(n^2). This is just O(n) [O(2n) if literal]
                int[] leftOccurrence = new int[max];
                int[] rightOccurrence = new int[max];
                for (int i = 0; i < left.Count; i++)
                {
                    leftOccurrence[left[i]]++;
                    rightOccurrence[right[i]]++;
                }

                var distance = 0;
                for (int i = 0; i < leftOccurrence.Length; i++)
                {
                    distance += i * leftOccurrence[i] * rightOccurrence[i];
                }


                Console.WriteLine(distance);
            }
        }

        #endregion

    }
}
