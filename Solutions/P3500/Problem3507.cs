namespace Solutions.P3500;

public class Problem3507
{
    public int MinimumPairRemoval(int[] nums)
    {
        var data = new List<int>(nums);

        var count = 0;
        var sorted = false;
        var minSum = 0;

        while (!sorted && data.Count > 1)
        {
            sorted = true;

            var minIndex = 0;
            minSum = data[0] + data[1];

            for (int i = 1; i < data.Count; i++)
            {
                var sum = data[i] + data[i - 1];

                if (sum < minSum)
                {
                    minIndex = i - 1;
                    minSum = sum;
                }

                sorted &= data[i] >= data[i - 1];
            }

            if (sorted)
                break;

            data[minIndex + 1] = minSum;
            data.RemoveAt(minIndex);
            count++;
        }

        return count;
    }
}
