using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day12
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var data = reader.ReadToEnd();
                var sum = FindSum(data, false);
                Console.WriteLine(sum);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var data = reader.ReadToEnd();

                var sum = FindSum(data, true);

                Console.WriteLine(sum);
            }
        }

        private static int FindSum(string data, bool removeRed)
        {
            int sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '[')
                {
                    // Handle array
                    int closingIndex = FindClosingBracket(data, i, '[', ']');
                    var substring = data.Substring(i + 1, closingIndex - i - 1);
                    sum += FindSum(substring, removeRed);
                    i = closingIndex;
                }
                else if (data[i] == '{')
                {
                    // Handle object
                    int closingIndex = FindClosingBracket(data, i, '{', '}');
                    var substring = data.Substring(i + 1, closingIndex - i - 1);

                    // Process the object contents from deepest level first
                    if (!removeRed || !ContainsRed(substring))
                    {
                        sum += FindSum(substring, removeRed);
                    }
                    i = closingIndex;
                }
                else if (char.IsDigit(data[i]) || (data[i] == '-' && char.IsDigit(data[i + 1])))
                {
                    // Parse number
                    int j = i + 1;
                    while (j < data.Length && char.IsDigit(data[j]))
                    {
                        j++;
                    }
                    sum += int.Parse(data[i..j]);
                    i = j - 1;
                }
            }

            return sum;
        }

        private static bool ContainsRed(string data)
        {
            // Check if the substring contains `"red"` as a value
            int colonIndex = data.IndexOf(":\"red\"");
            while (colonIndex != -1)
            {
                // Ensure `"red"` is a value, not part of a key
                if (colonIndex > 0 && data[colonIndex - 1] == '"')
                {
                    return true;
                }
                colonIndex = data.IndexOf(":\"red\"", colonIndex + 1);
            }
            return false;
        }

        private static int FindClosingBracket(string data, int startIndex, char open, char close)
        {
            // Find the closing bracket for the given opening bracket
            int depth = 0;
            for (int i = startIndex; i < data.Length; i++)
            {
                if (data[i] == open)
                {
                    depth++;
                }
                else if (data[i] == close)
                {
                    depth--;
                    if (depth == 0)
                    {
                        return i;
                    }
                }
            }
            throw new InvalidOperationException("No matching closing bracket found.");
        }
    }
}
