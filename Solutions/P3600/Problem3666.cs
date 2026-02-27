namespace Solutions.P3600;

public class Problem3666
{    
    public int MinOperations(string s, int k)
    {
        var n = s.Length;

        var sets = new SortedSet<int>[2] { [], [] };
        for (int i = 0; i <= n; i++)
            sets[i & 1].Add(i);

        var zeros = 0;
        for (int i = 0; i < n; i++)
            zeros += ~s[i] & 1;

        sets[zeros & 1].Remove(zeros);

        Span<int> visited = stackalloc int[n];
        Queue<int> queue = [];

        queue.Enqueue(zeros);
        
        for (int count = 0; queue.Count > 0; count++)
        {
            var dequeue = queue.Count;

            for (int i = 0; i < dequeue; i++)
            {
                var cz = queue.Dequeue();
                if (cz == 0)
                    return count;

                var from = cz + k - 2 * Math.Min(cz, k);
                var to = cz + k - 2 * Math.Max(k - n + cz, 0);

                var set = sets[from & 1];

                var vix = 0;
                foreach (var next in set.GetViewBetween(from, to))
                {
                    queue.Enqueue(next);
                    visited[vix++] = next;
                }

                for(int v = 0; v < vix; v++)
                    set.Remove(visited[v]);
            }
        }

        return -1;
    }
}
