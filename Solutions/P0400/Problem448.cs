namespace Solutions.P0400;

public class Problem448
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int pos = Math.Abs(nums[i]) - 1;
            if (nums[pos] > 0)
                nums[pos] = -nums[pos];
        }

        var result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
            if (nums[i] > 0) 
                result.Add(i + 1);

        return result;
    }
}
