using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utility
{
    public enum NEIGHBOR_TYPE
    {
        ORTHOGONAL, // Up, down, left, right
        KING // Diagonals included
    }

    public static class CollectionUtil
    {
        /// <summary>
        /// Returns the coordinates of each of a point's neighbors
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

        /// <summary>
        /// Inserts a value into a dictionary if it doesn't exist. Otherwise it updates the value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void InsertOrUpdate<T, U>(Dictionary<T, U> dict, T key, U value)
        {
            if (dict.ContainsKey(key))
                dict[key] = value;
            else
                dict.Add(key, value);
        }

        /// <summary>
        /// Inserts a value into a dictionary if it doesn't exist. Otherwise, it adds to the value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void InsertOrIncrement<T, U>(Dictionary<T, U> dict, T key, U value) where U : INumber<U>
        {
            if (dict.ContainsKey(key))
            {
                dict[key] += value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        /// <summary>
        /// Inserts a list to a dictionary if it doesn't exist, otherwise appends to the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void InsertOrAppend<T, U>(Dictionary<T, List<U>> dict, T key, U value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key].Add(value);
            }
            else
            {
                dict.Add(key, new List<U>() { value });
            }
        }

        /// <summary>
        /// Given a grid and some value, finds the (x, y) coordinate pair of the item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static (int x, int y) FindCoordsInGrid<T>(List<List<T>> grid, T? v) => v == null ? (-1, -1) : grid
                                                                                                        .SelectMany((row, x) => row
                                                                                                            .Select((val, y) => new { Value = val, X = x, Y = y }))
                                                                                                            .Where(item => item.Value.Equals(v))
                                                                                                        .Select(item => (item.X, item.Y))
                                                                                                        .First();

        public static IEnumerable<List<T>> GetPermutations<T>(List<T> list)
        {
            if (list.Count == 1)
                yield return list;

            for (int i = 0; i < list.Count; i++)
            {
                var element = list[i];
                var remainingList = list.Where((_, index) => index != i).ToList();

                foreach (var permutation in GetPermutations(remainingList))
                {
                    var newPermutation = new List<T> { element };
                    newPermutation.AddRange(permutation);
                    yield return newPermutation;
                }
            }
        }
    }
}
