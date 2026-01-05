namespace Solutions.P2600;

public class Problem2685
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        var uf = new UnionFind(n);

        foreach (var edge in edges)
            uf.Union(edge[0], edge[1]);

        var count = 0;
        for (int i = 0; i < n; i++)
        {
            if (i != uf.Parent[i])
                continue;

            if (EdgesCount(uf.Rank(i)) == uf.Connections(i))
                count++;
        }

        return count;
    }

    public static int EdgesCount(int rank)
        => rank * (rank - 1) / 2;

    private class UnionFind
    {
        private readonly int[] _ranks;
        private readonly int[] _connections;

        public int[] Parent { get; }

        public UnionFind(int n)
        {
            Parent = new int[n];

            _ranks = new int[n];
            _connections = new int[n];

            for (int i = 0; i < n; i++)
            {
                Parent[i] = i;
                _ranks[i] = 1;
            }
        }

        public int Connections(int x)
            => _connections[x];

        public int Rank(int x)
            => _ranks[x];

        public int Find(int x)
            => Parent[x] != x
                ? Parent[x] = Find(Parent[x])
                : x;

        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x == y)
            {
                _connections[x]++;
                return;
            }

            if (_ranks[x] < _ranks[y])
                (x, y) = (y, x);

            Parent[y] = x;
            _ranks[x] += _ranks[y];
            _connections[x] += _connections[y] + 1;
        }
    }
}
