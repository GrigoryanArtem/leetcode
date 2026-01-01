namespace Solutions.P2500;

public class Problem2574
{
    public int[] LeftRightDifference(int[] nums)
    {
        var result = new int[nums.Length];
        for (int i = nums.Length - 1; i > 0; i--)
            result[i - 1] = result[i] + nums[i];

        var acc = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            result[i] = Math.Abs(acc - result[i]);
            acc += nums[i];
        }

        return result;
    }
}
