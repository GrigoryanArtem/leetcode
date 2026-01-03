namespace Solutions.P3400;

public class Problem3467
{
    public int[] TransformArray(int[] nums)
    {
        var result = new int[nums.Length];
        var right = nums.Length;

        for (int i = 0; i < nums.Length; i++)
            if (nums[i] % 2 != 0)
                result[--right] = 1;

        return result;
    }
}
