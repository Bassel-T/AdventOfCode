using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day8
    {

        public static void Part1()
        {
            var text = File.ReadAllLines("Input.txt");
            var xDim = text.Length;
            var yDim = text[0].Length;

            var visible = 0;

            for (int x = 0; x < xDim; x++)
            {
                for (int y = 0; y < yDim; y++)
                {

                    if (x == 0 || x == xDim - 1 || y == 0 || y == yDim - 1)
                    {
                        visible++;
                        continue;
                    }

                    var coord = text[x][y];
                    var isVisible = true;
                    for (int z = x - 1; z >= 0; z--)
                    {
                        if (coord <= text[z][y])
                        {
                            isVisible = false;
                            break;
                        }
                    }

                    if (isVisible)
                    {
                        visible++;
                        continue;
                    }

                    isVisible = true;

                    for (int z = x + 1; z < xDim; z++)
                    {
                        if (coord <= text[z][y])
                        {
                            isVisible = false;
                            break;
                        }
                    }

                    if (isVisible)
                    {
                        visible++;
                        continue;
                    }

                    isVisible = true;

                    for (int z = y - 1; z >= 0; z--)
                    {
                        if (coord <= text[x][z])
                        {
                            isVisible = false;
                            break;
                        }
                    }

                    if (isVisible)
                    {
                        visible++;
                        continue;
                    }

                    isVisible = true;

                    for (int z = y + 1; z < yDim; z++)
                    {
                        if (coord <= text[x][z])
                        {
                            isVisible = false;
                            break;
                        }
                    }

                    if (isVisible)
                    {
                        visible++;
                    }
                }
            }

            Console.WriteLine(visible);
        }

        public static void Part2()
        {
            var text = File.ReadAllLines("Input.txt");
            var xDim = text.Length;
            var yDim = text[0].Length;

            var maxScenic = 0;

            for (int x = 1; x < xDim - 1; x++)
            {
                for (int y = 1; y < yDim - 1; y++)
                {
                    var currScenic = 1;
                    var temp = 0;

                    var coord = text[x][y];
                    for (int z = x - 1; z >= 0; z--)
                    {
                        temp++;
                        if (coord <= text[z][y])
                        {
                            break;
                        }
                    }

                    currScenic *= temp;
                    temp = 0;

                    for (int z = x + 1; z < xDim; z++)
                    {
                        temp++;
                        if (coord <= text[z][y])
                        {
                            break;
                        }
                    }

                    currScenic *= temp;
                    temp = 0;

                    for (int z = y - 1; z >= 0; z--)
                    {
                        temp++;
                        if (coord <= text[x][z])
                        {
                            break;
                        }
                    }

                    currScenic *= temp;
                    temp = 0;

                    for (int z = y + 1; z < yDim; z++)
                    {
                        temp++;
                        if (coord <= text[x][z])
                        {
                            break;
                        }
                    }

                    currScenic *= temp;

                    if (currScenic > maxScenic)
                    {
                        maxScenic = currScenic;
                    }

                }
            }

            Console.WriteLine(maxScenic);
        }

    }
}
