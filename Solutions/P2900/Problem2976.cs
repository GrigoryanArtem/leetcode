namespace Solutions.P2900;

public class Problem2976
{
    private const int N = 'z' - 'a' + 1;

    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        Span<long> graph = stackalloc long[N * N];
        graph.Fill(Int32.MaxValue);

        for (int i = 0; i < cost.Length; i++)
        {
            var u = C2I(original[i]);
            var v = C2I(changed[i]);

            var pos = UV2P(u, v);
            graph[pos] = Math.Min(graph[pos], cost[i]);
        }

        for (int i = 0; i < N; i++)
            graph[UV2P(i, i)] = 0;

        for (int k = 0; k < N; k++)
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    graph[UV2P(i, j)] = Math.Min(graph[UV2P(i, j)], graph[UV2P(i, k)] + graph[UV2P(k, j)]);

        var sum = 0L;
        for(int i = 0; i < source.Length; i++)
        {
            var u = C2I(source[i]);
            var v = C2I(target[i]);

            var pos = UV2P(u, v);
            if (graph[pos] >= Int32.MaxValue)
                return -1;

            sum += graph[pos];
        }


        return sum;
    }

    private static int C2I(char ch)
        => ch - 'a';

    private static int UV2P(int u, int v)
        => u * N + v;
}
