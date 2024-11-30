using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day18
    {
        class Operator
        {
            char Operate;
            int InputPriority;
            int StackPriority;

            public Operator(char c)
            {
                Operate = c;

                if (c == '+')
                {
                    InputPriority = 2;
                    StackPriority = 2;
                }
                else if (c == '*')
                {
                    InputPriority = 1;
                    StackPriority = 1;
                }
                else if (c == '(')
                {
                    InputPriority = 6;
                    StackPriority = 0;
                }
                else if (c == ')')
                {
                    InputPriority = -5;
                    StackPriority = -5;
                }
                else if (c == '$')
                {
                    InputPriority = -5;
                    StackPriority = -1;
                }
            }

            public char getOperation()
            {
                return Operate;
            }

            public int getStackPriority()
            {
                return StackPriority;
            }

            public bool inputCheck(Operator other)
            {
                return InputPriority > other.StackPriority;
            }
        }

        class Calculator
        {
            Stack<ulong> Values;
            Stack<Operator> Operations;

            public Calculator(string input)
            {
                Values = new Stack<ulong>();
                Operations = new Stack<Operator>();

                Operations.Push(new Operator('$'));

                bool valid = true;

                foreach (char c in input)
                {
                    valid = push(c);
                }

                while (Operations.Peek().getOperation() != '$' && valid)
                {
                    valid = popAndProcess();
                    valid = valid && Operations.Peek().getOperation() != '(' && Operations.Peek().getOperation() != ')';
                }
            }

            public ulong getResult()
            {
                return Values.Pop();
            }

            bool push(char op)
            {
                bool valid = true;
                try
                {
                    Values.Push(ulong.Parse(op.ToString()));
                }
                catch (Exception e)
                {
                    Operator operate = new Operator(op);

                    if (operate.inputCheck(Operations.Peek()) && op != ')')
                    {
                        Operations.Push(operate);
                    }
                    else
                    {
                        if (op == ')')
                        {
                            if (Operations.Peek().getOperation() == '(')
                            {
                                valid = false;
                            }

                            while (Operations.Peek().getOperation() != '(')
                            {
                                valid = popAndProcess();

                                if (Operations.Peek().getOperation() == '$')
                                {
                                    valid = false;
                                    break;
                                }
                            }

                            if (Operations.Peek().getOperation() == '(')
                            {
                                Operations.Pop();
                            }
                        }
                        else if (op == '$')
                        {
                            valid = false;
                        }
                        else
                        {
                            valid = popAndProcess() && push(op);
                        }
                    }
                }

                return valid;
            }

            bool popAndProcess()
            {
                Operator curr = Operations.Pop();

                if (curr.getStackPriority() <= 0)
                {
                    return false;
                }

                ulong val2 = Values.Pop();
                ulong val1 = Values.Pop();

                Values.Push(doMath(val1, val2, curr));

                return true;
            }

            ulong doMath(ulong a, ulong b, Operator op)
            {
                if (op.getOperation() == '+')
                {
                    return a + b;
                }
                else
                {
                    // op.getOperation() == '*'
                    return a * b;
                }
            }
        }

        public static void Part1()
        {
            ulong sum = 0;
            int count = 1;

            Calculator calculator;

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input18.txt")))
            {
                do
                {
                    string input = reader.ReadLine();
                    input = input.Replace(" ", "");

                    calculator = new Calculator(input);
                    ulong result = (ulong)calculator.getResult();
                    sum += result;

                    Console.WriteLine($"Expression {count} resuted in {result}");
                    count++;

                } while (!reader.EndOfStream);
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            // Where is this??? I have the star???
        }
    }
}
