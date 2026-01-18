namespace Solutions.P1800;

public class Problem1895
{
    private int[,] hs;
    private int[,] vs;
    private int[,] ds;
    private int[,] rds;

    public int LargestMagicSquare(int[][] grid)
    {
        Init(grid);

        var maxSize = Math.Min(grid.Length, grid[0].Length);
        for (int size = maxSize; size > 1; size--)
            for (int i = 0; i <= grid.Length - size; i++)
                for (int k = 0; k <= grid[0].Length - size; k++)
                    if (IsMatrixValid(i, k, size))
                        return size;

        return 1;
    }

    private void Init(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        hs = new int[m, n + 1];
        vs = new int[m + 1, n];
        ds = new int[m + 1, n + 1];
        rds = new int[m + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            for (int k = 0; k < n; k++)
            {
                hs[i, k + 1] = hs[i, k] + grid[i][k];
                vs[i + 1, k] = vs[i, k] + grid[i][k];
                ds[i + 1, k + 1] = ds[i, k] + grid[i][k];

                var rk = n - 1 - k;
                rds[i + 1, rk] = rds[i, rk + 1] + grid[i][rk];
            }
        }
    }

    public bool IsMatrixValid(int x, int y, int size)
    {
        var isValid = true;
        var sum = hs[x, y + size] - hs[x, y];

        for (int i = x + 1; isValid && i < x + size; i++)
            isValid &= (hs[i, y + size] - hs[i, y]) == sum;

        for (int i = y; isValid && i < y + size; i++)
            isValid &= (vs[x + size, i] - vs[x, i]) == sum;

        return isValid
            && (ds[x + size, y + size] - ds[x, y] == sum)
            && (rds[x + size, y] - rds[x, y + size] == sum);
    }
}
