using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utility
{
    public static class GraphUtil
    {
        public static bool PointInBounds<T>(int x, List<T> grid)
        {
            return x >= 0 && x < grid.Count;
        }

        public static bool PointIn2DBounds<T>(int x, int y, List<List<T>> grid)
        {
            return grid.All(subarray => PointInBounds(y, subarray)) && PointInBounds(x, grid);
        }

    }
}
