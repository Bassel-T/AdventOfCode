using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016
{
    public static class Day4
    {
        private class Day4Helper : IComparable
        {
            public char character;
            public int count;

            public Day4Helper(char ch, int co)
            {
                character = ch;
                count = co;
            }

            public int CompareTo(object obj)
            {
                Day4Helper other = (Day4Helper)obj;

                if (count != other.count)
                {
                    return count.CompareTo(other.count);
                }

                return -character.CompareTo(other.character);
            }
        }

        public static List<string> Part1()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DayFour.txt"));

            List<string> validRooms = new List<string>();
            int sum = 0;

            // Name-sector[checksum]

            foreach (string line in lines)
            {

                string name = (new Regex(@"^[^\d]+")).Match(line).Value;
                name = name.Replace("-", "");
                int[] counts = new int[26];

                foreach (char item in name)
                {
                    // -97
                    counts[(int)item - 97]++;
                }

                List<Day4Helper> sorted = new List<Day4Helper>();

                for (int i = 0; i < 26; i++)
                {
                    sorted.Add(new Day4Helper((char)(i + 97), counts[i]));

                    if (sorted.Count > 5)
                    {
                        sorted.Sort();
                        sorted.RemoveAt(0);
                        sorted.Reverse();
                    }
                }

                string checkSum = (new Regex(@"\[\w+\]")).Match(line).Value;
                checkSum = checkSum.Substring(1, checkSum.Length - 2);

                bool valid = true;

                for (int i = 0; i < 5; i++)
                {
                    if (checkSum[i] != sorted[i].character)
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    string value = (new Regex(@"\d+")).Match(line).Value;
                    validRooms.Add(line);
                    // sum += Convert.ToInt32(value);
                }
            }

            return validRooms;
            // Console.WriteLine(sum);
        }

        public static void Part2()
        {
            List<string> validRooms = Part1();

            foreach (string room in validRooms)
            {
                Console.WriteLine(room);
                string name = (new Regex(@"^[^\d]+")).Match(room).Value;
                int value = Convert.ToInt32((new Regex(@"\d+")).Match(room).Value);

                string realName = "";
                foreach (char c in name)
                {
                    if (c == '-') { continue; }
                    char clone = c;
                    for (int i = 0; i < value; i++)
                    {
                        clone++;
                        if (clone == '{')
                        {
                            clone = 'a';
                        }
                    }

                    realName += clone;
                }

                Console.WriteLine($"{realName} : {value}");
            }
        }
    }
}
