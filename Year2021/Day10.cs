using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day10
    {
        public static void Part1()
        {
            string[] lines = File.ReadAllLines("Input10.txt");
            int error = 0;
            foreach (string chunks in lines)
            {
                Stack<char> toClose = new Stack<char>();
                foreach (char delim in chunks)
                {
                    if (delim == '(' || delim == '[' || delim == '{' || delim == '<')
                    {
                        toClose.Push(delim);
                    }

                    if (delim == ')')
                    {
                        if (toClose.Peek() == '(')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error += 3;
                            break;
                        }
                    }

                    if (delim == ']')
                    {
                        if (toClose.Peek() == '[')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error += 57;
                            break;
                        }
                    }

                    if (delim == '}')
                    {
                        if (toClose.Peek() == '{')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error += 1197;
                            break;
                        }
                    }

                    if (delim == '>')
                    {
                        if (toClose.Peek() == '<')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error += 25137;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(error);
        }

        public static void Part2()
        {
            string[] lines = File.ReadAllLines("Input10.txt");
            List<long> remaining = new List<long>();
            foreach (string chunks in lines)
            {
                Stack<char> toClose = new Stack<char>();
                bool error = false;
                foreach (char delim in chunks)
                {
                    if (delim == '(' || delim == '[' || delim == '{' || delim == '<')
                    {
                        toClose.Push(delim);
                    }

                    if (delim == ')')
                    {
                        if (toClose.Peek() == '(')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }

                    if (delim == ']')
                    {
                        if (toClose.Peek() == '[')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }

                    if (delim == '}')
                    {
                        if (toClose.Peek() == '{')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }

                    if (delim == '>')
                    {
                        if (toClose.Peek() == '<')
                        {
                            toClose.Pop();
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }
                }

                if (error)
                {
                    continue;
                }

                long sum = 0;

                while (toClose.Count != 0)
                {
                    sum *= 5;
                    switch (toClose.Pop())
                    {
                        case '(':
                            ++sum;
                            break;
                        case '[':
                            sum += 2;
                            break;
                        case '{':
                            sum += 3;
                            break;
                        case '<':
                            sum += 4;
                            break;
                    }
                }

                if (sum > 0)
                {
                    remaining.Add(sum);
                }
            }

            remaining.Sort();

            Console.WriteLine(remaining[remaining.Count / 2]);
        }
    }
}
