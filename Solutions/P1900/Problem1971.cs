namespace Solutions.P1900;

public class Problem1971
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var uf = new UnionFind(n, source, destination);
        for (int i = 0; i < edges.Length && !uf.PathExist; i++)
            uf.Union(edges[i][0], edges[i][1]);

        return uf.PathExist;
    }

    private class UnionFind(int n, int source, int destination)
    {
        private readonly int[] _parent = [.. Enumerable.Range(0, n)];

        private int _sourceRoot = source;
        private int _destinationRoot = destination;

        public bool PathExist => _sourceRoot == _destinationRoot;

        public int Find(int x)
            => _parent[x] != x
                ? _parent[x] = Find(_parent[x])
                : x;

        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x == y)
                return;

            _parent[y] = x;

            if (y == _sourceRoot)
                _sourceRoot = x;

            if (y == _destinationRoot)
                _destinationRoot = x;
        }
    }
}
