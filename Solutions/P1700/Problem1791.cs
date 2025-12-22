namespace Solutions.P1700;

public class Problem1791
{
    public int FindCenter(int[][] edges)
        => edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1] ? edges[0][0] : edges[0][1];    
}
