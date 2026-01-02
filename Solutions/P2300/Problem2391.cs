namespace Solutions.P2300;

public class Problem2391
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        var time = 0;
        var found = 0U;

        Span<char> names = ['M', 'P', 'G'];
        Span<int> idx = stackalloc int[names.Length];

        Span<int> travelTime = stackalloc int[travel.Length + 1];
        for (int i = 0; i < travelTime.Length - 1; i++)
            travelTime[i + 1] = travel[i] + travelTime[i];

        for (int i = garbage.Length - 1; found != 0b111 && i >= 0; i--)
        {
            for (int k = 0; k < idx.Length; k++)
            {
                if(((found >> k) & 1U) == 0U && garbage[i].Contains(names[k]))
                {
                    found |= (1U << k);
                    idx[k] = i;
                }
            }
        }

        for (int i = 0; i < garbage.Length; i++)
            time += garbage[i].Length;

        for (int i = 0; i < idx.Length; i++)
            time += travelTime[idx[i]];

        return time;
    }
}
