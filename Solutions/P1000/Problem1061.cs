namespace Solutions.P1000;

public class Problem1061
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        var uf = new UnionFind();

        for (int i = 0; i < s1.Length; i++)
            uf.Union(s1[i] - 'a', s2[i] - 'a');

        var res = baseStr.ToCharArray();
        for (int i = 0; i < res.Length; i++)
            res[i] = (char)(uf.Find(res[i] - 'a') + 'a');

        return new string(res);
    }

    private class UnionFind
    {
        private readonly int[] _parent = new int['z' - 'a' + 1];

        public UnionFind()
        {
            for(int i = 0; i < _parent.Length; i++)
                _parent[i] = i;
        }

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

            if (y > x)
            {
                _parent[y] = x;
            }
            else
            {
                _parent[x] = y;
            }
        }
    }
}
