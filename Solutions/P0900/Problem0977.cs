using System.Numerics;
using System.Runtime.InteropServices;

namespace Solutions.P0900;

public class Problem0977
{
    public int[] SortedSquares(int[] nums)
    {
        var span = nums.AsSpan();
        var tail = span.Length - (span.Length % Vector<int>.Count);

        var vectors = MemoryMarshal.Cast<int, Vector<int>>(span);
        for (int i = 0; i < vectors.Length; i++)
            vectors[i] *= vectors[i];

        for (int i = tail; i < span.Length; i++)
            span[i] *= span[i]; 

        var ans = new int[span.Length];
        var aidx = span.Length;

        var lo = 0;
        var hi = span.Length - 1;

        while (lo <= hi)
            ans[--aidx] = span[lo] > span[hi] ? span[lo++] : span[hi--];

        return ans;
    }
}
