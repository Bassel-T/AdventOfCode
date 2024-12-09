using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2015
{
    public static class Day10
    {
        private static string input = "1321131112";

        private static void LookAndSee(int repetitions)
        {
            var currInput = input;
            for (int i = 0; i < repetitions; i++)
            {
                char c = currInput[0];
                int count = 1;
                StringBuilder nextInput = new StringBuilder(currInput.Length * 2);

                for (int j = 1; j < currInput.Length; j++)
                {
                    if (c == currInput[j])
                    {
                        count++;
                    }
                    else
                    {
                        nextInput.Append(count).Append(c);
                        c = currInput[j];
                        count = 1;
                    }
                }

                nextInput.Append(count).Append(c);
                currInput = nextInput.ToString();
            }

            Console.WriteLine(currInput.Length);
        }

        public static void Part1()
        {
            //LookAndSee(40);   
        }

        public static void Part2()
        {
            LookAndSee(50);
        }
    }
}
