namespace Solutions.P3500;

public class Problem3512
{
    public int MinOperations(int[] nums, int k)
    {
        var sum = 0;
        for (int i = 0; i < nums.Length; i++)
            sum += nums[i];

        return sum % k;
    }
}
