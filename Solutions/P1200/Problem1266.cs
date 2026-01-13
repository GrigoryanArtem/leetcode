namespace Solutions.P1200;

public class Problem1266
{
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        var current = points[0];
        var time = 0;

        for(int i = 1; i < points.Length; i++)
        {
            var end = points[i];
            var dx = Math.Abs(end[0] - current[0]);
            var dy = Math.Abs(end[1] - current[1]);

            var sqrt = Math.Min(dx, dy);

            time += dx + dy - sqrt;

            current = end;
        }

        return time;
    }
}
