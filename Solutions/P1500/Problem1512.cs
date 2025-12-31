namespace Solutions.P1500;

public class Problem1512
{
    public int NumIdenticalPairs(int[] nums)
    {
        var count = 0;

        for(int i = 1; i < nums.Length; i++)
            for(int k = 0; k < i; k++)
                if (nums[i] == nums[k])
                    count++;

        return count;
    }
}
