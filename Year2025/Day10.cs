using Microsoft.Z3;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2025
{
    public static class Day10
    {
        private class Part1Configuration
        {
            public List<bool> Target { get; set; } = new();

            public List<List<int>> Moves { get; set; } = new();
        }

        public class Part1State
        {
            public int Depth { get; set; } = 0;
            public List<bool> Current { get; set; } = new();
        }

        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                List<Part1Configuration> configurations = new List<Part1Configuration>();

                while (!reader.EndOfStream)
                {
                    var config = new Part1Configuration();

                    var line = reader.ReadLine();
                    var frag = line.Split(' ');

                    config.Target = frag[0].Substring(1, frag[0].Length - 2).Select(x => x == '#').ToList();

                    for (int i = 1; i < frag.Length - 1; i++)
                    {
                        config.Moves.Add(frag[i].Substring(1, frag[i].Length - 2).Split(',').Select(int.Parse).ToList());
                    }

                    configurations.Add(config);
                }

                var answer = 0;

                foreach (var config in configurations)
                {
                    var queue = new Queue<Part1State>();
                    queue.Enqueue(new Part1State() { Current = Enumerable.Range(0, config.Target.Count).Select(x => false).ToList() });
                    var found = false;

                    while (queue.Any())
                    {
                        var curr = queue.Dequeue();

                        foreach (var move in config.Moves)
                        {
                            List<bool> nextState = [.. curr.Current];
                            foreach (var index in move)
                            {
                                nextState[index] = !nextState[index];
                            }

                            int nextDepth = curr.Depth + 1;

                            if (nextState.SequenceEqual(config.Target))
                            {
                                found = true;
                                answer += nextDepth;
                                break;
                            }

                            queue.Enqueue(new Part1State { Current = nextState, Depth = nextDepth });
                        }

                        if (found) break;
                    }
                }

                Console.WriteLine(answer);
            }
        }

        private class Part2Configuration
        {
            public List<int> Target { get; set; } = new();

            public List<List<int>> Moves { get; set; } = new();
        }

        public static void Part2()
        {
            ulong total = 0;

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var config = new Part2Configuration();

                    var line = reader.ReadLine();
                    var frag = line.Split(' ');

                    config.Target = frag.Last().Substring(1, frag.Last().Length - 2).Split(',').Select(int.Parse).ToList();

                    for (int i = 1; i < frag.Length - 1; i++)
                    {
                        config.Moves.Add(frag[i].Substring(1, frag[i].Length - 2).Split(',').Select(int.Parse).ToList());
                    }

                    total += SolveConfiguration(config);
                }

                Console.WriteLine(total);
            }
        }

        // TODO : Get rid of this library...
        private static ulong SolveConfiguration(Part2Configuration config)
        {
            using (Context ctx = new Context())
            {
                List<IntExpr> variables = Enumerable.Range(0, config.Moves.Count).Select(i => ctx.MkIntConst($"x{i}")).ToList();

                Optimize opt = ctx.MkOptimize();

                // Must be at least 0
                foreach (var expr in variables)
                {
                    opt.Add(ctx.MkGe(expr, ctx.MkInt(0)));
                }

                // Add linear equations
                foreach (var index in Enumerable.Range(0, config.Target.Count))
                {
                    opt.Add(ctx.MkEq(ctx.MkAdd(config.Moves.Select((x, i) => ctx.MkMul(ctx.MkInt(x.Contains(index) ? 1 : 0), variables[i]))), ctx.MkInt(config.Target[index])));
                }

                // Define the objective to minimize
                ArithExpr sum = ctx.MkAdd(variables);
                opt.MkMinimize(sum);

                // Check satisfiability and get the solution
                Model model = opt.Model;
                return ulong.Parse($"{model.Evaluate(sum)}");
            }
        }
    }
}
