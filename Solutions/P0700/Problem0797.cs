namespace Solutions.P0700;

public class Problem0797
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        => DFS(graph, 0, graph.Length - 1);

    private static List<IList<int>> DFS(int[][] graph, int start, int target)
    {
        Span<int> path = stackalloc int[graph.Length];
        var pidx = 0;

        Span<int> stack = stackalloc int[graph.Length];
        var sidx = 0;

        var result = new List<IList<int>>();

        stack[sidx++] = 0;
        path[pidx++] = 0;

        while (sidx > 0)
        {
            var (node, childIndex) = FromNc(stack[--sidx]);

            if (node == target)
            {
                var copy = new int[pidx];
                for (int i = 0; i < pidx; i++)
                    copy[i] = path[i];

                result.Add(copy);
                pidx--;

                continue;
            }

            if (childIndex < graph[node].Length)
            {
                stack[sidx++] = ToNC(node, childIndex + 1);
                path[pidx++] = stack[sidx++] = graph[node][childIndex];                
            }
            else
            {
                pidx--;
            }
        }

        return result;
    }

    private static int ToNC(int node, int child)
        => (child << 8) | node;

    private static (int node, int child) FromNc(int nc)
        => (nc & 0xFF, nc >> 8);    
}
