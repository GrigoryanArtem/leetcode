namespace Solutions.P3400;

public class Problem3453
{
    private const double EPS = 1e-6;

    public double SeparateSquares(int[][] squares)
    {
        var area = Area(squares, out var minY, out var maxY);
        var halfArea = area / 2;

        while (Math.Abs(maxY - minY) > EPS)
        {
            var mid = (maxY + minY) / 2;

            if (Area(squares, mid) >= halfArea)
            {
                maxY = mid;
            }
            else
            {
                minY = mid;
            }
        }

        return Math.Round(maxY, 5);
    }

    private static double Area(int[][] squares, out double minY, out double maxY)
    {
        var area = .0;

        maxY = Double.NegativeInfinity;
        minY = Double.PositiveInfinity;

        for (int i = 0; i < squares.Length; i++)
        {
            var y = squares[i][1];
            var size = (double)squares[i][2];

            area += size * size;

            minY = Math.Min(minY, y);
            maxY = Math.Max(maxY, y + size);
        }

        return area;
    }

    private static double Area(int[][] squares, double limitY)
    {
        var area = .0;

        for (int i = 0; i < squares.Length; i++)
        {
            var y = squares[i][1];
            var size = squares[i][2];

            area += Math.Clamp(limitY - y, .0, size) * size;
        }

        return area;
    }
}
