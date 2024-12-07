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
    }
}
