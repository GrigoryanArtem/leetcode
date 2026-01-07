namespace Solutions.P2100;

public class Problem2161
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        var result = new int[nums.Length];

        var left = 0;
        var right = nums.Length - 1;

        for (int i = 0, k = nums.Length - 1; i < nums.Length; i++, k--)
        {
            if (nums[i] < pivot)
                result[left++] = nums[i];

            if (nums[k] > pivot)
                result[right--] = nums[k];
        }

        for (int i = left; i <= right; i++)
            result[i] = pivot;

        return result;
    }
}
