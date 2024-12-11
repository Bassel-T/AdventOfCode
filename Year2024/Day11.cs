using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public static class Day11
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var nums = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int blinks = 0; blinks < 25; blinks++)
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] == "0")
                        {
                            nums[i] = "1";
                        } else if (nums[i].Length % 2 == 0)
                        {
                            string temp = nums[i];
                            nums[i] = temp.Substring(0, temp.Length / 2).TrimStart('0');
                            nums.Insert(i + 1, temp.Substring(temp.Length / 2).TrimStart('0'));
                            if (string.IsNullOrEmpty(nums[i])) { nums[i]= "0"; }
                            if (string.IsNullOrEmpty(nums[i + 1])) { nums[i + 1]= "0"; }
                            i++;
                        } else
                        {
                            nums[i] = $"{ulong.Parse(nums[i]) * 2024}";
                        }
                    }
                }

                Console.WriteLine(nums.Count);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var nums = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => new KeyValuePair<string, ulong>(x, 1)).ToDictionary();

                for (int blinks = 0; blinks < 75; blinks++)
                {
                    Dictionary<string, ulong> newDict = new Dictionary<string, ulong>();
                    foreach (var x in nums)
                    {
                        if (x.Key == "0") {
                            CollectionUtil.InsertOrIncrement(newDict, "1", x.Value);
                        }
                        else if (x.Key.Length % 2 == 0)
                        {
                            string temp = x.Key;

                            string left = temp.Substring(0, temp.Length / 2).TrimStart('0');
                            if (string.IsNullOrEmpty(left)) { left = "0"; }

                            string right = temp.Substring(temp.Length / 2).TrimStart('0');
                            if (string.IsNullOrEmpty(right)) { right = "0"; }

                            CollectionUtil.InsertOrIncrement(newDict, left, x.Value);
                            CollectionUtil.InsertOrIncrement(newDict, right, x.Value);
                        }
                        else
                        {
                            CollectionUtil.InsertOrIncrement(newDict, $"{BigInteger.Parse(x.Key) * 2024}", x.Value);
                        }
                    }
                    nums = newDict.ToDictionary();
                }

                BigInteger count = 0;
                foreach (var x in nums)
                {
                    count += x.Value;
                }

                Console.WriteLine(count);
            }
        }
    }
}
