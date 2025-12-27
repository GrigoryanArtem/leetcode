using System.Numerics;

namespace Solutions.P3700;

public class Problem3760
{
    public int MaxDistinct(string s)
    {
        var set = 0U;
        for(int i = 0; i < s.Length; i++)
            set |= 1U << (s[i] - 'a');

        return BitOperations.PopCount(set);
    }
}
