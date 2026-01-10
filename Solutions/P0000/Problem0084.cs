namespace Solutions.P0000;

public class Problem0084
{
    public int LargestRectangleArea(int[] heights)
    {
        var n = heights.Length;
        Span<int> stack = stackalloc int[n];
        var top = -1;

        int maxArea = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            while (top >= 0 && heights[stack[top]] >= heights[i])
            {
                var val = stack[top--];
                var width = top >= 0 ? i - stack[top] - 1 : i;

                maxArea = Math.Max(maxArea, heights[val] * width);
            }

            stack[++top] = i;
        }

        while (top >= 0)
        {
            var val = stack[top--];
            var width = top >= 0 ? n - stack[top] - 1 : n;

            maxArea = Math.Max(maxArea, heights[val] * width);
        }

        return maxArea;
    }
}
