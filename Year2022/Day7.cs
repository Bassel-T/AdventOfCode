using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day7
    {
        class Group7
        {
            public string Directory { get; set; }
            public List<string> Subfolders { get; set; } = new List<string>();
            public int Size { get; set; }
        }

        public static void Part1()
        {
            var text = File.ReadAllLines("Input.txt");
            List<string> Path = new List<string>();

            List<Group7> directories = new List<Group7>();

            foreach (var line in text)
            {
                if (line == "$ cd ..")
                {
                    Path = Path.SkipLast(1).ToList();
                }
                else if (line.StartsWith("$ cd"))
                {
                    var folder = line.Split(' ').Last();
                    Path.Add(folder);
                    var dirName = String.Join('/', Path);
                    if (!directories.Any(x => x.Directory == dirName))
                    {
                        directories.Add(new Group7()
                        {
                            Directory = dirName
                        });
                    }
                }
                else if (int.TryParse(line.Split(' ')[0], out int size))
                {
                    directories.Where(x => String.Join('/', Path).Contains(x.Directory)).ToList().ForEach(x => {
                        x.Size += size;
                    });
                }
            }

            Console.WriteLine(directories.Where(x => x.Size <= 100000).Sum(x => x.Size));

        }

        public static void Part2()
        {
            var text = File.ReadAllLines("Input.txt");
            List<string> Path = new List<string>();

            List<Group7> directories = new List<Group7>();

            foreach (var line in text)
            {
                if (line == "$ cd ..")
                {
                    Path = Path.SkipLast(1).ToList();
                }
                else if (line.StartsWith("$ cd"))
                {
                    var folder = line.Split(' ').Last();
                    Path.Add(folder);
                    var dirName = String.Join('/', Path);
                    if (!directories.Any(x => x.Directory == dirName))
                    {
                        directories.Add(new Group7()
                        {
                            Directory = dirName
                        });
                    }
                }
                else if (int.TryParse(line.Split(' ')[0], out int size))
                {
                    directories.Where(x => String.Join('/', Path).Contains(x.Directory)).ToList().ForEach(x => {
                        x.Size += size;
                    });
                }
            }

            Console.WriteLine(directories.Where(x => x.Size <= 100000).Sum(x => x.Size));

            var total = 70000000;
            var neededUnused = 30000000;

            var current = total - directories[0].Size;
            var minSizeToDelete = neededUnused - current;

            Console.WriteLine(directories.OrderBy(x => x.Size).Where(x => x.Size > minSizeToDelete).Min(x => x.Size));
        }
    }
}
