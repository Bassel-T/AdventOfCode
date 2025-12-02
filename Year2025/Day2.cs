using System.Text.RegularExpressions;

namespace AdventOfCode.Year2025
{
    public static class Day2
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var ranges = reader.ReadLine().Split(',');
                long invalid = 0;

                foreach (var range in ranges)
                {
                    var limits = range.Split('-').Select(long.Parse).ToArray();

                    for (long i = limits[0]; i <= limits[1]; i++)
                    {
                        var str = i.ToString();
                        var len = str.Length;
                        if (str.Substring(0, len / 2) == str.Substring(len / 2))
                        {
                            Console.WriteLine(str);
                            invalid += i;
                        }
                    }
                }

                Console.WriteLine(invalid);

            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var ranges = reader.ReadLine().Split(',');
                long invalid = 0;

                foreach (var range in ranges)
                {
                    var limits = range.Split('-').Select(long.Parse).ToArray();

                    for (long i = limits[0]; i <= limits[1]; i++)
                    {
                        var str = i.ToString();

                        for (int len = 1; len < str.Length; len++)
                        {
                            var substring = str.Substring(0, len);
                            if (str.Replace(substring, "").Length == 0)
                            {
                                Console.WriteLine(str);
                                invalid += i;
                                break;
                            }
                        }
                    }
                }

                Console.WriteLine(invalid);

            }
        }
    }
}
