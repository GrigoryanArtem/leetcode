namespace Solutions.P0900;

public class Problem0997
{
    public int FindJudge(int n, int[][] trust)
    {
        Span<int> trusted = stackalloc int[n + 1];

        foreach (var t in trust)
        {
            trusted[t[0]]--;
            trusted[t[1]]++;
        }
        
        var judge = -1;
        for (int i = 1; i <= n && judge < 0; i++)
            if (trusted[i] == n - 1)
                judge = i;

        return judge;
    }
}
