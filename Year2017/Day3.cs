using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2017
{
    public static class Day3
    {
        private enum Direction
        {
            UP,
            RIGHT,
            LEFT,
            DOWN
        }

        private class Day3Part2Helper
        {
            public int x { get; set; }
            public int y { get; set; }
            public int value { get; set; }
        }

        public static void Part1(int position)
        {
            int x = 0, y = 0;
            int curr = 1;
            int step = 1;
            int repeat = 2;

            // Overshoot
            Direction dir = Direction.RIGHT;
            while (curr < position)
            {
                curr += step;

                switch (dir)
                {
                    case Direction.UP:
                        y += step;
                        dir = Direction.LEFT;
                        break;
                    case Direction.LEFT:
                        x -= step;
                        dir = Direction.DOWN;
                        break;
                    case Direction.DOWN:
                        y -= step;
                        dir = Direction.RIGHT;
                        break;
                    case Direction.RIGHT:
                        x += step;
                        dir = Direction.UP;
                        break;
                }

                repeat--;

                if (repeat == 0)
                {
                    step++;
                    repeat = 2;
                }
            }

            var diff = curr - position;
            switch (dir)
            {
                case Direction.UP:
                    x -= diff;
                    break;
                case Direction.LEFT:
                    y -= diff;
                    break;
                case Direction.DOWN:
                    x += diff;
                    break;
                case Direction.RIGHT:
                    y += diff;
                    break;
            }

            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        }

        //public static void Part2(int value)
        //{
        //    List<Day3Part2Helper> values = new List<Day3Part2Helper>();
        //    values.Add(new Day3Part2Helper { x = 0, y = 0, value = 1 });

        //    int x = 0, y = 0;
        //    int curr = 1;
        //    int step = 1;
        //    int repeat = 2;

        //    // Overshoot
        //    Direction dir = Direction.RIGHT;
        //    while (curr <= value)
        //    {

        //        // Take a step
        //        switch (dir)
        //        {
        //            case Direction.UP:
        //                y++;
        //                dir = Direction.LEFT;
        //                break;
        //            case Direction.LEFT:
        //                x++;
        //                dir = Direction.DOWN;
        //                break;
        //            case Direction.DOWN:
        //                y++;
        //                dir = Direction.RIGHT;
        //                break;
        //            case Direction.RIGHT:
        //                x++;
        //                dir = Direction.UP;
        //                break;
        //        }

        //        // Calculate the new position's value
        //        curr = values.Where(tile => Math.Abs(x - tile.x) < 2 && Math.Abs(y - tile.y) < 2).Sum(x => x.value);
        //        values.Add(new Day3Part2Helper() { x = x, y = y, value = curr });

        //        // Turn if needed

        //    }

        //    var diff = curr - position;
        //    switch (dir)
        //    {
        //        case Direction.UP:
        //            x -= diff;
        //            break;
        //        case Direction.LEFT:
        //            y -= diff;
        //            break;
        //        case Direction.DOWN:
        //            x += diff;
        //            break;
        //        case Direction.RIGHT:
        //            y += diff;
        //            break;
        //    }

        //    Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        //}
    }
}
