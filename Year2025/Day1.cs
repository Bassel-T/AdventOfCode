using AdventOfCode.Utility;

namespace AdventOfCode.Year2025
{
    public static class Day1
    {
        public static void Part1()
        {
            int pos = 50;
            int zeroCount = 0;

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var add = line[0] == 'R';
                    var num = int.Parse(line[1..]);

                    if (add)
                    {
                        pos += num;
                        while (pos > 99) { pos -= 100; }
                    }
                    else
                    {
                        pos -= num;
                        while (pos < 0) { pos += 100; }
                    }

                    if (pos == 0) { zeroCount++; }

                }

                Console.WriteLine(zeroCount);
            }
        }

        public static void Part2()
        {
            int pos = 50;
            int zeroCount = 0;

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    bool add = line[0] == 'R';
                    int num = int.Parse(line[1..]);

                    int firstCross = 0;

                    // Figure out how far we are from the first cross
                    if (add)
                    {
                        firstCross = MathUtil.Modulo(100 - pos, 100);
                    }
                    else
                    {
                        firstCross = pos;
                    }

                    // If we're at 0, the first cross is 100 away
                    if (firstCross == 0)
                    {
                        firstCross = 100;
                    }

                    // Calculate how many crosses there will be, taking the first into account
                    if (num >= firstCross)
                    {
                        zeroCount += 1 + ((num - firstCross) / 100);
                    }

                    // Update the position
                    if (add)
                    {
                        pos = MathUtil.Modulo(pos + num, 100);
                    }
                    else
                    {
                        pos = MathUtil.Modulo(pos - num + 100, 100);

                        if (pos < 0)
                        {
                            pos += 100;
                        }
                    }

                }

                Console.WriteLine(zeroCount);
            }
        }
    }
}
