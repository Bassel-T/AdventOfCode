using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day9
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<int> data = new List<int>();
                string line = reader.ReadLine();
                bool addingFile = true;
                int index = 0;

                for (int i = 0; i < line.Count(); i++)
                {
                    if (addingFile)
                    {
                        data.AddRange(Enumerable.Repeat(index, line[i] - 48));
                        index++;
                    }
                    else
                    {
                        data.AddRange(Enumerable.Repeat(-1, line[i] - 48));
                    }

                    addingFile = !addingFile;
                }

                int numberOfNegativeOnes = data.Count(x => x == -1);
                int total = data.Count();
                int firstNegativeOne = total - numberOfNegativeOnes;

                while (data.IndexOf(-1) != firstNegativeOne)
                {
                    int negIndex = data.IndexOf(-1);
                    int lastIndex = data.LastIndexOf(data.Last(x => x != -1));

                    data[negIndex] = data[lastIndex];
                    data[lastIndex] = -1;
                }

                ulong checksum = 0;
                for (int i = 0; i < firstNegativeOne; i++)
                {
                    checksum += (ulong)i * (ulong)data[i];
                }

                Console.WriteLine(checksum);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<int> data = new List<int>();

                string line = reader.ReadLine();
                bool addingFile = true;
                int fileId = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (addingFile)
                    {
                        data.AddRange(Enumerable.Repeat(fileId, line[i] - 48));
                        fileId++;
                    }
                    else
                    {
                        data.AddRange(Enumerable.Repeat(-1, line[i] - 48));
                    }
                    addingFile = !addingFile;
                }

                for (int scanId = fileId - 1; scanId >= 0; scanId--)
                {
                    int fileStart = data.IndexOf(scanId);
                    int fileSize = data.Count(x => x == scanId);

                    // Find where the latest block will fit
                    int bestFit = -1;
                    for (int i = 0; i <= fileStart - fileSize; i++)
                    {
                        if (data.Skip(i).Take(fileSize).All(x => x == -1))
                        {
                            bestFit = i;
                            break;
                        }
                    }

                    // Move the block if possible
                    if (bestFit != -1)
                    {
                        for (int j = 0; j < fileSize; j++)
                        {
                            data[bestFit + j] = scanId;
                        }

                        for (int j = fileStart; j < fileStart + fileSize; j++)
                        {
                            data[j] = -1;
                        }
                    }
                }

                // Calculate checksum
                ulong checksum = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i] != -1)
                    {
                        checksum += (ulong)i * (ulong)data[i];
                    }
                }

                Console.WriteLine(checksum);
            }
        }


    }
}
