using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utility
{
    public static class MathUtil
    {
        public static double GreatestCommonDenominator(double a, double b)
        {
            while (b > 0)
            {
                double t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        public static double LeastComonMultiple(double a, double b)
        {
            return a * b / GreatestCommonDenominator(a, b);
        }

        public static int ManhattanDistance((int x, int y) p1, (int x, int y) p2)
        {
            if (p1.x == int.MaxValue & p1.y == int.MaxValue) return int.MaxValue;
            if (p2.x == int.MaxValue & p2.y == int.MaxValue) return int.MaxValue;

            return Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y);
        }

        public static int Modulo(int dividend, int divisor)
        {
            int remainder = dividend % divisor;

            if (remainder < 0 && divisor > 0)
            {
                return remainder + divisor;
            }
            else if (remainder > 0 && divisor < 0)
            {
                return remainder + divisor;
            }

            return remainder;
        }
    }
}
