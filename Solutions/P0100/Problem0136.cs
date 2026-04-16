using System.Numerics;
using System.Runtime.InteropServices;

namespace Solutions.P0100;

public class Problem0136
{
    public int SingleNumber(int[] nums)
    {
        var ans = 0;

        for (int i = 0; i < nums.Length; i++)
            ans ^= nums[i];

        return ans;
    }

    public int SingleNumberSimd(int[] nums)
    {        
        var vecc = Vector<int>.Count;
        var tail = nums.Length - nums.Length % vecc;

        var vectors = MemoryMarshal.Cast<int, Vector<int>>(nums);
        var ans = Vector<int>.Zero;        

        for (int i = 0; i < vectors.Length; i++)
            ans ^= vectors[i];
        
        var scalar = 0;
        for (int i = tail; i < nums.Length; i++)
            scalar ^= nums[i];

        for (int k = 0; k < vecc; k++)
            scalar ^= ans[k];

        return scalar;
    }
}