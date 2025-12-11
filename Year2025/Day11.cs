using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2025
{
    public static class Day11
    {
        public static void Part1()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var graph = reader.ReadToEnd().Split("\r\n").ToDictionary(x => x.Split(": ")[0], x => x.Split(": ")[1].Split(" ").ToList());

                List<string> paths = new List<string> { "you" };

                while (paths.Any(x => x != "out"))
                {
                    paths = paths.SelectMany(x => graph[x]).ToList();
                }

                Console.WriteLine(paths.Count);
            }
        }

        public static void Part2()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                // Read the graph, also assign out because Topological Sort will scream at me otherwise
                var graph = reader.ReadToEnd().Split("\r\n").ToDictionary(x => x.Split(": ")[0], x => x.Split(": ")[1].Split(" ").ToList());
                graph["out"] = [];

                // Path from a → d that passes through b and c is just (a → b → c → d) or (a → c → d → b)
                var svrfft = DAG(graph, "svr", "fft");
                var fftdac = DAG(graph, "fft", "dac");
                var dacout = DAG(graph, "dac", "out");
                var svrdac = DAG(graph, "svr", "dac");
                var dacfft = DAG(graph, "dac", "fft");
                var fftout = DAG(graph, "fft", "out");

                var total = svrfft * fftdac * dacout + svrdac * dacfft * fftout;

                Console.WriteLine(total);
            }
        }

        static ulong DAG(Dictionary<string, List<string>> graph, string start, string end)
        {
            var tree = TopologicalSort(graph);
            tree.Reverse();
            var paths = graph.ToDictionary(x => x.Key, x => (x.Key == end) ? 1ul : 0ul);

            foreach (var node in tree)
            {
                foreach (var neighbor in graph[node])
                {
                    paths[node] += paths[neighbor];
                }
            }

            return paths[start];
        }

        // Turn the graph into a list by depth
        static List<string> TopologicalSort(Dictionary<string, List<string>> graph)
        {
            var visited = new HashSet<string>();
            var stack = new Stack<string>();

            void DFS(string vertex)
            {
                if (visited.Contains(vertex))
                {
                    return;
                }

                visited.Add(vertex);

                foreach (var next in graph[vertex])
                {
                    DFS(next);
                }

                stack.Push(vertex);
            }

            // Make sure we get through all possible paths (even though svr is probably the only start)
            foreach (var vertex in graph.Keys)
                DFS(vertex);

            return stack.ToList();
        }
    }
}
