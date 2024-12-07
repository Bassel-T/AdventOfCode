using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
    public static class Day4
    {
        public static void Part1()
        {
            int[] range = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input4.txt"))
                .Split('-').Select(x => int.Parse(x)).ToArray();
            int count = 0;

            for (int i = range[0]; i <= range[1]; i++)
            {
                string check = i.ToString();
                bool repeat = false;
                bool valid = true;
                for (int j = 0; j < check.Length - 1; j++)
                {
                    if (check[j] == check[j + 1])
                    {
                        repeat = true;
                    }
                    if (int.Parse(check[j].ToString()) > int.Parse(check[j + 1].ToString()))
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid && repeat)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            int[] range = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Input4.txt"))
                .Split('-').Select(x => int.Parse(x)).ToArray();
            int count = 0;

            for (int i = range[0]; i <= range[1]; i++)
            {
                string check = i.ToString();
                bool repeat = false;
                bool valid = true;
                for (int j = 0; j < check.Length - 2; j++)
                {
                    if (check[j] == check[j + 1] && check[j] != check[j + 2])
                    {
                        if (j > 0)
                        {
                            if (check[j] != check[j - 1])
                            {
                                repeat = true;
                            }
                        }
                        else
                        {
                            repeat = true;
                        }
                    }
                    if (int.Parse(check[j].ToString()) > int.Parse(check[j + 1].ToString()))
                    {
                        valid = false;
                        break;
                    }
                }

                if (check[4] == check[5] && check[3] != check[4])
                {
                    repeat = true;
                }
                if (int.Parse(check[4].ToString()) > int.Parse(check[5].ToString()))
                {
                    valid = false;
                }

                if (valid && repeat)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
