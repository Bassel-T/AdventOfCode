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

                    var add = line[0] == 'R';
                    var num = int.Parse(line[1..]);

                    for (int i = 0; i < num; i++)
                    {
                        if (add)
                        {
                            pos++;
                            if (pos > 99) { pos -= 100; }
                        }
                        else
                        {
                            pos--;
                            if (pos < 0) { pos += 100; }
                        }

                        if (pos == 0) zeroCount++;
                    }
                    
                }

                Console.WriteLine(zeroCount);
            }
        }
    }
}
