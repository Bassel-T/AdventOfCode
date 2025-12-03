using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utility
{
    public static class DebugUtil
    {
        // https://stackoverflow.com/questions/56289426/debug-multi-dimensional-arrays-c-sharp
        public static string Test2D(this Array source, int pad = 10)
        {
            var result = "";
            for (int i = source.GetLowerBound(0); i <= source.GetUpperBound(0); i++)
            {
                for (int j = source.GetLowerBound(1); j <= source.GetUpperBound(1); j++)
                    result += (source.GetValue(i, j) ?? "null").ToString().PadLeft(pad);
                result += "\n";
            }
            return result;
        }
    }
}
