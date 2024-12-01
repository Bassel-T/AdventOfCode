using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public static class Day4
    {
        class Tile
        {
            public int num { get; set; }
            public bool marked { get; set; }
            public Tile(int n)
            {
                num = n;
                marked = false;
            }
        }

        class Board
        {
            List<List<Tile>> board { get; set; }
            public Board(string r1, string r2, string r3, string r4, string r5)
            {
                board = new List<List<Tile>>() { new List<Tile>(), new List<Tile>(), new List<Tile>(), new List<Tile>(), new List<Tile>() };
                board[0] = r1.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Tile(Convert.ToInt32(x))).ToList();
                board[1] = r2.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Tile(Convert.ToInt32(x))).ToList();
                board[2] = r3.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Tile(Convert.ToInt32(x))).ToList();
                board[3] = r4.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Tile(Convert.ToInt32(x))).ToList();
                board[4] = r5.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Tile(Convert.ToInt32(x))).ToList();
            }

            public bool Call(int i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    for (int k = 0; k < 5; ++k)
                    {
                        if (board[j][k].num == i)
                        {
                            board[j][k].marked = true;
                            return true;
                        }
                    }
                }
                return false;
            }

            public bool HasMatch()
            {
                // Column match
                for (int i = 0; i < 5; ++i)
                {
                    int minus1 = 0;
                    for (int j = 0; j < 5; ++j)
                    {
                        if (board[j][i].marked)
                        {
                            ++minus1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (minus1 == 5)
                    {
                        return true;
                    }
                }

                // Row
                return board.Select(x => x.Count(i => i.marked) == 5).ToList().Contains(true);
            }

            public int Sum()
            {
                return board.Sum(x => x.Sum(x => x.marked ? 0 : x.num));
            }
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("Input4.txt"))
            {
                List<int> calls = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList();
                List<Board> boards = new List<Board>();
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    boards.Add(new Board(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine()));
                }

                foreach (int i in calls)
                {
                    foreach (Board b in boards)
                    {
                        if (b.Call(i))
                        {
                            if (b.HasMatch())
                            {
                                Console.WriteLine(b.Sum());
                                Console.WriteLine(b.Sum() * i);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public static void Part2()
        {
            string[] file = File.ReadAllLines("Input4.txt");
            using (var reader = new StreamReader("Input4.txt"))
            {
                List<int> calls = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList();
                List<Board> boards = new List<Board>();
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    boards.Add(new Board(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine()));
                }

                for (int i = 0; boards.Count > 0; ++i)
                {
                    for (int j = 0; j < boards.Count; ++j)
                    {
                        if (boards[j].Call(calls[i]))
                        {
                            if (boards[j].HasMatch())
                            {
                                if (boards.Count == 1)
                                {
                                    Console.WriteLine(boards[j].Sum() * calls[i]);
                                    return;
                                }

                                boards.Remove(boards[j]);
                                --j;
                            }
                        }
                    }
                }
            }
        }
    }
}
