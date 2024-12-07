using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public static class Day13
    {
        public class Group13
        {
            public int? Value { get; set; }
            public List<Group13> Children { get; set; } = new List<Group13>();

            public bool Empty { get { return !Value.HasValue && !Children.Any(); } }
        }

        /*
		 [[1],[2,3,[4]]

				[ ]
			   /  \
		     [ ]  [ ]
		     /    /|\ 
		    1    2 3 [ ]
					 /
		            4
		 */

        private static Group13 ParseGroup13(string input)
        {
            // Create a stack to store the nested groups as we parse them
            var stack = new Stack<Group13>();

            // Create a new root group
            var root = new Group13();
            stack.Push(root);

            // Keep track of the current position in the input string
            int i = 0;

            while (i < input.Length)
            {
                // If the current character is a '[', we are starting a new nested group
                if (input[i] == '[')
                {
                    // Create a new group and add it to the current group's children
                    var group = new Group13();
                    stack.Peek().Children.Add(group);

                    // Push the new group onto the stack
                    stack.Push(group);
                }
                // If the current character is a ']', we are ending a nested group
                else if (input[i] == ']')
                {
                    // Pop the current group off the stack
                    stack.Pop();
                }
                // If the current character is a digit, we are parsing a value
                else if (char.IsDigit(input[i]))
                {
                    // Parse the value and set it on the current group
                    int j = i;
                    while (j < input.Length && char.IsDigit(input[j]))
                    {
                        j++;
                    }
                    int value = int.Parse(input.Substring(i, j - i));
                    stack.Peek().Children.Add(new Group13 { Value = value });
                    i = j - 1;
                }

                i++;
            }
            return root;
        }

        #region Tree2

        public static int CompareTrees1(Group13 left, Group13 right)
        {
            // Base case: Both are numbers
            if (left.Value.HasValue && right.Value.HasValue)
            {
                return Math.Sign(left.Value.Value - right.Value.Value);
            }

            // Base case: Left is a number and right is a list
            if (right.Children.Any() && left.Value.HasValue)
            {
                left.Children.Add(new Group13() { Value = left.Value });
                left.Value = null;
            }

            // Base case: Right is a number and left is a list
            if (left.Children.Any() && right.Value.HasValue)
            {
                right.Children.Add(new Group13() { Value = right.Value });
                right.Value = null;
            }

            // Base case: One is an empty list
            if (left.Empty && !right.Empty)
            {
                return -1;
            }

            if (right.Empty && !left.Empty)
            {
                return 1;
            }

            // Both are lists, compare their children in order
            var smallerCount = Math.Min(left.Children.Count, right.Children.Count);

            for (int i = 0; i < smallerCount; i++)
            {
                var cmp = CompareTrees1(left.Children[i], right.Children[i]);
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            // Got to the end of the smaller list
            return Math.Sign(left.Children.Count - right.Children.Count);
        }

        #endregion

        public static void Part1()
        {
            var inputs = File.ReadAllText("Input.txt").Split("\r\n\r\n").Select(x => x.Split("\r\n").Select(y => ParseGroup13(y)).ToList()).ToList();

            int sum = 0;
            for (int i = 0, c = inputs.Count; i < c; i++)
            {
                var cmp = CompareTrees1(inputs[i][0], inputs[i][1]);
                if (cmp < 0)
                {
                    sum += i + 1;
                }
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            var inputs = File.ReadAllLines("input.txt").Where(x => x.Any()).Select(x => ParseGroup13(x)).ToList();


            var twoPacket = new Group13();
            twoPacket.Children.Add(new Group13() { Value = 2 });

            var sixPacket = new Group13();
            sixPacket.Children.Add(new Group13() { Value = 6 });

            inputs.Add(twoPacket);
            inputs.Add(sixPacket);

            inputs.Sort((x, y) => CompareTrees1(x, y));

            Console.WriteLine((1 + inputs.IndexOf(twoPacket)) * (1 + inputs.IndexOf(sixPacket)));

        }

    }
}
