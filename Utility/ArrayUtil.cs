using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utility
{
    public enum NEIGHBOR_TYPE
    {
        ORTHOGONAL, // Up, down, left, right
        KING // Diagonals included
    }

    public static class ArrayUtil
    {
        /// <summary>
        /// Returns the coordinates of each 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="neighborType"></param>
        /// <returns></returns>
        public static List<Tuple<int, int>> GetNeighborCoordinates(int[,] arr, int x, int y, NEIGHBOR_TYPE neighborType)
        {
            List<Tuple<int, int>> tuple = new List<Tuple<int, int>>();



            return tuple;
        }
    }
}
