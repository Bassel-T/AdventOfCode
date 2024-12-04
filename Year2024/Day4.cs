using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day4
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var text = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray()).ToArray();

                int count = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < text[i].Length; j++)
                    {
                        if (text[i][j] != 'X')
                        {
                            continue;
                        }

                        if (i >= 3)
                        {
                            if (text[i - 1][j] == 'M' && text[i - 2][j] == 'A' && text[i - 3][j] == 'S')
                            {
                                count++;
                            }

                            if (j >= 3)
                            {
                                if (text[i - 1][j - 1] == 'M' && text[i - 2][j - 2] == 'A' && text[i - 3][j - 3] == 'S')
                                {
                                    count++;
                                }
                            }

                            if (j <= text[i].Length - 4)
                            {
                                if (text[i - 1][j + 1] == 'M' && text[i - 2][j + 2] == 'A' && text[i - 3][j + 3] == 'S')
                                {
                                    count++;
                                }
                            }
                        }

                        if (i <= text[i].Length - 4)
                        {
                            if (text[i + 1][j] == 'M' && text[i + 2][j] == 'A' && text[i + 3][j] == 'S')
                            {
                                count++;
                            }

                            if (j >= 3)
                            {
                                if (text[i + 1][j - 1] == 'M' && text[i + 2][j - 2] == 'A' && text[i + 3][j - 3] == 'S')
                                {
                                    count++;
                                }
                            }

                            if (j <= text[i].Length - 4)
                            {
                                if (text[i + 1][j + 1] == 'M' && text[i + 2][j + 2] == 'A' && text[i + 3][j + 3] == 'S')
                                {
                                    count++;
                                }
                            }
                        }

                        if (j >= 3)
                        {
                            if (text[i][j - 1] == 'M' && text[i][j - 2] == 'A' && text[i][j - 3] == 'S')
                            {
                                count++;
                            }
                        }

                        if (j <= text[i].Length - 4)
                        {
                            if (text[i][j + 1] == 'M' && text[i][j + 2] == 'A' && text[i][j + 3] == 'S')
                            {
                                count++;
                            }
                        }
                    }
                }

                Console.WriteLine(count);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var text = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray()).ToArray();

                int count = 0;

                for (int i = 1; i < text.Length - 1; i++)
                {
                    for (int j = 1; j < text[i].Length - 1; j++)
                    {
                        if (text[i][j] != 'A')
                        {
                            continue;
                        }

                        var instances = 0;

                        if (text[i - 1][j - 1] == 'M' && text[i + 1][j + 1] == 'S')
                        {
                            instances++;
                        }

                        if (text[i - 1][j - 1] == 'S' && text[i + 1][j + 1] == 'M')
                        {
                            instances++;
                        }

                        if (text[i + 1][j - 1] == 'M' && text[i - 1][j + 1] == 'S')
                        {
                            instances++;
                        }

                        if (text[i + 1][j - 1] == 'S' && text[i - 1][j + 1] == 'M')
                        {
                            instances++;
                        }

                        if (instances == 2)
                        {
                            count++;
                        }
                    }
                }

                Console.WriteLine(count);
            }
        }
    }
}
