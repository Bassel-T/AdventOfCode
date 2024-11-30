using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020
{
    public static class Day22
    {
        private static int CalculateScore(Queue<int> cards)
        {
            int count = 0;
            while (cards.Count() > 0)
            {
                count += cards.Count() * cards.Peek();
                cards.Dequeue();
            }
            return count;
        }

        private static bool RecursiveCombat(Queue<int> p1, Queue<int> p2, int p1C, int p2C, int max)
        {

            int round = 0;

            Queue<int> newDeck1 = new Queue<int>();
            while (newDeck1.Count < p1C)
            {
                newDeck1.Enqueue(p1.Dequeue());
            }

            Queue<int> newDeck2 = new Queue<int>();
            while (newDeck2.Count < p2C)
            {
                newDeck2.Enqueue(p2.Dequeue());
            }

            bool[,] memory = new bool[max, max];

            while (newDeck1.Count > 0 && newDeck2.Count > 0)
            {

                round++;
                int card1 = newDeck1.Dequeue();
                int card2 = newDeck2.Dequeue();

                if (memory[card1, card2])
                {
                    return true;
                }
                else
                {
                    memory[card1, card2] = true;
                    int winner;
                    if (newDeck1.Count >= card1 && newDeck2.Count >= card2)
                    {
                        winner = RecursiveCombat(newDeck1, newDeck2, card1, card2, max) ? 1 : 0;
                    }
                    else
                    {
                        winner = (card1 > card2) ? 1 : 0;
                    }

                    if (winner == 1)
                    {
                        newDeck1.Enqueue(card1);
                        newDeck1.Enqueue(card2);
                    }
                    else
                    {
                        newDeck2.Enqueue(card2);
                        newDeck2.Enqueue(card1);
                    }
                }
            }

            return newDeck1.Count > 0;
        }

        public static void Part1()
        {
            Queue<int> Cards1 = new Queue<int>();
            Queue<int> Cards2 = new Queue<int>();

            string input = "Read line here";

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input22.txt")))
            {
                while (!string.IsNullOrEmpty(input))
                {
                    input = reader.ReadLine();
                    try
                    {
                        Cards1.Enqueue(int.Parse(input));
                    }
                    catch (Exception e)
                    {

                    }
                }

                input = "Starting 2";

                while (!string.IsNullOrEmpty(input))
                {
                    input = reader.ReadLine();
                    try
                    {
                        Cards2.Enqueue(int.Parse(input));
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            while (Cards1.Count > 0 && Cards2.Count > 0)
            {
                int c1 = Cards1.Dequeue();
                int c2 = Cards2.Dequeue();

                if (c1 > c2)
                {
                    Cards1.Enqueue(c1);
                    Cards1.Enqueue(c2);
                }
                else
                {
                    Cards2.Enqueue(c2);
                    Cards2.Enqueue(c1);
                }
            }

            int count = Math.Max(CalculateScore(Cards1), CalculateScore(Cards2));

            Console.WriteLine(count);
        }

        public static void Part2()
        {
            Queue<int> Cards1 = new Queue<int>();
            Queue<int> Cards2 = new Queue<int>();

            string input = "Read line here";
            int max = 0;

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Input22.txt")))
            {
                while (!string.IsNullOrEmpty(input))
                {
                    input = reader.ReadLine();
                    try
                    {
                        int toAdd = int.Parse(input);
                        Cards1.Enqueue(toAdd);
                        max = Math.Max(max, toAdd);
                    }
                    catch (Exception e)
                    {

                    }
                }

                input = "Starting 2";

                while (!string.IsNullOrEmpty(input))
                {
                    input = reader.ReadLine();
                    try
                    {
                        int toAdd = int.Parse(input);
                        Cards2.Enqueue(toAdd);
                        max = Math.Max(max, toAdd);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            bool p1Wins = RecursiveCombat(Cards1, Cards2, Cards1.Count, Cards2.Count, max + 1);

            Console.WriteLine(CalculateScore(p1Wins ? Cards1 : Cards2));
        }
    }
}
