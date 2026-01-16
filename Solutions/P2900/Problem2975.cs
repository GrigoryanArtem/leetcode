namespace Solutions.P2900;

public class Problem2975
{
    private const int MOD = 1000000007;

    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        Span<int> h = stackalloc int[hFences.Length + 2];

        h[0] = 1;
        h[^1] = m;

        Span<int> v = stackalloc int[vFences.Length + 2];

        v[0] = 1;
        v[^1] = n;

        hFences.AsSpan().CopyTo(h.Slice(1, hFences.Length));
        vFences.AsSpan().CopyTo(v.Slice(1, vFences.Length));

        h.Sort();
        v.Sort();

        HashSet<int> sizes = [];

        for (int i = 0; i < h.Length; i++)
            for (int k = i + 1; k < h.Length; k++)
                sizes.Add(h[k] - h[i]);

        var max = -1;
        for (int i = 0; i < v.Length; i++)
        {
            for (int k = i + 1; k < v.Length; k++)
            {
                var d = v[k] - v[i];

                if (sizes.Contains(d))
                    max = Math.Max(max, d);
            }
        }

        return max > 0 
            ? (int)(((long)max * max) % MOD) 
            : -1; ;
    }
}
