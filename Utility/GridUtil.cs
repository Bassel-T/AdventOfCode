using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utility
{
    public static class GridUtil
    {
        public static bool PointInBounds<T>(int x, List<T> grid)
        {
            return x >= 0 && x < grid.Count;
        }

        public static bool PointIn2DBounds<T>(int x, int y, List<List<T>> grid)
        {
            return grid.All(subarray => PointInBounds(y, subarray)) && PointInBounds(x, grid);
        }

        public static void GetNeighbors<T>(T[][] grid, int x, int y, bool includeCorners, Action<int,int> action)
        {
            int rows = grid.Length;

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    if (!includeCorners && nx != 0 && ny != 0) continue;

                    if (nx < 0 || nx >= rows)
                        continue;

                    if (ny < 0 || ny >= grid[nx].Length)
                        continue;

                    action(nx, ny);
                }
            }
        }
    }
}
